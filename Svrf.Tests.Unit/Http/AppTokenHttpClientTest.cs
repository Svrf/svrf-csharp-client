using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using Svrf.Api.Interfaces;
using Svrf.Http;
using Svrf.Models.Http;
using Svrf.Services;
using Svrf.Services.Interfaces;
using Svrf.Tests.Unit.Mocks;

namespace Svrf.Tests.Unit.Http
{
    [TestFixture]
    public class AppTokenHttpClientTest
    {
        private readonly Mock<IAuthApi> _mockAuthApi = new Mock<IAuthApi>();
        private readonly Mock<ITokenService> _mockTokenService = new Mock<ITokenService>();

        private static HttpRequestHeaders GetExpectedHeaders
        {
            get
            {
                var expectedHeaders = new HttpClient().DefaultRequestHeaders;
                expectedHeaders.Add("x-app-token", Token);

                return expectedHeaders;
            }
        }

        private AppTokenHttpClient _appTokenHttpClient;
        private MockedRequest _request;

        private const string Token = "token";
        private const string RequestUri = "/vr/";

        [SetUp]
        public virtual void Init()
        {
            _request = HttpClientMock.GetMockRequest_WithSuccess();

            _mockTokenService.Setup(ts => ts.GetAppToken()).Returns(Token);
            _mockAuthApi.Setup(aa => aa.AuthenticateAsync()).Returns(Task.FromResult(default(object)));
            
            _appTokenHttpClient = new AppTokenHttpClient(
                _mockAuthApi.Object,
                _mockTokenService.Object,
                HttpClientMock.MockHttpMessageHandler.ToHttpClient(),
                new QueryService());
        }

        [TearDown]
        public virtual void CleanUp()
        {
            _mockAuthApi.Reset();
            _mockTokenService.Reset();
            HttpClientMock.MockHttpMessageHandler.ResetBackendDefinitions();
        }

        [Test]
        public async Task GetAsync()
        {
            await _appTokenHttpClient.GetAsync<HttpResponseMessage>(RequestUri);

            Assert.AreEqual(HttpClientMock.MockHttpMessageHandler.GetMatchCount(_request), 1);
            Assert.AreEqual(GetExpectedHeaders, HttpClientMock.Headers);

            _mockAuthApi.Verify(aa => aa.AuthenticateAsync(), Times.Once);
            _mockTokenService.Verify(ts => ts.GetAppToken(), Times.Once);
        }

        [Test]
        public async Task PostAsync()
        {
            var body = new AuthRequestBody {ApiKey = "api key"};

            await _appTokenHttpClient.PostAsync<HttpResponseMessage>(RequestUri, body);

            Assert.AreEqual(HttpClientMock.MockHttpMessageHandler.GetMatchCount(_request), 1);
            Assert.AreEqual(GetExpectedHeaders, HttpClientMock.Headers);

            _mockAuthApi.Verify(aa => aa.AuthenticateAsync(), Times.Once);
            _mockTokenService.Verify(ts => ts.GetAppToken(), Times.Once);
        }
    }
}
