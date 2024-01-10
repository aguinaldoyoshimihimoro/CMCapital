using System.Collections.Generic;
using System.Threading.Tasks;
using CMCapital.Domain;
//using CMCapital.ViewModel;

namespace CMCapital.Service
{
    public interface IClientesProdutosService
    {
        Task<List<ClientesProdutos>> GetClienteProdutoDownload(int idCodCliente);


        Task SaveAsync(int idCodCliente, List<ClientesProdutos> clientesVM);
    }
}