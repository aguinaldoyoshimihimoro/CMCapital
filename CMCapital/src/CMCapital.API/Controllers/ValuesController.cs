using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CMCapital.Data;
using Microsoft.Extensions.Logging;

namespace CMCapital.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        CMCapitalContext _context;
        private ILogger _logger;

        public ValuesController(CMCapitalContext context, ILogger<ValuesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] 
            {
                "1",
                "2"
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
