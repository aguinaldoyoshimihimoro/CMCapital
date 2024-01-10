
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
    public class TaxasController : Controller
    {
        private ITaxasService _service;
        private ILogger _logger;

        public TaxasController(ITaxasService service, ILogger<TaxasController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("PesquisaTaxa")]
        public async Task<ActionResult> GetTaxas(int idCodTaxa)
        {
            try
            {
                if (idCodTaxa == default(int))
                    return BadRequest();

                var taxasVM = await this._service.GetTaxasDownload(idCodTaxa: idCodTaxa);

                return Ok(taxasVM);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Error getting Taxa: {ex.Message}.");
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new Microsoft.AspNetCore.Mvc.ObjectResult(ex.Message);
            }
        }
    }
}