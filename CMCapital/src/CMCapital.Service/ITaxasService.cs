using System.Collections.Generic;
using System.Threading.Tasks;
using CMCapital.Domain;
//using CMCapital.ViewModel;

namespace CMCapital.Service
{
    public interface ITaxasService
    {
        Task<List<Taxas>> GetTaxasDownload(int idCodTaxa);

        Task SaveAsync(int idCodTaxa, List<Taxas> taxasVM);
    }
}