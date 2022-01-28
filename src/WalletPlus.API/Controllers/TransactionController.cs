using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletPlus.Core.Common.DTOs;
using WalletPlus.Core.Handlers.Transactions.AddMoney;

namespace WalletPlus.API.Controllers
{
    [Route("api/v1/transactions")]
    public class TransactionController : BaseController
    {
        /// <summary>
        /// Add money endpoint
        /// </summary>
        /// <param name="request">Add money request</param>
        /// <returns>Wallet information</returns>
        [ProducesResponseType(typeof(ServiceResponse<WalletDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("", Name = nameof(AddMoney))]
        public async Task<IActionResult> AddMoney(AddMoneyCommand request)
        {
            var response = await Mediator.Send(request);
            return ResolveActionResult(response);
        }
    }
}