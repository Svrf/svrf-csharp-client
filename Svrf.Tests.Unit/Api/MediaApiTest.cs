using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Svrf.Api;
using Svrf.Exceptions;
using Svrf.Http;
using Svrf.Models.Http;
using Svrf.Models.Media;
using Svrf.Tests.Unit.Mocks;

namespace Svrf.Tests.Unit.Api
{
    [TestFixture]
    public class MediaApiTest
    {
        private readonly Mock<IHttpClient> _mockHttpClient = new Mock<IHttpClient>();

        private MediaApi _mediaApi;

        [SetUp]
        public virtual void Init()
        {
            _mediaApi = new MediaApi(_mockHttpClient.Object);
        }

        [TearDown]
        public virtual void Cleanup()
        {
            _mockHttpClient.Reset();
        }

        [TestFixture]
        public class GetByIdTest : MediaApiTest
        {
            public const int Id = 42;

            [SetUp]
            public override void Init()
            {
                base.Init();
                _mockHttpClient
                    .Setup(hc => hc.GetAsync<SingleMediaResponse>(It.IsAny<string>(), It.IsAny<IDictionary<string, object>>()))
                    .ReturnsAsync(ResponseMocks.SingleMediaResponse);
            }

            [TearDown]
            public override void Cleanup()
            {
                base.Cleanup();
                _mockHttpClient.Reset();
            }

            [Test]
            public async Task GetById_WithCorrectId_ReturnsAsyncMediaResponse()
            {
                var response = await _mediaApi.GetByIdAsync(Id);

                Assert.AreEqual(ResponseMocks.SingleMediaResponse, response);
            }

            [Test]
            public async Task GetById_WithCorrectId_InvokesHttpClientGet()
            {
                await _mediaApi.GetByIdAsync(Id);

                _mockHttpClient.Verify(hc => hc.GetAsync<SingleMediaResponse>("vr/1", null), Times.Once);
            }

            [Test]
            public void GetById_WithIncorrectId_ThrowsMediaNotFoundException()
            {
                var exception = new HttpException(string.Empty, HttpStatusCode.NotFound);
                _mockHttpClient
                    .Setup(hc => hc.GetAsync<SingleMediaResponse>(It.IsAny<string>(), It.IsAny<IDictionary<string, object>>()))
                    .Throws(exception);

                Assert.ThrowsAsync<MediaNotFoundException>(async () => await _mediaApi.GetByIdAsync(Id));
            }
        }

        [TestFixture]
        public class GetTrendingTest : MediaApiTest
        {
            [SetUp]
            public override void Init()
            {
                base.Init();
                _mockHttpClient
                    .Setup(hc => hc.GetAsync<MultipleMediaResponse>(It.IsAny<string>(), It.IsAny<IDictionary<string, object>>()))
                    .ReturnsAsync(ResponseMocks.MultipleMediaResponse);
            }

            [Test]
            public async Task GetTrending_WithoutParams_InvokesHttpClientGet()
            {
                await _mediaApi.GetTrendingAsync();

                _mockHttpClient.Verify(hc => hc.GetAsync<MultipleMediaResponse>("vr/trending", It.IsAny<IDictionary<string, object>>()), Times.Once);
            }

            [Test]
            public async Task GetTrending_WithoutParams_ReturnsAsyncMultipleMediaResponse()
            {
                var result = await _mediaApi.GetTrendingAsync();

                Assert.AreEqual(ResponseMocks.MultipleMediaResponse, result);
            }

            [Test]
            public async Task GetTrending_WithParams_ReturnsAsyncMultipleMediaResponse()
            {
                var result = await _mediaApi.GetTrendingAsync(RequestMocks.RequestParams);

                Assert.AreEqual(ResponseMocks.MultipleMediaResponse, result);
            }

            [Test]
            public async Task GetTrending_WithParams_InvokesHttpClientGet()
            {
                await _mediaApi.GetTrendingAsync(RequestMocks.RequestParams);

                _mockHttpClient.Verify(hc => hc.GetAsync<MultipleMediaResponse>(
                    "vr/trending",
                    It.IsAny<IDictionary<string, object>>() // TODO: compare equality
                ), Times.Once);
            }
        }

        [TestFixture]
        public class SearchTest : MediaApiTest
        {
            private const string Query = "query";

            [SetUp]
            public override void Init()
            {
                base.Init();
                _mockHttpClient
                    .Setup(hc => hc.GetAsync<MultipleMediaResponse>(It.IsAny<string>(), It.IsAny<IDictionary<string, object>>()))
                    .ReturnsAsync(ResponseMocks.MultipleMediaResponse);
            }

            [Test]
            public async Task Search_WithQuery_InvokesHttpClientGet()
            {
                await _mediaApi.SearchAsync(Query);

                _mockHttpClient.Verify(hc => hc.GetAsync<MultipleMediaResponse>("vr/search", new Dictionary<string, object>{ {"q", Query} }), Times.Once);
            }

            [Test]
            public async Task Search_WithQuery_ReturnsAsyncMultipleMediaResponse()
            {
                var result = await _mediaApi.SearchAsync(Query);

                Assert.AreEqual(ResponseMocks.MultipleMediaResponse, result);
            }

            [Test]
            public async Task Search_WithQueryAndParams_InvokesHttpClientGet()
            {
                await _mediaApi.SearchAsync(Query, RequestMocks.RequestParams);

                _mockHttpClient.Verify(hc => hc.GetAsync<MultipleMediaResponse>(
                    "vr/search",
                    It.IsAny<IDictionary<string, object>>() // TODO: compare equality
                ), Times.Once);
            }

            [Test]
            public async Task Search_WithQueryAndParams_ReturnsMultipleMediaResponse()
            {
                var result = await _mediaApi.SearchAsync(Query, RequestMocks.RequestParams);

                Assert.AreEqual(ResponseMocks.MultipleMediaResponse, result);
            }
        }
    }
}
