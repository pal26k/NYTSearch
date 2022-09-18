using Microsoft.AspNetCore.Mvc;
using NYTimesSearch.Client.Articles;
using NYTimesSearch.Core.Providers;

namespace ArticleAPI.Controllers
{
    /// <summary>
    /// Controller for working with article services
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IExternalServicesProvider _provider;
        private readonly IArticleClient _articleClient;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="externalServiceProvider"></param>
        public ArticleController(ILogger<ArticleController> logger, IExternalServicesProvider externalServiceProvider)
        {
            _logger = logger;
            _provider = externalServiceProvider;
            _articleClient = _provider.ArticleClient;
        }

        /// <summary>
        /// API for Search Article
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchArticleAsync")]
        public async Task<string> SearchArticleAsync(string searchQuery)
        {
            var result = await _articleClient.GetArticlesAsync(searchQuery);
            return result;
        }
    }
}