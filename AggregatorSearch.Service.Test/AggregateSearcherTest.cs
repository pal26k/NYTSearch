using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NYTimesSearch.Client.Internal;
using NYTimesSearch.Common.Models;
using NYTimesSearch.Common.Models.ArticleModels;
using NYTimesSearch.Common.Models.MovieReviewModels;
using NYTimesSearch.Core.Managers;
using NYTimesSearch.Core.Providers;
using NYTimesSearch.Core.Repository.Implementation;
using NYTSearchAssignment.Controllers;
using System.Net;
using Assert = NUnit.Framework.Assert;

namespace AggregatorSearch.Service.Test
{

    [TestFixture]
    [Category("TestSuite.Unit")]
    public class AggregateSearcherTest
    {

        private readonly Mock<ILogger<AggreagateSearcherController>> mockLogger = new Mock<ILogger<AggreagateSearcherController>>();
        private readonly Mock<IInternalHTTPClient> mockInternalHTTPClient = new Mock<IInternalHTTPClient>();
        private readonly Mock<IExternalServicesProvider> mockExternalServicesProvider = new Mock<IExternalServicesProvider>();
        AggreagateSearcherController aggreagateSearcherController;
        AggregatedSearchModel aggregatedSearchModel;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
             aggregatedSearchModel = new AggregatedSearchModel()
            {
                ArchiveModel = new Archive() { },
                ArticleModel = new Article() { },
                BookModel = new Book() { },
                MovieReviewModel = new MovieReview() { }
            };

          

        }

        [SetUp]
        public void BaseSetup()
        {
            //SearchServiceRepository searchServiceRepository = new SearchServiceRepository(mockExternalServicesProvider.Object);
            //SearchServiceManager searchServiceManager = new SearchServiceManager(searchServiceRepository);
            //aggreagateSearcherController = new AggreagateSearcherController(mockLogger.Object, searchServiceManager);
        }

        [TearDown]
        public void BaseTearDown()
        {
            aggreagateSearcherController = null;
        }

        [Test]
        public async Task SearchQueryResults_ShouldReturnOk()
        {
            mockInternalHTTPClient.Setup(o => o.GetResultsAsync(It.IsAny<string>())).Returns(Task.FromResult(aggregatedSearchModel));

            mockExternalServicesProvider.Setup(o => o.InternalHTTPClient).Returns(mockInternalHTTPClient.Object);
            SearchServiceRepository searchServiceRepository = new SearchServiceRepository(mockExternalServicesProvider.Object);
            SearchServiceManager searchServiceManager = new SearchServiceManager(searchServiceRepository);
            aggreagateSearcherController = new AggreagateSearcherController(mockLogger.Object, searchServiceManager);
            var result = await aggreagateSearcherController.SearchAsync("test");
            
            var okResult = result as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task SearchQueryResults_ShouldReturnUnAuthorized()
        {
            mockInternalHTTPClient.Setup(o => o.GetResultsAsync(It.IsAny<string>())).ThrowsAsync(new Exception("An exception Occurred"));
            mockExternalServicesProvider.Setup(o => o.InternalHTTPClient).Returns(mockInternalHTTPClient.Object);
            SearchServiceRepository searchServiceRepository = new SearchServiceRepository(mockExternalServicesProvider.Object);
            SearchServiceManager searchServiceManager = new SearchServiceManager(searchServiceRepository);
            aggreagateSearcherController = new AggreagateSearcherController(mockLogger.Object, searchServiceManager);
            var result = await aggreagateSearcherController.SearchAsync("test") as ContentResult;

            Assert.AreEqual((HttpStatusCode)result.StatusCode, HttpStatusCode.InternalServerError);

        }

    }
}
