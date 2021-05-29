using System;
using System.Collections.Generic;
using System.Text;

namespace LD.Domain.DynamicQuery
{
    /// <summary>
    /// Data descriptor for filtering, ordering, paginating the files
    /// AKJ.
    /// </summary>
    public class DataDescriptor
    {
        public OrderDescriptor Order { get; set; }
        public FilterDescription[] Filter { get; set; }
        public PaginationDescriptor Pagination { get; set; }
    }
}
