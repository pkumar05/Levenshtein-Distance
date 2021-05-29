using System;
using System.Collections.Generic;
using System.Text;

namespace LD.Domain.DynamicQuery
{
    /// <summary>
    /// An object that represent an order by description.
    /// </summary>
    public class OrderDescriptor
    {
        public string OrderBy { get; set; }
        public string OrderType { get; set; }
    }
}
