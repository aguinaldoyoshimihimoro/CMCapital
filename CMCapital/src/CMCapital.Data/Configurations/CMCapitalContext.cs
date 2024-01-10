using CMCapital.Data;
using CMCapital.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using CMCapital.Domain;
using CMCapital.Domain.Infrastructure;

namespace CMCapital.Data
{
    public class CMCapitalContext : DbContext
    {
        public CMCapitalContext()
        {
            this.Database.SetCommandTimeout(180);
        }

        public CMCapitalContext(DbContextOptions<CMCapitalContext> options) : base(options) { }

        

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<ClientesProdutos> ClientesProdutos { get; set; }
        public DbSet<Taxas> Taxas { get; set; }

        public DbSet<LogProcessRequest> LogProcessRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //Altere a string de conexão no appsettings.json presente na raiz do Hub.Lquidity.API, pois, vem pela injeção de dependência
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(ClientesConfiguration.Configure);
        }
    }

    internal static class Extensions
    {
        public static Microsoft.EntityFrameworkCore.EntityState AsEntityState(this CMCapital.Domain.State state)
        {
            return (Microsoft.EntityFrameworkCore.EntityState)((int)state);
        }
    }
}