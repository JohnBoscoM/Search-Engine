using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{

    public class WebSearchResponse 
    {
        public string _type { get; set; }
        public WebPages webPages { get; set; }
    }
    public class WebPages
    {
        public string webSearchUrl { get; set; }
        public int totalEstimatedMatches { get; set; }
        public WebPage[] value { get; set; }
    }

    public class WebPage
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string DisplayUrl { get; set; }
        public string Snippet { get; set; }
        public DateTime dateLastCrawled { get; set; }
        public string cachedPageUrl { get; set; }
    }
}
