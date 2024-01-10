using System.Collections.Generic;
using System.Threading.Tasks;
using CMCapital.Domain;
//using CMCapital.ViewModel;

namespace CMCapital.Service
{
    public interface IClientesService
    {
        Task<List<Clientes>> GetClienteDownload(int idCodCliente);
        

        Task SaveAsync(int idCodCliente, List<Clientes> clientesVM);
    }
}