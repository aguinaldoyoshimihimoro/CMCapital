using System;
using Microsoft.AspNetCore.Mvc;
using CMCapital.Service;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CMCapital.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientesResultController : Controller
    {
        private IClientesService _service;
        private ILogger _logger;

        public ClientesResultController(IClientesService service, ILogger<ClientesController> logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}
