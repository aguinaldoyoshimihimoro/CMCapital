
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
//using CMCapital.ViewModel;
using CMCapital.Service;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CMCapital.Domain;

namespace CMCapital.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ClientesController : Controller
    {
        private IClientesService _service;
        private ILogger _logger;

        public ClientesController(IClientesService service, ILogger<ClientesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("PesquisaCliente")]

        public async Task<ActionResult> GetPorCliente(int idCodCliente)
        {
            try
            {
                if (idCodCliente == default(int))
                    return BadRequest();

                var clientesVM = await this._service.GetClienteDownload(idCodCliente: idCodCliente);

                
                return Ok(clientesVM);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Error getting Cliente: {ex.Message}.");
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new Microsoft.AspNetCore.Mvc.ObjectResult(ex.Message);
            }
        }
    }
}