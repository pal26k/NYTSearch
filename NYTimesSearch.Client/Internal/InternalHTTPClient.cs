using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NYTimesSearch.Common.Models;
using NYTimesSearch.Common.Models.ArticleModels;
using NYTimesSearch.Common.Models.MovieReviewModels;

namespace NYTimesSearch.Client.Internal
{
    /// <summary>
    /// Proxy Class for HTTP Client
    /// </summary>
    public class InternalHTTPClient : IInternalHTTPClient
    {
        private readonly IConfiguration _configuration;
        public InternalHTTPClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get response for a model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<T> GetData<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.Timeout = new TimeSpan(0, 5, 0);
                var response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                return default(T);
            }
        }
        

        /// <summary>
        /// Aggregate response of data from 4 services
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<AggregatedSearchModel> GetResultsAsync(string searchQuery)
        {
            
            try
            {
                AggregatedSearchModel aggregatedSearchModel = new AggregatedSearchModel();
                aggregatedSearchModel.ArticleModel = await GetData<Article>(_configuration.GetSection("ArticleServiceSearchEndpoint").Value +"?searchQuery=" + searchQuery);
                aggregatedSearchModel.ArchiveModel = await GetData<Archive>(_configuration.GetSection("ArchiveServiceSearchEndpoint").Value +"?searchQuery=" + searchQuery);
                aggregatedSearchModel.BookModel = await GetData<Book>(_configuration.GetSection("BookServiceSearchEndpoint").Value +"?searchQuery=" + searchQuery);
                aggregatedSearchModel.MovieReviewModel = await GetData<MovieReview>(_configuration.GetSection("MovieServiceSearchEndpoint").Value +"?searchQuery=" + searchQuery);
                return aggregatedSearchModel;

            }
            catch
            {
                throw ;
            }
        }
    }
}
