using Microsoft.AspNetCore.Mvc;
using NYTimesSearch.Client.MovieReviews;
using NYTimesSearch.Core.Providers;

namespace MovieReviewAPI.Controllers
{

    /// <summary>
    /// Controller for working with movie review services
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MovieReviewController : ControllerBase
    {
        private readonly ILogger<MovieReviewController> _logger;
        private readonly IExternalServicesProvider _provider;
        private readonly IMovieClient _movieClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="externalServiceProvider"></param>
        public MovieReviewController(ILogger<MovieReviewController> logger, IExternalServicesProvider externalServiceProvider)
        {
            _logger = logger;
            _provider = externalServiceProvider;
            _movieClient = _provider.MovieClient;
        }

        /// <summary>
        ///  API for Search movie reviews 
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchMovieReviewAsync")]
        public async Task<string> SearchMovieReviewAsync(string searchQuery)
        {
            var result = await _movieClient.GetMovieReviewsAsync(searchQuery);
            return result;
        }
    }
}