
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMCapital.Domain;

namespace CMCapital.Data
{
    public interface IClientesProdutosRepository
    {
        Task AddRangeAsyncDownload(IEnumerable<ClientesProdutos> clientesProdutos);

        Task<List<ClientesProdutos>> GetClienteProdutoDownload(int idCodCliente);

        Task DeleteRangeAsync(IEnumerable<ClientesProdutos> clientesProdutos);

        Task<bool> AddOrUpdateAsync(ClientesProdutos clientesProdutos);

        Task AddRangeAsyncUpload(IEnumerable<ClientesProdutos> clientesProdutos);
    }
}