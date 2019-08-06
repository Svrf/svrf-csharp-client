using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Svrf.Exceptions;
using Svrf.Http;
using Svrf.Models.Http;
using Svrf.Services.Interfaces;
using Svrf.Tests.Unit.Mocks;

namespace Svrf.Tests.Unit.Http
{
    [TestFixture]
    public class BaseHttpClientTest
    {
        private BaseHttpClient _baseHttpClient;
        private readonly Mock<IQueryService> _mockQueryService = new Mock<IQueryService>();

        private const string RequestUri = "/vr/";

        [SetUp]
        public virtual void Init()
        {
           _baseHttpClient = new BaseHttpClient(HttpClientMock.MockHttpMessageHandler.ToHttpClient(), _mockQueryService.Object);
        }

        [TearDown]
        public virtual void CleanUp()
        {
            HttpClientMock.MockHttpMessageHandler.ResetBackendDefinitions();
        }

        [TestFixture]
        public class GetAsync : BaseHttpClientTest
        {
            private const string FakedQueryString = "&IsFaceFilters=true&pageNum=10";

            [SetUp]
            public override void Init()
            {
                base.Init();
                _mockQueryService.Setup(qs => qs.Build(It.IsAny<IDictionary<string, object>>())).Returns(FakedQueryString);
            }

            [TearDown]
            public override void CleanUp()
            {
                base.CleanUp();
                _mockQueryService.Reset();

                HttpClientMock.ActualRequestUrl = null;
            }

            [Test]
            public async Task GetAsync_WithoutRequestParams()
            {
                var request = HttpClientMock.GetMockRequest_WithSuccess();

                var response = await _baseHttpClient.GetAsync<SingleMediaResponse>(RequestUri);

                Assert.AreEqual(HttpClientMock.MockHttpMessageHandler.GetMatchCount(request), 1);
                Assert.AreEqual(ResponseMocks.SingleMediaResponse, response);
            }

            [Test]
            public async Task GetAsync_WithMediaRequestParams()
            {
                var request = HttpClientMock.GetMockRequest_WithSuccess();
                var expectedRequestUri = new Uri($"https://api.svrf.com{RequestUri}?{FakedQueryString}");

                var response = await _baseHttpClient.GetAsync<SingleMediaResponse>(RequestUri, RequestMocks.MediaRequestParams.ToDictionary());
                
                _mockQueryService.Verify(qs => qs.Build(It.IsAny<IDictionary<string, object>>()), Times.Once);

                Assert.AreEqual(expectedRequestUri, HttpClientMock.ActualRequestUrl);
                Assert.AreEqual(HttpClientMock.MockHttpMessageHandler.GetMatchCount(request), 1);
                Assert.AreEqual(ResponseMocks.SingleMediaResponse, response);
            }

            [Test]
            public void GetAsync_ThrowsUnauthorizedException()
            {
                HttpClientMock.GetMockRequest_WithException(HttpStatusCode.Forbidden);

                Assert.ThrowsAsync<UnauthorizedException>(async () =>
                    await _baseHttpClient.GetAsync<HttpResponseMessage>(RequestUri));
            }

            [Test]
            public void GetAsync_ThrowsTooManyRequestsException()
            {
                HttpClientMock.GetMockRequest_WithException((HttpStatusCode) 429);

                Assert.ThrowsAsync<TooManyRequestsException>(async () =>
                    await _baseHttpClient.GetAsync<HttpResponseMessage>(RequestUri));
            }
        }

        [TestFixture]
        public class PostAsync : BaseHttpClientTest
        {
            private readonly object _requestBody = new AuthRequestBody {ApiKey = "Api key"};

            [SetUp]
            public override void Init()
            {
                base.Init();

            }

            [TearDown]
            public override void CleanUp()
            {
                base.CleanUp();
            }

            [Test]
            public async Task PostAsync_WithAuthRequestBody()
            {
                var request = HttpClientMock.GetMockRequest_WithSuccess();

                var response = await _baseHttpClient.PostAsync<AuthResponse>(RequestUri, _requestBody);

                Assert.AreEqual(HttpClientMock.MockHttpMessageHandler.GetMatchCount(request), 1);
                Assert.AreEqual(ResponseMocks.AuthResponse.Token, response.Token);
            }

            [Test]
            public void PostAsync_WithAuthRequestBody_ThrowsUnauthorizedException()
            {
                HttpClientMock.GetMockRequest_WithException(HttpStatusCode.Forbidden);

                Assert.ThrowsAsync<UnauthorizedException>(async () =>
                    await _baseHttpClient.PostAsync<HttpResponseMessage>(RequestUri, _requestBody));
            }

            [Test]
            public void PostAsync_WithAuthRequestBody_TooManyRequestsException()
            {
                HttpClientMock.GetMockRequest_WithException((HttpStatusCode) 429);

                Assert.ThrowsAsync<TooManyRequestsException>(async () => 
                    await _baseHttpClient.PostAsync<HttpResponseMessage>(RequestUri, _requestBody));
            }
        }
    }
}
