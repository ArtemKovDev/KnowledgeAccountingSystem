using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Filters
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionMessage = context.Exception.Message;

            context.Result = new ContentResult
            {
                Content = exceptionMessage,
                StatusCode = 400
            };
            context.ExceptionHandled = true;
        }
    }
}
