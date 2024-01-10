using System.Collections.Generic;
using System.Threading.Tasks;
using CMCapital.Domain;
//using CMCapital.ViewModel;

namespace CMCapital.Service
{
    public interface IProdutosService
    {
        Task<List<Produtos>> GetProdutosDownload(int idCodProduto);


        Task SaveAsync(int idCodCliente, List<Produtos> clientesVM);
    }
}