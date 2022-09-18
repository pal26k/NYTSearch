using Microsoft.AspNetCore.Mvc;
using NYTimesSearch.Core.Managers;
using NYTimesSearch.Service.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NYTSearchAssignment.Controllers
{
    /// <summary>
    /// Entry point of Aggreagate Search Service
    /// </summary>
    [ApiController]
    [Route("[controller]")]    
    public class AggreagateSearcherController : BaseServiceController
    {
        #region private Members  
        private readonly ILogger<AggreagateSearcherController> _logger;
        private readonly ISearchServiceManager _searchServiceManager;
        #endregion

        /// <summary>
        /// AggreagateSearcherController Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="searchServiceManager"></param>
        public AggreagateSearcherController(ILogger<AggreagateSearcherController> logger, ISearchServiceManager searchServiceManager):base(logger)
        {         
            _logger = logger;
            _searchServiceManager = searchServiceManager;
        }

       
        /// <summary>
        /// Search API to search for aggregated results
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchAsync")]
        public async Task<IActionResult> SearchAsync(string searchQuery)
        {
            try
            {
                var result = await _searchServiceManager.Search(searchQuery);
                _logger.LogInformation("Search Results received successfully!");
                return Ok(result);
            }
            catch(Exception ex)
            {
                 string message = "An unexpected error occurred while fetching the search results";
                _logger.LogError(ex,message);
                return new ContentResult
                {
                    Content = message,
                    StatusCode = (int)GetHttpStatusCodeFromException(ex)
                };
            }
            
        }
    }
}
