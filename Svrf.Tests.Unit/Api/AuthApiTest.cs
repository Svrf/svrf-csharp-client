using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Svrf.Api;
using Svrf.Http;
using Svrf.Models.Http;
using Svrf.Services;
using Svrf.Storage;

namespace Svrf.Tests.Unit.Api
{
    [TestFixture]
    public class AuthApiTest
    {
        private const string ApiKey = "api key";

        private readonly Mock<IHttpClient> _mockHttpClient = new Mock<IHttpClient>();
        private readonly Mock<TokenService> _mockTokenService = new Mock<TokenService>(
            new Mock<ITokenStorage>().Object,
            new Mock<DateTimeProvider>().Object
        );

        private AuthApi _authApi;

        [SetUp]
        public void Init()
        {
            _authApi = new AuthApi(_mockHttpClient.Object, _mockTokenService.Object, ApiKey);
        }

        [TearDown]
        public void Cleanup()
        {
            _mockHttpClient.Reset();
            _mockTokenService.Reset();
        }

        [Test]
        public async Task Authenticate_IsTokenValidTrue_DoesNotCallHttpPost()
        {
            _mockTokenService.SetupGet(ts => ts.IsTokenValid).Returns(true);

            await _authApi.AuthenticateAsync();

            _mockTokenService.VerifyGet(ts => ts.IsTokenValid, Times.Once);
            _mockHttpClient.Verify(hc => hc.PostAsync<object>(It.IsAny<string>(), It.IsAny<object>()), Times.Never);
        }

        [Test]
        public void Authenticate_ApiKeyIsEmpty_ThrowsApiKeyNotFoundException()
        {
            _authApi = new AuthApi(_mockHttpClient.Object, _mockTokenService.Object, "");

            Assert.ThrowsAsync<ArgumentException>(() => _authApi.AuthenticateAsync());
        }

        [Test]
        public async Task Authenticate_IsTokenValidFalseAndApiKeyIsNotEmpty_InvokesHttpClientPostAsync()
        {
            _mockHttpClient
                .Setup(hc => hc.PostAsync<AuthResponse>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(Mocks.ResponseMocks.AuthResponse);

            await _authApi.AuthenticateAsync();

            _mockHttpClient.Verify(hc => hc.PostAsync<AuthResponse>(
                "app/authenticate",
                It.Is<AuthRequestBody>(b => b.ApiKey == ApiKey)
            ), Times.Once);
        }
    }
}
