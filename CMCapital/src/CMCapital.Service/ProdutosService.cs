using CMCapital.Data;
using CMCapital.Domain;
//using CMCapital.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMCapital.Service
{
    public class ProdutosService : IProdutosService
    {
        private IProdutosRepository _produtosRepository;

        public ProdutosService(IProdutosRepository produtosRepository)

        {
            _produtosRepository = produtosRepository;
        }

        public async Task<List<Produtos>> GetProdutosDownload(int idCodProduto)
        {
            var produtos = await _produtosRepository.GetProdutosDownload(idCodProduto);

            if (produtos == null && !produtos.Any())
                return new List<Produtos>();

            var produtosVM = produtos.Select(
                cc => new Produtos
                {
                    Id_Cod_Produto = cc.Id_Cod_Produto,
                    Descricao = cc.Descricao,
                    Dt_Vencimento = cc.Dt_Vencimento,
                    Dt_Cadastro = cc.Dt_Cadastro,
                    Vr_Unitario = cc.Vr_Unitario
                }
            ).ToList();

            return produtosVM;
        }

        public async Task SaveAsync(int idCodCliente, List<Produtos> clientesVM)
        {
            //if (idCodCliente <= default(int) || clientesVM == null || !clientesVM.Any())
            //    return;

            //Clientes tmpData = null;

            //Verifica integridade do SubClass
            //if (clientesVM.Count > 0)
            //{
            //    decimal acumulado = 0;

            //    for (int i = 0; i < clientesVM.Count; i++)
            //    {
            //        acumulado += clientesVM[i].NAVPercentage;
            //    }

            //    if (acumulado > 100)
            //    {
            //        throw new Exception("Percentual de Segmento de Investidores maior que 100%");
            //    }
            //    else if (acumulado < 100)
            //    {
            //        if (!clientesVM.Contains(new Clientes() { SegmentType = 6 }))
            //        {
            //            tmpData = new Clientes();

            //            tmpData.NAVPercentage = 100 - acumulado;
            //            tmpData.IsFeeder = clientesVM[0].IsFeeder;
            //            tmpData.PortfolioId = clientesVM[0].IsFeeder;
            //            tmpData.SegmentType = 6;

            //            clientesVM.Add(tmpData);
            //        }
            //        else
            //        {
            //            var registros = clientesVM.Where(x => x.SegmentType == 6).ToList();

            //            if (registros.Count > 1)
            //            {
            //                if (registros[0].NAVPercentage + acumulado > 100)
            //                {
            //                    throw new Exception("Percentual de Segmento de Investidores maior que 100%");
            //                }
            //                else
            //                {
            //                    registros[0].NAVPercentage += 100 - acumulado;
            //                }
            //            }
            //        }
            //    }
            //}

            var produtosTemp = clientesVM.Select(
                pVM => new Produtos
                {
                    Id_Cod_Produto = pVM.Id_Cod_Produto,
                    Descricao = pVM.Descricao,
                    Dt_Vencimento = pVM.Dt_Vencimento,
                    Dt_Cadastro = pVM.Dt_Cadastro,
                    Vr_Unitario = pVM.Vr_Unitario
                }
            ).ToList();

            //var investorsSegmentDistributionsToDeleteTemp = investorsSegmentDistributionsTemp.Where(b => !string.IsNullOrEmpty(b.Operation) && b.Operation.Equals("DELETE", StringComparison.InvariantCultureIgnoreCase)).ToList();

            //var investorsSegmentDistributionsToDelete = investorsSegmentDistributionsToDeleteTemp.Select(
            //   cc => new Clientes
            //   {
            //       Id = cc.Id,
            //       Date = cc.Date,
            //       CompanyId = companyId,
            //       PortfolioId = cc.PortfolioId,
            //       SegmentType = cc.SegmentType,
            //       NAVPercentage = cc.NAVPercentage,
            //       IsFeeder = cc.IsFeeder
            //   }
            //).ToList();

            //foreach (Clientes investorsSegmentDistributionDelete in investorsSegmentDistributionsToDelete)
            //{
            //    int Id = investorsSegmentDistributionDelete.Id;
            //    int PortfolioId = investorsSegmentDistributionDelete.PortfolioId;
            //    DateTime Date = investorsSegmentDistributionDelete.Date;
            //    int SegmentType = investorsSegmentDistributionDelete.SegmentType;

            //    var investorsSegmentDistributionsFromDb = await this._clientesRepository.GetByCompanyByPortfolioIdByDateAsyncDownload(Id, companyId, PortfolioId, Date);

            //    await this._clientesRepository.DeleteRangeAsync(investorsSegmentDistributionsFromDb);
            //}

            //var investorsSegmentDistributionsToInsertUpdateTemp = clientesTemp.Where(b => string.IsNullOrEmpty(b.Operation) || b.Operation.Equals("UPDATE", StringComparison.InvariantCultureIgnoreCase) || b.Operation.Equals(" ", StringComparison.InvariantCultureIgnoreCase)).ToList();
            //investorsSegmentDistributionsToInsertUpdateTemp = investorsSegmentDistributionsToInsertUpdateTemp.Except(investorsSegmentDistributionsToDeleteTemp).ToList();

            //var investorsSegmentDistributionsToInsertUpdate = investorsSegmentDistributionsToInsertUpdateTemp.Select(
            //   cc => new Clientes
            //   {
            //       Id = cc.Id,
            //       Date = cc.Date,
            //       CompanyId = companyId,
            //       PortfolioId = cc.PortfolioId,
            //       SegmentType = cc.SegmentType,
            //       NAVPercentage = cc.NAVPercentage,
            //       IsFeeder = cc.IsFeeder
            //   }
            //).ToList();

            //var clientesUpdateToDelete = clientesTemp.Select(
            //   cc => new Clientes
            //   {
            //       Id_Cod_Cliente = cc.Id_Cod_Cliente//,
            ////       Date = cc.Date,
            ////       CompanyId = companyId,
            ////       PortfolioId = cc.PortfolioId,
            ////       SegmentType = cc.SegmentType,
            ////       NAVPercentage = cc.NAVPercentage,
            ////       IsFeeder = cc.IsFeeder
            //   }
            //).ToList();

            //foreach (Clientes investorsSegmentDistributionDelete in investorsSegmentDistributionsUpdateToDelete)
            //{
            //    int Id = investorsSegmentDistributionDelete.Id;
            //    int PortfolioId = investorsSegmentDistributionDelete.PortfolioId;
            //    DateTime Date = investorsSegmentDistributionDelete.Date;
            //    int SegmentType = investorsSegmentDistributionDelete.SegmentType;

            //    var investorsSegmentDistributionsFromDb = await this._clientesRepository.GetByCompanyByPortfolioIdByDateNewAsyncDownload(companyId, PortfolioId, Date);

            //    if (investorsSegmentDistributionsFromDb.Count > 0)
            //    {
            //        await this._clientesRepository.DeleteRangeAsync(investorsSegmentDistributionsFromDb);
            //    }
            //}

            foreach (Produtos produtosInsertUpdate in produtosTemp)
            {
                await this._produtosRepository.AddOrUpdateAsync(produtosInsertUpdate);
            }
        }
    }
}