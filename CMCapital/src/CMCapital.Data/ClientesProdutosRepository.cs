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
    public class ClientesProdutosRepository : IClientesProdutosRepository
    {
        private CMCapitalContext _context;

        public ClientesProdutosRepository(CMCapitalContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsyncDownload(IEnumerable<ClientesProdutos> clientesProdutos)
        {
            if (clientesProdutos == null || !clientesProdutos.Any())
                return;

            this._context.ClientesProdutos.AddRange(clientesProdutos);
            await this._context.SaveChangesAsync();
        }

        public async Task AddRangeAsyncUpload(IEnumerable<ClientesProdutos> clientesProdutos)
        {
            if (clientesProdutos == null || !clientesProdutos.Any())
                return;

            this._context.ClientesProdutos.AddRange(clientesProdutos);
            await this._context.SaveChangesAsync();
        }

        public async Task<List<ClientesProdutos>> GetClienteProdutoDownload(int idCodCliente)
        {
            return await this._context.ClientesProdutos.Where(cc => cc.Id_Cod_Cliente == idCodCliente).AsNoTracking().ToListAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<ClientesProdutos> clientesProdutos)
        {
            if (clientesProdutos == null || !clientesProdutos.Any())
                return;

            this._context.ClientesProdutos.RemoveRange(clientesProdutos);
            await this._context.SaveChangesAsync();
        }

        public async Task<bool> AddOrUpdateAsync(ClientesProdutos clientesProdutos)
        {
            if (clientesProdutos == null)
                return false;

            //var investorsSegmentDistributionsFromDb = await this._context.Clientes
            //                                .Where(ISD => ISD.Id_Cod_Cliente == clientes.Id_Cod_Cliente
            //                                    //&& ISD.Date == investorsSegmentDistributions.Date
            //                                    //&& ISD.CompanyId == investorsSegmentDistributions.CompanyId
            //                                    //&& ISD.PortfolioId == investorsSegmentDistributions.PortfolioId
            //                                    //&& ISD.SegmentType == investorsSegmentDistributions.SegmentType
            //                                    )
            //                                .FirstOrDefaultAsync();

            //if (investorsSegmentDistributionsFromDb == null)
            //{
            //    clientes.Id_Cod_Cliente = 0; 
            //    this._context.Clientes.Add(clientes);
            //    return await this._context.SaveChangesAsync() > 0;
            //}
            //else
            //{
            //    if (clientes.Compare(investorsSegmentDistributionsFromDb))
            //        return true;

            //    investorsSegmentDistributionsFromDb.Id_Cod_Cliente = clientes.Id_Cod_Cliente;
            //    //investorsSegmentDistributionsFromDb.SegmentType = investorsSegmentDistributions.SegmentType;
            //    //investorsSegmentDistributionsFromDb.NAVPercentage = investorsSegmentDistributions.NAVPercentage;
            //    //investorsSegmentDistributionsFromDb.IsFeeder = investorsSegmentDistributions.IsFeeder;

            return await this._context.SaveChangesAsync() > 0;
            //}
        }

        public async Task<bool> Delete(int idCodCliente)
        {
            var settingsFromDb = await this._context.ClientesProdutos
                                            .Where(ps => ps.Id_Cod_Cliente == idCodCliente)
                                            .FirstOrDefaultAsync();

            _context.ClientesProdutos.Remove(settingsFromDb);

            return await this._context.SaveChangesAsync() > 0;
        }
    }
}


