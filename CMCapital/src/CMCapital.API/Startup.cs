using CMCapital.Data;
using CMCapital.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using CMCapital.API.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CMCapital.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;

namespace CMCapital.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddEnvironmentVariables()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.SetBasePath(Directory.GetCurrentDirectory());

            Configuration = builder.Build();

            env.ConfigureLog4Net("log4net.xml");

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CustomDataContractResolver()
            };
        }

        public IConfigurationRoot Configuration { get; }
        //private readonly ILogger<Startup> Logger;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddJsonOptions(opt =>
            {
                var resolver = opt.SerializerSettings.ContractResolver;

                if (resolver != null)
                {
                    var res = resolver as DefaultContractResolver;
                    res.NamingStrategy = null;  // <<!-- this removes the camelcasing
                }
            });

            services.AddCors();
            services.AddOptions();

            var conn = Configuration.GetConnectionString("ConnectionStringCMCapital"); 

            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<CMCapitalContext>(options => options.UseSqlServer(conn));


            services
                // Services
                .AddTransient<IClientesService, ClientesService>()
                .AddTransient<IProdutosService, ProdutosService>()
                .AddTransient<IClientesProdutosService, ClientesProdutosService>()
                .AddTransient<ITaxasService, TaxasService>()
                .AddScoped<LogProcessRequestFilter>()

                // Modules

                //// Repositories
                .AddTransient<IClientesRepository, ClientesRepository>()
                .AddTransient<IProdutosRepository, ProdutosRepository>()
                .AddTransient<IClientesProdutosRepository, ClientesProdutosRepository>()
                .AddTransient<ITaxasRepository, TaxasRepository>()
                ;


            services.AddScoped<GlobalExceptionHandlingFilter>();
			services.AddScoped<GlobalActionLogger>();

			services.AddScoped<CMCapitalContext>();
            services.AddSingleton<IConfiguration>(Configuration);


			services.AddMvc(options =>
			{
				options.Filters.Add(new ServiceFilterAttribute(typeof(GlobalActionLogger)));
				options.Filters.Add<GlobalExceptionHandlingFilter>();
			});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CMCapital", Version = "v1"});
            });

			//services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddLog4Net();

            app.UseSwagger();
            app.UseSwaggerUI();

            //if (env.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/swagger.json", "CMCapital v1"));
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/", "swagger.json"));
            //}

			app.UseMvc();
        }
    }
}