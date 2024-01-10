using System;
//using CMCapital.ViewModel;
using CMCapital.Data;
using CMCapital.Domain.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CMCapital.Service
{
    public class LogRequestService : ILogRequestService
    {
        private CMCapitalContext _context;
        private ILogger _logger;

        public LogRequestService(CMCapitalContext context, ILogger<LogRequestService> logger)
        {
            _context = context;
            _logger = logger;
        }

        //public void LogProcessRequest(PortfolioViewModel viewModel, string jsonContent)
        //{
        //    var logRequest = new LogProcessRequest
        //    {
        //        PortfolioName = viewModel.Name,
        //        PortfolioId = viewModel.PortfolioId,
        //        CompositionId = viewModel.CompositionId,
        //        RequestedOn = DateTime.Now,
        //        Content = jsonContent
        //    };
        //    _context.LogProcessRequests.Add(logRequest);
        //    _context.SaveChanges();
        //}

        //public void LogProcessRequestFile(PortfolioViewModel viewModel, string jsonContent)
        //{
        //    var logRequest = new LogProcessRequest
        //    {
        //        PortfolioName = viewModel.Name,
        //        PortfolioId = viewModel.PortfolioId,
        //        CompositionId = viewModel.CompositionId,
        //        RequestedOn = DateTime.Now,
        //        Content = jsonContent
        //    };

        //    this._logger.LogWarning(jsonContent);

        //}
    }
}
