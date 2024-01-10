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
    public class ClientesProdutosController : Controller
    {
        private IClientesProdutosService _service;
        private ILogger _logger;

        public ClientesProdutosController(IClientesProdutosService service, ILogger<ClientesProdutosController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("ProdutosCompradosPorCliente")]
        public async Task<ActionResult> GetPorProdutoCliente(int idCodCliente)
        {
            try
            {
                if (idCodCliente == default(int))
                    return BadRequest();

                var clientesVM = await this._service.GetClienteProdutoDownload(idCodCliente: idCodCliente);


                return Ok(clientesVM);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Error getting Client: {ex.Message}.");
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new Microsoft.AspNetCore.Mvc.ObjectResult(ex.Message);
            }
        }
    }
}