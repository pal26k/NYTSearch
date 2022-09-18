using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NYTimesSearch.Service.Common
{
    /// <summary>
    /// Base controller for common functionlity
    /// </summary>
    public class BaseServiceController : ControllerBase
    {
        private readonly ILogger<BaseServiceController> _logger;
        public BaseServiceController(ILogger<BaseServiceController> logger)
        {
            _logger = logger;
                
        }

        /// <summary>
        /// Gets Http Status Code From Exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        [NonAction]
        public HttpStatusCode GetHttpStatusCodeFromException(Exception ex)
        {
            if (ex is UnauthorizedAccessException)
            {
                return HttpStatusCode.Unauthorized;
            }
           
            else
            {
                return HttpStatusCode.InternalServerError;
            }

        }


    }
}
