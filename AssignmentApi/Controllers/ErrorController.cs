using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssignmentApi.Models;

namespace AssignmentApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public ResponseModel HandleError() 
        {
            var ex = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ResponseModel response = new ResponseModel(500)
            {
                isError = true,
                message = "Request failed..!!",
                responseException = ex.Error.Message,
                result = null,
            };

            return response;
        }
    }
}
