using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletPlus.Core.Common.DTOs;
using WalletPlus.Core.Handlers.Transactions.Commands.AddMoney;
using WalletPlus.Core.Handlers.Transactions.Commands.SendMoney;
using WalletPlus.Core.Handlers.Transactions.Queries.GetTransactions;

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
        [HttpPost("add_money", Name = nameof(AddMoney))]
        public async Task<IActionResult> AddMoney(AddMoneyCommand request)
        {
            var response = await Mediator.Send(request);

            return ResolveActionResult(response);
        }

        /// <summary>
        /// Send money endpoint
        /// </summary>
        /// <param name="request">Send money request</param>
        /// <returns>Transaction information</returns>
        [ProducesResponseType(typeof(ServiceResponse<TransactionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("send_money", Name = nameof(SendMoney))]
        public async Task<IActionResult> SendMoney(SendMoneyCommand request)
        {
            var response = await Mediator.Send(request);

            return ResolveActionResult(response);
        }

        /// <summary>
        /// Get transactions endpoint
        /// </summary>
        /// <param name="page">Page requested</param>
        /// <param name="pageSize">Size of page requested</param>
        /// <returns>Lst of transactions</returns>
        [ProducesResponseType(typeof(ServiceResponse<PaginatedResponse<TransactionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("", Name = nameof(GetTransactions))]
        public async Task<IActionResult> GetTransactions(int page, int pageSize)
        {
            var response = await Mediator.Send(new GetTransactionsQuery(page, pageSize));

            return ResolveActionResult(response);
        }
    }
}