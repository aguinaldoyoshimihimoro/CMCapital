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
    public class ClientesRepository : IClientesRepository
    {
        private CMCapitalContext _context;

        public ClientesRepository(CMCapitalContext context)
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

        public async Task<List<Clientes>> GetClienteDownload(int idCodCliente)
        {
            return await this._context.Clientes.Where(cc => cc.Id_Cod_Cliente == idCodCliente).AsNoTracking().ToListAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<Clientes> clientes)
        {
            if (clientes == null || !clientes.Any())
                return;

            this._context.Clientes.RemoveRange(clientes);
            await this._context.SaveChangesAsync();
        }

        public async Task<bool> AddOrUpdateAsync(Clientes clientes)
        {
            if (clientes == null)
                return false;

            var clientesFromDb = await this._context.Clientes
                                            .Where(ISD => ISD.Nome == clientes.Nome
                                                )
                                            .FirstOrDefaultAsync();

            if (clientesFromDb == null)
            {
                clientes.Id_Cod_Cliente = 0; 
                this._context.Clientes.Add(clientes);
                return await this._context.SaveChangesAsync() > 0;
            }
            else
            {
                if (clientes.Compare(clientesFromDb))
                    return true;

                clientesFromDb.Nome = clientes.Nome;
                clientesFromDb.Dt_Ultima_Compra = clientes.Dt_Ultima_Compra;
                clientesFromDb.Saldo = clientes.Saldo;
                
                return await this._context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> Delete(int idCodCliente)
        {
            var settingsFromDb = await this._context.Clientes
                                            .Where(ps => ps.Id_Cod_Cliente == idCodCliente)
                                            .FirstOrDefaultAsync();

            _context.Clientes.Remove(settingsFromDb);

            return await this._context.SaveChangesAsync() > 0;
        }
    }
}