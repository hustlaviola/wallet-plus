using System.Collections.Generic;

namespace WalletPlus.Core.Common.DTOs
{
    public class PaginatedResponse<T>
    {
        public List<T> ItemsList { get; set; }
        public long TotalItems { get; set; }
        public int PerPage { get; set; }
        public int? CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int? PagingCounter { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public int? PreviousPage { get; set; }
        public int? NextPage { get; set; }
    }
}