namespace WalletPlus.Core.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
    }
}