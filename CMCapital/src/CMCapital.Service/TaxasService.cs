using CMCapital.Data;
using CMCapital.Domain;
//using CMCapital.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMCapital.Service
{
    public class TaxasService : ITaxasService
    {
        private ITaxasRepository _taxasRepository;

        public TaxasService(ITaxasRepository taxasRepository)

        {
            _taxasRepository = taxasRepository;
        }

        public async Task<List<Taxas>> GetTaxasDownload(int idCodTaxa)
        {
            var taxas = await _taxasRepository.GetTaxasDownload(idCodTaxa);

            if (taxas == null && !taxas.Any())
                return new List<Taxas>();

            var taxasVM = taxas.Select(
                cc => new Taxas
                {
                    Id_Cod_Taxa = cc.Id_Cod_Taxa,
                    Vr_Inicial = cc.Vr_Inicial,
                    Vr_Final = cc.Vr_Final,
                    Percentual = cc.Percentual
                }
            ).ToList();

            return taxasVM;
        }


        public async Task SaveAsync(int idCodTaxa, List<Taxas> taxasVM)
        {

            var taxasTemp = taxasVM.Select(
                pVM => new Taxas
                {
                    Id_Cod_Taxa = pVM.Id_Cod_Taxa,
                    Vr_Inicial = pVM.Vr_Inicial,
                    Vr_Final = pVM.Vr_Final,
                    Percentual = pVM.Percentual
                }
            ).ToList();


            foreach (Taxas taxasInsertUpdate in taxasTemp)
            {
                await this._taxasRepository.AddOrUpdateAsync(taxasInsertUpdate);
            }
        }
    }
}