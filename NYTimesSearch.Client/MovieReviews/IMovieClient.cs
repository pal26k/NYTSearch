namespace NYTimesSearch.Client.MovieReviews
{   
    /// <summary>
    /// Interface for MovieClient
    /// </summary>
    public interface IMovieClient
    {
        /// <summary>
        /// Method to get Movie Review details with specific filter
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<string> GetMovieReviewsAsync(string searchQuery);
    }
}
