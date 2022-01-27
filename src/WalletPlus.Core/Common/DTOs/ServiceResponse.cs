namespace WalletPlus.Core.Common.DTOs
{
    public class ServiceResponse<T> : BaseResponse where T : class
    {
        public T Data { get; set; }
        public ServiceResponse()
        {
            Status = base.Status;
        }

        public ServiceResponse(ResponseStatus status) : base(status)
        {
            Status = ResponseStatus.OK;
        }
    }
}
