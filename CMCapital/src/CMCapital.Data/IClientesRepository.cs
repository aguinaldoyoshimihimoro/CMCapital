
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMCapital.Domain;

namespace CMCapital.Data
{
    public interface IClientesRepository
    {
        Task AddRangeAsyncDownload(IEnumerable<Clientes> clientes);

        Task<List<Clientes>> GetClienteDownload(int idCodCliente);
 
        Task DeleteRangeAsync(IEnumerable<Clientes> clientes);

        Task<bool> AddOrUpdateAsync(Clientes clientes);

        Task AddRangeAsyncUpload(IEnumerable<Clientes> clientes);
    }
}