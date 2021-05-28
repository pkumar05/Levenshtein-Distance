using System;
using System.Collections.Generic;
using System.Text;

namespace LD.Domain.DTO
{
    public class AddLevenshteinDistanceBetweenTwoStrings
    {
        public string Source { get; set; }
        public string Target { get; set; }

        public int LevenshteinDistance { get; set; }

    }
}
