
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMCapital.Domain;

namespace CMCapital.Data
{
    public interface IProdutosRepository
    {
        Task AddRangeAsyncDownload(IEnumerable<Clientes> clientes);

        Task<List<Produtos>> GetProdutosDownload(int idCodProduto);

        //Task<List<Clientes>> GetByCompanyByPortfolioIdByDateAsyncDownload(int Id, int companyId, int PortfolioId, DateTime Date);

        //Task<List<Clientes>> GetByCompanyByPortfolioIdByDateNewAsyncDownload(int companyId, int PortfolioId, DateTime Date);

        //Task<List<Clientes>> GetByPortfolioAsyncDownload(int portfolioId);

        Task<List<Clientes>> GetAllByCompanyAsyncDownload(int companyId);

        Task DeleteRangeAsync(IEnumerable<Produtos> clientes);

        Task<bool> AddOrUpdateAsync(Produtos clientes);

        Task AddRangeAsyncUpload(IEnumerable<Clientes> clientes);
    }
}