using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace CMCapital.Domain.Infrastructure
{
    public class GlobalExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {            
            filterContext.Result = new JsonResult("An unexpected error occurred while using this method. Please contact customer support.")
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };            
        }
    }
}

