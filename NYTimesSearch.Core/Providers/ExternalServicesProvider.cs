using Microsoft.Extensions.Configuration;
using NYTimesSearch.Client.Archives;
using NYTimesSearch.Client.Articles;
using NYTimesSearch.Client.Books;
using NYTimesSearch.Client.Internal;
using NYTimesSearch.Client.MovieReviews;
using NYTimesSearch.Common;

namespace NYTimesSearch.Core.Providers
{
    public class ExternalServicesProvider : IExternalServicesProvider
    {
        #region Private Members


        private IArchiveClient archiveClient = null;


        private IArticleClient articleClient = null;


        private IBookClient bookClient = null;


        private IMovieClient movieClient = null;

        private IInternalHTTPClient internalHTTPClient = null;

        #endregion Private Members

        public IArchiveClient ArchiveClient => archiveClient;

        public IArticleClient ArticleClient => articleClient;

        public IBookClient BookClient => bookClient;

        public IMovieClient MovieClient => movieClient;
        public IInternalHTTPClient InternalHTTPClient => internalHTTPClient;


        public ExternalServicesProvider(IConfiguration configuration)
        {

            try
               
            {
                var APIKeyId = configuration.GetSection("API_KEY_ID").Value;
                var baseUrl = configuration.GetSection("BaseDomain").Value;
                ArticleConfiguration artAconfig = new ArticleConfiguration()
                {
                    API_KEY_ID = APIKeyId,
                    ArticleSuffixURL = configuration.GetSection("ArticleSuffixURL").Value ,
                    BaseDomain = baseUrl
                };
                articleClient = new ArticleClient(artAconfig);

                ArchiveConfiguration archiveConfig = new ArchiveConfiguration()
                {
                    API_KEY_ID = APIKeyId,
                    ArchiveSuffixURL = configuration.GetSection("ArchiveSuffixURL").Value,
                    BaseDomain = baseUrl
                };
                archiveClient = new ArchiveClient(archiveConfig);

                BookConfiguration bookConfig = new BookConfiguration()
                {
                    API_KEY_ID = APIKeyId,
                    BookSuffixURL = configuration.GetSection("BookSuffixURL").Value,
                    BaseDomain = baseUrl
                };
                bookClient = new BookClient(bookConfig);

                MovieReviewConfiguration movieConfig = new MovieReviewConfiguration()
                {
                    API_KEY_ID = APIKeyId,
                    MovieSuffixURL = configuration.GetSection("MovieSuffixURL").Value,
                    BaseDomain = baseUrl
                };
                movieClient = new MovieClient(movieConfig);

                internalHTTPClient = new InternalHTTPClient(configuration);
            }
            catch { }

        }
       
    }
}
