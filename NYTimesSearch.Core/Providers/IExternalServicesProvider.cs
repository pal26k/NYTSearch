using NYTimesSearch.Client.Archives;
using NYTimesSearch.Client.Articles;
using NYTimesSearch.Client.Books;
using NYTimesSearch.Client.Internal;
using NYTimesSearch.Client.MovieReviews;

namespace NYTimesSearch.Core.Providers
{
    public interface IExternalServicesProvider
    {
        IArchiveClient ArchiveClient { get; }
        IArticleClient ArticleClient { get; }
        IBookClient BookClient { get; }
        IMovieClient MovieClient { get; }
        IInternalHTTPClient InternalHTTPClient { get; }


    }
}
