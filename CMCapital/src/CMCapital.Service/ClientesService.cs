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
    public class ClientesService : IClientesService
    {
        private IClientesRepository _clientesRepository;
        private IProdutosRepository _produtosRepository;

        public ClientesService(IClientesRepository clientesRepository, IProdutosRepository produtosRepository)

        {
            _clientesRepository = clientesRepository;
            _produtosRepository = produtosRepository;

        }


        public async Task<List<Clientes>> GetClienteDownload(int idCodCliente)
        {
            var clientes = await _clientesRepository.GetClienteDownload(idCodCliente);

            if (clientes == null && !clientes.Any())
                return new List<Clientes>();

            var clientesVM = clientes.Select(
                cc => new Clientes
                {
                    Id_Cod_Cliente = cc.Id_Cod_Cliente,
                      Nome = cc.Nome,
                      Dt_Ultima_Compra = cc.Dt_Ultima_Compra,
                      Saldo = cc.Saldo
                }
            ).ToList();

            return clientesVM;
        }

        public async Task SaveAsync(int idCodCliente, List<Clientes> clientesVM)
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

            var clientesTemp = clientesVM.Select(
                pVM => new Clientes
                {
                    //Operation = pVM.Operation,
                    Id_Cod_Cliente = pVM.Id_Cod_Cliente//,
                    //Date = pVM.Date,
                    //CompanyId = companyId,
                    //PortfolioId = pVM.PortfolioId,
                    //SegmentType = pVM.SegmentType,
                    //NAVPercentage = pVM.NAVPercentage,
                    //IsFeeder = pVM.IsFeeder
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

            foreach (Clientes clientesInsertUpdate in clientesTemp)
            {
                await this._clientesRepository.AddOrUpdateAsync(clientesInsertUpdate);
            }
        }
    }
}