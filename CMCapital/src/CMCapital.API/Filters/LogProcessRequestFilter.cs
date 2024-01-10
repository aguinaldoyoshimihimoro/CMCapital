using CMCapital.Service;
//using CMCapital.ViewModel;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CMCapital.API.Filters
{
    public class LogProcessRequestFilter : ActionFilterAttribute
    {
        private ILogRequestService _logRequestService;

        public LogProcessRequestFilter(ILogRequestService logRequestService)
        {
            _logRequestService = logRequestService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            //var model = (PortfolioViewModel) context.ActionArguments["viewModel"];
            //var json = JsonConvert.SerializeObject(model); 
            //_logRequestService.LogProcessRequest(model, json);

            // Logar em arquivo quando estiver no modo "debug"
#if (DEBUG)
                //_logRequestService.LogProcessRequestFile(model, json); 
#endif
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }

    }
}
