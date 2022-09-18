using NYTimesSearch.Common.Models;
using System.Threading.Tasks;

namespace NYTimesSearch.Core.Repository
{
    /// <summary>
    /// Interface for Search Reposiory
    /// </summary>
    public interface ISearchServiceRepository
    {

        /// <summary>
        /// Method for getting results for AggregatedSearchModel
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<AggregatedSearchModel> GetResults(string searchQuery);
    }
}
