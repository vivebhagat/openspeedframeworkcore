using Common.Exceptions;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace SpeedFramework.APILib.Models.Attributs
{
    public class CustomErrorFilter : IExceptionFilter
    {
        private readonly ILogger<CustomErrorFilter> _logger;
        public CustomErrorFilter(ILogger<CustomErrorFilter> logger)
        {
            this._logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            
            _logger.LogInformation("This is a MEL warning on the privacy page");
            if (context.Exception is DataProcessingException)
            {
//                context.Response = new HttpResponseMessage()
//                {
//                    Content = new StringContent(JsonConvert.SerializeObject(new ServiceResult<object> { ErrorMessage = context.Exception.Message, Result = null, IsError = true }), System.Text.Encoding.UTF8, "application/json"),
 //                   StatusCode = HttpStatusCode.InternalServerError
 //               };
            }
          //  base.OnException(context);
        }        
    }   
}