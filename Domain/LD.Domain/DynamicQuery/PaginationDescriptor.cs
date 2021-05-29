using System;
using System.Collections.Generic;
using System.Text;

namespace LD.Domain.DynamicQuery
{
    /// <summary>
    /// Pagination parameters.
    /// </summary>
    public class PaginationDescriptor
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public static readonly PaginationDescriptor NoPagination = new PaginationDescriptor
        {
            PageSize = int.MaxValue,
            PageIndex = 1
        };
    }
}
