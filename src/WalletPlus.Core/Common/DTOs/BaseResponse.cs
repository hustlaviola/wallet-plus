namespace WalletPlus.Core.Common.DTOs
{
    public class BaseResponse
    {
        public ResponseStatus Status { get; set; }

        public BaseResponse()
        {
            Status = ResponseStatus.OK;
        }

        public BaseResponse(ResponseStatus status)
        {
            Status = status;
        }
    }

    public enum ResponseStatus
    {
        OK = 200,
        CREATED = 201,
        ACCEPTED = 202,
        NO_CONTENT = 204,
        BAD_REQUEST = 400,
        UNAUTHORIZED = 401,
        FORBIDDEN = 403,
        NOT_FOUND = 404,
        REQUEST_TIMEOUT = 408,
        CONFLICT = 409,
        UNPROCESSABLE = 422,
        SERVER_ERROR = 500
    }
}