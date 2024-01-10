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
    public class ProdutosController : Controller
    {
        private IProdutosService _service;
        private ILogger _logger;

        public ProdutosController(IProdutosService service, ILogger<ProdutosController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("PesquisaCliente")]
        public async Task<ActionResult> GetProdutos(int idCodProduto)
        {
            try
            {
                if (idCodProduto == default(int))
                    return BadRequest();

                var clientesVM = await this._service.GetProdutosDownload(idCodProduto: idCodProduto);

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