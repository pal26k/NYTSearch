using Microsoft.AspNetCore.Mvc;
using NYTimesSearch.Client.Archives;
using NYTimesSearch.Core.Providers;

namespace ArchiveAPI.Controllers
{

    /// <summary>
    /// Controller for working with archive services
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ArchiveController : ControllerBase
    {
        private readonly IExternalServicesProvider _provider;
        private readonly IArchiveClient _archiveClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="externalServiceProvider"></param>
        public ArchiveController(IExternalServicesProvider externalServiceProvider)
        {
            _provider = externalServiceProvider;
            _archiveClient = _provider.ArchiveClient;
        }

        /// <summary>
        /// API for Search Archive
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchArchiveAsync")]
        public async Task<string> SearchArchiveAsync(string searchQuery)
        {
            var result = await _archiveClient.GetArchiveAsync(searchQuery);
            return result;
        }
    }
}