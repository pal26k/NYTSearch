using NYTimesSearch.Common;

namespace NYTimesSearch.Client.Articles
{
    /// <summary>
    /// Proxy Class for Article Client
    /// </summary>
    public class ArticleClient:IArticleClient
    {
        ArticleConfiguration _articleConfig;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="articleConfig"></param>
        public ArticleClient(ArticleConfiguration articleConfig)
        {
            _articleConfig = articleConfig;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<string> GetArticlesAsync(string searchQuery)
        {
           using(var client = new HttpClient())
            {

                client.BaseAddress = new Uri(_articleConfig.BaseDomain + _articleConfig.ArticleSuffixURL+ "?api-key="+_articleConfig.API_KEY_ID+"&query="+searchQuery);                   
                var response = await client.GetAsync(client.BaseAddress);
                return response.Content.ReadAsStringAsync().Result;
            }                  


        }
    }
}
