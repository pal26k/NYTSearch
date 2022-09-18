using NYTimesSearch.Client.Internal;
using NYTimesSearch.Common.Models;
using NYTimesSearch.Core.Providers;
using System;
using System.Threading.Tasks;

namespace NYTimesSearch.Core.Repository.Implementation
{
    /// <summary>
    /// Class for Search Reposiory
    /// </summary>
    public class SearchServiceRepository : ISearchServiceRepository
    {

        private readonly IInternalHTTPClient _internalClient;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="provider"></param>
        /// <exception cref="ArgumentException"></exception>
        public SearchServiceRepository(IExternalServicesProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentException("External service provider is not available.");
            }

            _internalClient = provider.InternalHTTPClient;
        }

        /// <summary>
        /// Method for getting results for AggregatedSearchModel
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<AggregatedSearchModel> GetResults(string searchQuery)
        {

            var result = await _internalClient.GetResultsAsync(searchQuery);
            return result;
        }


        }
}
