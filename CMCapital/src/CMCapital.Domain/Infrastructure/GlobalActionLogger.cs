using System;

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CMCapital.Domain.Infrastructure
{
    public class GlobalActionLogger : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var message = new
            {
                Version = "v1.0",
                Application = "RISK API",
                Source = "GlobalActionLoggerFilter",
                User = filterContext.HttpContext.User.Identity.Name,
                Hostname = filterContext.HttpContext.Request.Host.Host,
                Url = filterContext.HttpContext.Request.GetDisplayUrl(),
                DateTime = DateTime.Now,
                Method = filterContext.HttpContext.Request.Method,
                StatusCode = filterContext.HttpContext.Response.StatusCode,
                Data = filterContext.Exception?.Data,                
                TimeStamp = DateTime.Now,
                Detail = JsonConvert.SerializeObject(new { IP = filterContext.HttpContext.Connection.RemoteIpAddress.ToString(),
                    AreaAccessed = filterContext.HttpContext.Request.GetDisplayUrl(),
                    Action = filterContext.ActionDescriptor.DisplayName,
                })
            };
        }

        public void OnActionExecuting(ActionExecutingContext filterContext){}
    }
}
