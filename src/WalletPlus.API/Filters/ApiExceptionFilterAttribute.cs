using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using WalletPlus.Core.Common.Constants;
using WalletPlus.Core.Common.Exceptions;

namespace WalletPlus.API.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly ILogger<ApiExceptionFilterAttribute> _logger;
        public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
        {
            _logger = logger;
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(ConflictException), HandleConflictException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(BadGatewayException), HandleBadGatewayException}
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = MVCProblemDetails.VALIDATION_TYPE
            };

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            var exception = context.Exception as ValidationException;

            var details = new ValidationProblemDetails(exception.Errors)
            {
                Type = MVCProblemDetails.VALIDATION_TYPE,
                Detail = exception.Message
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            // var exception = context.Exception as NotFoundException;

            var details = new ProblemDetails()
            {
                Type = MVCProblemDetails.NOT_FOUND_TYPE,
                Title = MVCProblemDetails.NOT_FOUND_TITLE,
                Status = StatusCodes.Status404NotFound,
                Detail = context.Exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleConflictException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            // var exception = context.Exception as ConflictException;

            var details = new ProblemDetails()
            {
                Type = MVCProblemDetails.CONFLICT_TYPE,
                Title = MVCProblemDetails.CONFLICT_TITLE,
                Status = StatusCodes.Status409Conflict,
                Detail = context.Exception.Message
            };

            context.Result = new ConflictObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            var details = new ProblemDetails
            {
                Type = MVCProblemDetails.UNAUTHORIZED_TYPE,
                Title = MVCProblemDetails.UNAUTHORIZED_TITLE,
                Status = StatusCodes.Status401Unauthorized,
                Detail = context.Exception.Message
            };

            context.Result = new UnauthorizedObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleForbiddenAccessException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            var details = new ProblemDetails
            {
                Type = MVCProblemDetails.FORBIDDEN_TYPE,
                Title = MVCProblemDetails.FORBIDDEN_TITLE,
                Status = StatusCodes.Status403Forbidden,
                Detail = context.Exception.Message
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status403Forbidden
            };

            context.ExceptionHandled = true;
        }

        private void HandleBadGatewayException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            // var exception = context.Exception as BadGatewayException;
            var details = new ProblemDetails
            {
                Type = MVCProblemDetails.BAD_GATEWAY_TYPE,
                Title = MVCProblemDetails.BAD_GATEWAY_TITLE,
                Status = StatusCodes.Status502BadGateway,
                Detail = context.Exception.Message
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status502BadGateway
            };

            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            var details = new ProblemDetails
            {
                Type = MVCProblemDetails.UNKNOWN_TYPE,
                Title = MVCProblemDetails.UNKNOWN_TITLE,
                Status = StatusCodes.Status500InternalServerError,
                Detail = "An error occurred while processing your request"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
