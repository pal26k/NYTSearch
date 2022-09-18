namespace NYTimesSearch.Client.Articles
{
    /// <summary>
    /// Interface for ArticleClient
    /// </summary>
    public interface IArticleClient
    {
        /// <summary>
        /// GetArticlesAsync Method to get article details with specific filter
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<string> GetArticlesAsync(string searchQuery);
    }
}
