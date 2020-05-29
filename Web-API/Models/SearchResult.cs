using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class SearchResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Snippet { get; set; }
    }
}
