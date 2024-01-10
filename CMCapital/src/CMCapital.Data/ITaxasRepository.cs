using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMCapital.Domain;

namespace CMCapital.Data
{
    public interface ITaxasRepository
    {
        Task AddRangeAsyncDownload(IEnumerable<Taxas> taxas);

        Task<List<Taxas>> GetTaxasDownload(int idCodCliente);

        Task DeleteRangeAsync(IEnumerable<Taxas> taxas);

        Task<bool> AddOrUpdateAsync(Taxas taxas);

        Task AddRangeAsyncUpload(IEnumerable<Taxas> taxas);
    }
}