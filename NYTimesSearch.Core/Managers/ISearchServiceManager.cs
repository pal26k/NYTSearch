using NYTimesSearch.Common.Models;
using System.Threading.Tasks;

namespace NYTimesSearch.Core.Managers
{
    public interface ISearchServiceManager
    {
        Task<AggregatedSearchModel> Search(string searchQuery);
    }
}
