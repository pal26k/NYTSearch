using NYTimesSearch.Common;
namespace NYTimesSearch.Client.Archives
{
    /// <summary>
    /// Proxy Class for Archive Client
    /// </summary>
    public class ArchiveClient:IArchiveClient
    {

        ArchiveConfiguration _archiveConfig;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="archiveConfig"></param>
        public ArchiveClient(ArchiveConfiguration archiveConfig)
        {
            _archiveConfig = archiveConfig;
        }

        /// <summary>
        /// Task of Get Archive with filter
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<string> GetArchiveAsync(string searchQuery)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(_archiveConfig.BaseDomain + _archiveConfig.ArchiveSuffixURL + "?api-key=" + _archiveConfig.API_KEY_ID + "&query=" + searchQuery);
                var response = await client.GetAsync(client.BaseAddress);
                return response.Content.ReadAsStringAsync().Result;
            }


        }
    }
}
