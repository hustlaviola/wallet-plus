using WalletPlus.Core.Common.DTOs;

namespace WalletPlus.Core.Handlers
{
    public class BaseHandler
    {
        public ServiceResponse<T> HandleResponse<T>(T data, ResponseStatus responseStatus) where T : class
        {
            return new ServiceResponse<T>
            {
                Data = data,
                Status = responseStatus
            };
        }

        public BaseResponse HandleResponse(ResponseStatus responseStatus)
        {
            return new BaseResponse(responseStatus);
        }
    }
}