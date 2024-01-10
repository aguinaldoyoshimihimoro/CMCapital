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
    public class TaxasRepository : ITaxasRepository
    {
        private CMCapitalContext _context;

        public TaxasRepository(CMCapitalContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsyncDownload(IEnumerable<Taxas> taxas)
        {
            if (taxas == null || !taxas.Any())
                return;

            this._context.Taxas.AddRange(taxas);
            await this._context.SaveChangesAsync();
        }

        public async Task AddRangeAsyncUpload(IEnumerable<Taxas> taxas)
        {
            if (taxas == null || !taxas.Any())
                return;

            this._context.Taxas.AddRange(taxas);
            await this._context.SaveChangesAsync();
        }

        
        public async Task<List<Taxas>> GetTaxasDownload(int idCodTaxa)
        {
            return await this._context.Taxas.Where(cc => cc.Id_Cod_Taxa == idCodTaxa).AsNoTracking().ToListAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<Taxas> taxas)
        {
            if (taxas == null || !taxas.Any())
                return;

            this._context.Taxas.RemoveRange(taxas);
            await this._context.SaveChangesAsync();
        }

        public async Task<bool> AddOrUpdateAsync(Taxas taxas)
        {
            if (taxas == null)
                return false;

            var TaxasFromDb = await this._context.Taxas
                                            .Where(ISD => ISD.Id_Cod_Taxa == taxas.Id_Cod_Taxa
                                                && ISD.Vr_Inicial == taxas.Vr_Inicial
                                                && ISD.Vr_Final == taxas.Vr_Final
                                                && ISD.Percentual == taxas.Percentual
                                                )

                                            .FirstOrDefaultAsync();

            if (TaxasFromDb == null)
            {
                taxas.Id_Cod_Taxa = 0;
                this._context.Taxas.Add(taxas);
                return await this._context.SaveChangesAsync() > 0;
            }
            else
            {
                if (taxas.Compare(TaxasFromDb))
                    return true;

                TaxasFromDb.Id_Cod_Taxa = taxas.Id_Cod_Taxa;
                TaxasFromDb.Vr_Inicial = taxas.Vr_Inicial;
                TaxasFromDb.Vr_Final = taxas.Vr_Final;
                TaxasFromDb.Percentual = taxas.Percentual;

                return await this._context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> Delete(int idCodTaxa)
        {
            var settingsFromDb = await this._context.Taxas
                                            .Where(ps => ps.Id_Cod_Taxa == idCodTaxa)
                                            .FirstOrDefaultAsync();

            _context.Taxas.Remove(settingsFromDb);

            return await this._context.SaveChangesAsync() > 0;
        }
    }
}