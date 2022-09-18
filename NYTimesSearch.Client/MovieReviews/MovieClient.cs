using NYTimesSearch.Common;

namespace NYTimesSearch.Client.MovieReviews
{
    /// <summary>
    /// Proxy Class for MovieClient
    /// </summary>
    public class MovieClient : IMovieClient
    {
        MovieReviewConfiguration _movieConfig;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="movieConfig"></param>
        public MovieClient(MovieReviewConfiguration movieConfig)
        {
            _movieConfig= movieConfig;      
        }

        /// <summary>
        ///  Task to get Movie Review details with specific filter
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<string> GetMovieReviewsAsync(string searchQuery)
        {
            using (var client = new HttpClient())
            { 
                client.BaseAddress = new Uri(_movieConfig.BaseDomain + _movieConfig.MovieSuffixURL + "?api-key=" + _movieConfig.API_KEY_ID + "&query=" + searchQuery);
                var response = await client.GetAsync(client.BaseAddress);
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
