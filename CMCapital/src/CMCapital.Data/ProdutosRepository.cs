
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using CMCapital.Domain;
//using CMCapital.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CMCapital.Data
{
    public class ProdutosRepository : IProdutosRepository
    {
        private CMCapitalContext _context;

        public ProdutosRepository(CMCapitalContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsyncDownload(IEnumerable<Clientes> clientes)
        {
            if (clientes == null || !clientes.Any())
                return;

            this._context.Clientes.AddRange(clientes);
            await this._context.SaveChangesAsync();
        }

        public async Task AddRangeAsyncUpload(IEnumerable<Clientes> clientes)
        {
            if (clientes == null || !clientes.Any())
                return;

            this._context.Clientes.AddRange(clientes);
            await this._context.SaveChangesAsync();
        }

        public async Task<List<Produtos>> GetProdutosDownload(int idCodProduto)
        {
            return await this._context.Produtos.Where(cc => cc.Id_Cod_Produto == idCodProduto).AsNoTracking().ToListAsync();
        }

        public async Task<List<Clientes>> GetAllByCompanyAsyncDownload(int companyId)
        {
            return await this._context
                .Clientes
        .Where(cc => cc.Id_Cod_Cliente == companyId && cc.Id_Cod_Cliente != 0)
        .OrderByDescending(d => d.Id_Cod_Cliente)
        .AsNoTracking()
                .ToListAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<Produtos> produtos)
        {
            if (produtos == null || !produtos.Any())
                return;

            this._context.Produtos.RemoveRange(produtos);
            await this._context.SaveChangesAsync();
        }

        public async Task<bool> AddOrUpdateAsync(Produtos produtos)
        {
            if (produtos == null)
                return false;

            var produtosFromDb = await this._context.Produtos
                                            .Where(ISD => ISD.Id_Cod_Produto == produtos.Id_Cod_Produto
                                                && ISD.Dt_Cadastro == produtos.Dt_Cadastro
                                                && ISD.Dt_Vencimento == produtos.Dt_Vencimento
                                                && ISD.Vr_Unitario == produtos.Vr_Unitario
                                                )
                                            .FirstOrDefaultAsync();

            if (produtosFromDb == null)
            {
                produtos.Id_Cod_Produto = 0;
                this._context.Produtos.Add(produtos);
                return await this._context.SaveChangesAsync() > 0;
            }
            else
            {
                if (produtos.Compare(produtosFromDb))
                    return true;

                produtosFromDb.Id_Cod_Produto = produtos.Id_Cod_Produto;
                produtosFromDb.Dt_Cadastro = produtos.Dt_Cadastro;
                produtosFromDb.Dt_Vencimento = produtos.Dt_Vencimento;
                produtosFromDb.Vr_Unitario = produtos.Vr_Unitario;

                return await this._context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> Delete(int idCodProduto)
        {
            var settingsFromDb = await this._context.Produtos
                                            .Where(ps => ps.Id_Cod_Produto == idCodProduto)
                                            .FirstOrDefaultAsync();

            _context.Produtos.Remove(settingsFromDb);

            return await this._context.SaveChangesAsync() > 0;
        }
    }
}