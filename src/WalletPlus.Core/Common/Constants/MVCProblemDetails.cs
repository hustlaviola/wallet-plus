namespace WalletPlus.Core.Common.Constants
{
    public class MVCProblemDetails
    {
        public const string VALIDATION_TYPE = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
        public const string INVALID_QR_TITLE = "Invalid QR data";
        public const string NOT_FOUND_TITLE = "The specified resource was not found";
        public const string NOT_FOUND_TYPE = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
        public const string CONFLICT_TITLE = "Conflict";
        public const string CONFLICT_TYPE = "https://tools.ietf.org/html/rfc7231#section-6.5.8";
        public const string UNPROCESSABLE_TITLE = "Unprocessable Entity";
        public const string UNPROCESSABLE_TYPE = "https://tools.ietf.org/html/rfc7231#section-6.5.14";
        public const string UNAUTHORIZED_TITLE = "Unauthorized";
        public const string UNAUTHORIZED_TYPE = "https://tools.ietf.org/html/rfc7235#section-3.1";
        public const string FORBIDDEN_TITLE = "Forbidden";
        public const string FORBIDDEN_TYPE = "https://tools.ietf.org/html/rfc7231#section-6.5.3";
        public const string BAD_GATEWAY_TITLE = "Request failed from external provider";
        public const string BAD_GATEWAY_TYPE = "https://tools.ietf.org/html/rfc7231#section-6.6.3";
        public const string UNKNOWN_TITLE = "An error occurred";
        public const string UNKNOWN_TYPE = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
    }
}