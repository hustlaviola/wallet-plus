using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WalletPlus.Core.Common.Constants;
using WalletPlus.Core.Common.DTOs;

namespace WalletPlus.API.Controllers
{
    [ApiController]
    [EnableCors(AppCorsPolicy.ALLOW)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BaseController : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        protected ActionResult ResolveActionResult(BaseResponse response)
        {
            ObjectResult result;
            switch (response.Status)
            {
                case ResponseStatus.OK:
                    result = Ok(response);
                    break;
                case ResponseStatus.CREATED:
                    result = StatusCode(StatusCodes.Status201Created, response);
                    break;
                case ResponseStatus.ACCEPTED:
                    result = StatusCode(StatusCodes.Status202Accepted, response);
                    break;
                case ResponseStatus.NO_CONTENT:
                    result = StatusCode(StatusCodes.Status204NoContent, response);
                    break;
                case ResponseStatus.BAD_REQUEST:
                    result = BadRequest(response);
                    break;
                case ResponseStatus.UNAUTHORIZED:
                    result = StatusCode(StatusCodes.Status401Unauthorized, response);
                    break;
                case ResponseStatus.FORBIDDEN:
                    result = StatusCode(StatusCodes.Status403Forbidden, response);
                    break;
                case ResponseStatus.CONFLICT:
                    result = StatusCode(StatusCodes.Status409Conflict, response);
                    break;
                case ResponseStatus.UNPROCESSABLE:
                    result = StatusCode(StatusCodes.Status422UnprocessableEntity, response);
                    break;
                default:
                    result = StatusCode(StatusCodes.Status500InternalServerError, response);
                    break;
            }

            return result;
        }
    }
}