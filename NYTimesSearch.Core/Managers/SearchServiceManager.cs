using NYTimesSearch.Common.Models;
using NYTimesSearch.Core.Repository;
using System;
using System.Threading.Tasks;

namespace NYTimesSearch.Core.Managers
{
    public class SearchServiceManager : ISearchServiceManager
    {
        private ISearchServiceRepository _searchServiceRepository;
        public SearchServiceManager(ISearchServiceRepository searchServiceRepository)
        {
            _searchServiceRepository = searchServiceRepository;
        }
        public async Task<AggregatedSearchModel> Search(string searchQuery)
        {
            try
            {
                return await _searchServiceRepository.GetResults(searchQuery);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
