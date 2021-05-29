using System;
using System.Collections.Generic;
using System.Text;

namespace LD.Domain.DynamicQuery
{
    /// <summary>
    /// An object that represent a filter description
    /// </summary>
    public class FilterDescription
    {
        public string FilterBy { get; set; }
        public string FilterType { get; set; }
        public string Value { get; set; }
    }
}
