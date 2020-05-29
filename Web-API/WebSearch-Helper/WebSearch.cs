using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Web_API.Interfaces;
using Web_API.Models;


namespace Web_API.WebSearch_Helper
{
    public class WebSearch : IWebSearch
    {
        const string accessKey = "d1690b5b185643a990634411982ec876";
        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";
        const string searchTerm = "2pac";

        // Returns search results with headers.
        struct JSONSearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }
        /// <summary>
        /// Makes a request to the Bing Web Search API and returns data as a SearchResult.
        /// </summary>
        public IList<SearchResult> Search(string searchQuery)
        {
            // Construct the search request URI.
            var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery);

            // Perform request and get a response.
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // Create a result object.
            var jsonSearchResult = new JSONSearchResult()
            {
                jsonResult = json,
                relevantHeaders = new Dictionary<String, String>()
            };

            // Extract Bing HTTP headers.
            foreach (String header in response.Headers)
            {
                if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                    jsonSearchResult.relevantHeaders[header] = response.Headers[header];
            }

            var searchResults = GetSearchResults(jsonSearchResult.jsonResult);

            return searchResults;
        }
    
        public IList<SearchResult> GetSearchResults(string jsonResult)
        {
            var parsed = JObject.Parse(jsonResult);
            IList<JToken> sResult = parsed["webPages"]["value"].Children().ToList();

            IList<SearchResult> searchResult = new List<SearchResult>();
            foreach (var res in sResult)
            {
                SearchResult link = res.ToObject<SearchResult>();

                searchResult.Add(link);
            }
            return searchResult;
        }
    }
}
