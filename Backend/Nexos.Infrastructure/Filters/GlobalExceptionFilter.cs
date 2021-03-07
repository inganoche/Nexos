using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nexos.Core.Exceptions;
using System.Net;

namespace Nexos.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(GlobalException))
            {
                var exception = (GlobalException)context.Exception;
                var valildation = new { Status = 400 , Tilte ="Bad Request", Message= exception.Message  };
                var json = new { error = new[] { valildation } };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
