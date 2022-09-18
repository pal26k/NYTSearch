using NYTimesSearch.Common.Models.ArticleModels;
using NYTimesSearch.Common.Models.MovieReviewModels;

namespace NYTimesSearch.Common.Models
{

    /// <summary>
    /// Aggregated Search Model
    /// </summary>
    public class AggregatedSearchModel
    {
        /// <summary>
        /// Article model
        /// </summary>
        public Article ArticleModel { get; set; }


        /// <summary>
        /// Archive Model
        /// </summary>
        public Archive ArchiveModel { get; set; }


        /// <summary>
        /// Book Model
        /// </summary>
        public Book BookModel { get; set; }

        /// <summary>
        /// Movie Review Model
        /// </summary>
        public MovieReview MovieReviewModel { get; set; }

    }
}
