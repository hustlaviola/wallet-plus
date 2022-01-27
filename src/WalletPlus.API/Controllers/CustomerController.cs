using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletPlus.Core.Common.DTOs;
using WalletPlus.Core.Handlers.Customers.AddCustomer;

namespace WalletPlus.API.Controllers
{
    [Route("api/v1/customers")]
    public class CustomerController : BaseController
    {
        /// <summary>
        /// Add customer endpoint
        /// </summary>
        /// <param name="request">Customer creation request</param>
        /// <returns>Customer information</returns>
        [ProducesResponseType(typeof(ServiceResponse<AddCustomerResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("", Name = nameof(AddCustomer))]
        public async Task<IActionResult> AddCustomer(AddCustomerCommand request)
        {
            var response = await Mediator.Send(request);
            return ResolveActionResult(response);
        }
    }
}