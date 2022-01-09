using System.Net.Http;
using Web_API.Models;

namespace Web_API.Bing_API
{
    public class WebSearchResultApi
    {

        string subscriptionKey = "e83f31beff754d8d8d48033fc9122431";
        string customConfigId = "e843d9df-e92d-467d-84e0-2994d9e40364";
        string apiUrl = "https://api.cognitive.microsoft.com/bingcustomsearch/v7.0/search?";




        public WebSearchResponse GetQueryResults(string searchTerm)
        {
            var completeUrl = apiUrl + "q=" + searchTerm + "&" + "customconfig=" + customConfigId;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var httpResponseMessage = client.GetAsync(completeUrl).Result;
            var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            BingCustomSearchResponse response = JsonConvert.DeserializeObject<BingCustomSearchResponse>(responseContent);

        }
    }
}
