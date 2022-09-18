using Microsoft.AspNetCore.Mvc;
using NYTimesSearch.Client.Books;
using NYTimesSearch.Core.Providers;

namespace BooksAPI.Controllers
{

    /// <summary>
    /// Controller for working with book services
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
      
        private readonly IExternalServicesProvider _provider;
        private readonly IBookClient _bookClient;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="externalServiceProvider"></param>
        public BookController( IExternalServicesProvider externalServiceProvider)
        {
            _provider = externalServiceProvider;
            _bookClient = _provider.BookClient;
        }

        /// <summary>
        /// API for Search book by title
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchByTitleAsync")]
        public async Task<string> SearchByTitleAsync(string searchQuery)
        {
            var result = await _bookClient.GetBooksByTitleAsync(searchQuery);
            return result;
        }

        /// <summary>
        ///  API for Search book by author
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchByAuthorAsync")]
        public async Task<string> SearchByAuthorAsync(string searchQuery)
        {
            var result = await _bookClient.GetBooksByAuthorAsync(searchQuery);
            return result;
        }


        /// <summary>
        /// API for Search book by ISBN
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchByISBNAsync")]
        public async Task<string> SearchByISBNAsync(string searchQuery)
        {
            var result = await _bookClient.GetBooksByISBNAsync(searchQuery);
            return result;
        }
    }
}