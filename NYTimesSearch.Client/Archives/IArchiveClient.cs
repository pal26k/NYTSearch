namespace NYTimesSearch.Client.Archives
{
    /// <summary>
    /// Interface for ArchiveClient
    /// </summary>
    public interface IArchiveClient
    {
        /// <summary>
        /// Task of Get Archive with filter
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<string> GetArchiveAsync(string searchQuery);

    }
}
