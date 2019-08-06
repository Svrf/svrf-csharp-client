using System;
using Moq;
using NUnit.Framework;
using Svrf.Models;
using Svrf.Services;
using Svrf.Services.Interfaces;
using Svrf.Storage;

namespace Svrf.Tests.Unit.Services
{
    [TestFixture]
    public class TokenServiceTest
    {
        public static DateTime Now = DateTime.Now;

        public Mock<ITokenStorage> TokenStorage = new Mock<ITokenStorage>();
        internal Mock<IDateTimeService> DateTimeProvider = new Mock<IDateTimeService>();

        internal TokenService TokenService { get; set; }

        private const string AppToken = "token";
        private const int ExpiresIn = 10;

        [SetUp]
        public void Init()
        {
            TokenService = CreateDefaultTokenService();
        }

        [TearDown]
        public void Cleanup()
        {
            TokenStorage.Reset();
            DateTimeProvider.Reset();
        }

        private TokenService CreateDefaultTokenService()
        {
            DateTimeProvider.SetupGet(dtp => dtp.Now).Returns(Now);

            return new TokenService(TokenStorage.Object, DateTimeProvider.Object);
        }

        [TestFixture]
        public class SetAppTokenInfoTest : TokenServiceTest
        {
            [Test]
            public void SetAppTokenInfo_TokenStorageSet_InvokesOnes()
            {
                TokenService.SetAppTokenInfo("token", 10);

                TokenStorage.Verify(ts => ts.Set(It.IsAny<AppTokenInfo>()), Times.Once());
            }

            [Test]
            public void SetAppTokenInfo_TokenStorage_PassCorrectAppTokenInfo()
            {
                var appTokenInfo = new AppTokenInfo(AppToken, Now.AddSeconds(ExpiresIn));

                TokenService.SetAppTokenInfo(AppToken, ExpiresIn);

                TokenStorage.Verify(ts => ts.Set(It.Is<AppTokenInfo>(p => p.Equals(appTokenInfo))));
            }
        }

        [TestFixture]
        public class GetAppTokenInfoTest : TokenServiceTest
        {
            [Test]
            public void GetAppTokenInfo_TokenStorageGet_InvokesOnce()
            {
                TokenService.GetAppTokenInfo();

                TokenStorage.Verify(ts => ts.Get(), Times.Once());
            }

            [Test]
            public void GetAppTokenInfo_TokenStorage_ReturnsAppTokenInfo()
            {
                var appTokenInfo = new AppTokenInfo(AppToken, Now.AddSeconds(ExpiresIn));
                TokenStorage.Setup(ts => ts.Get()).Returns(appTokenInfo);

                var actualAppTokenInfo = TokenService.GetAppTokenInfo();

                Assert.AreEqual(appTokenInfo, actualAppTokenInfo);
            }
        }

        [TestFixture]
        public class ClearAppTokenInfoTest : TokenServiceTest
        {
            [Test]
            public void ClearAppTokenInfo_TokenStorageClear_InvokesOnce()
            {
                TokenService.ClearAppTokenInfo();

                TokenStorage.Verify(ts => ts.Clear(), Times.Once());
            }
        }

        [TestFixture]
        public class IsTokenValidTest : TokenServiceTest
        {
            [TestFixture]
            public class ReturnsTrueTest : IsTokenValidTest
            {
                [Test]
                public void IsTokenValid_AppTokenInfoValid_ReturnsTrue()
                {
                    var appTokenInfo = new AppTokenInfo(AppToken, Now.AddSeconds(ExpiresIn));
                    TokenStorage.Setup(ts => ts.Get()).Returns(appTokenInfo);

                    var isTokenValid = TokenService.IsTokenValid;

                    Assert.IsTrue(isTokenValid);
                }
            }

            [TestFixture]
            public class ReturnsFalseTest : IsTokenValidTest
            {
                [Datapoint]
                public AppTokenInfo nullAppTokenInfo = null;

                [Datapoint]
                public AppTokenInfo expirationTimeInvalid = new AppTokenInfo(AppToken, Now.AddSeconds(-10));

                [Datapoint]
                public AppTokenInfo emptyAppToken = new AppTokenInfo("", Now.AddSeconds(10));

                [Theory]
                public void IsTokenValid_ReturnsFalse(AppTokenInfo appTokenInfo)
                {
                    TokenStorage.Setup(ts => ts.Get()).Returns(appTokenInfo);
                    var isTokenValid = TokenService.IsTokenValid;

                    Assert.IsFalse(isTokenValid);
                }
            }
        }
    }
}
