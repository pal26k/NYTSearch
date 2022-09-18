using NYTimesSearch.Common.Models;

namespace NYTimesSearch.Client.Internal
{
    public interface IInternalHTTPClient
    {
        Task<AggregatedSearchModel> GetResultsAsync(string searchQuery);
    }
}
