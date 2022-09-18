namespace NYTimesSearch.Client.Books
{    
    /// <summary>
    /// Interface fop BookClient
    /// </summary>
    public interface IBookClient
    {
        /// <summary>
        /// GetBooksAsync Method to get book details with specific title
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<string> GetBooksByTitleAsync(string searchQuery);

        /// <summary>
        /// GetBooksByTitleAsync Method to get book details with specific author 
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<string> GetBooksByAuthorAsync(string searchQuery);

        /// <summary>
        /// GetBooksByISBNAsync Method to get book details with specific ISBN 
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<string> GetBooksByISBNAsync(string searchQuery);
    }
}
