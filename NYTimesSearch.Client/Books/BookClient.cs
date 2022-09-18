using NYTimesSearch.Common;

namespace NYTimesSearch.Client.Books
{
    /// <summary>
    /// Proxy Class for BookClient
    /// </summary>
    public class BookClient : IBookClient
    {
        BookConfiguration _bookConfig;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookConfig"></param>
        public BookClient(BookConfiguration bookConfig)
        {
            _bookConfig = bookConfig;
        }

        /// <summary>
        /// Task to get book details by title with specific filter
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<string> GetBooksByTitleAsync(string searchQuery)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_bookConfig.BaseDomain + _bookConfig.BookSuffixURL + "?api-key=" + _bookConfig.API_KEY_ID + "&title=" + searchQuery);
                var response = await client.GetAsync(client.BaseAddress);
                return response.Content.ReadAsStringAsync().Result;
            }
        }


        /// <summary>
        /// Task to get book details by author with specific filter
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<string> GetBooksByAuthorAsync(string searchQuery)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_bookConfig.BaseDomain + _bookConfig.BookSuffixURL + "?api-key=" + _bookConfig.API_KEY_ID + "&author=" + searchQuery);
                var response = await client.GetAsync(client.BaseAddress);
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// Task to get book details by ISBN with specific filter
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<string> GetBooksByISBNAsync(string searchQuery)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_bookConfig.BaseDomain + _bookConfig.BookSuffixURL + "?api-key=" + _bookConfig.API_KEY_ID + "&isbn=" + searchQuery);
                var response = await client.GetAsync(client.BaseAddress);
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
