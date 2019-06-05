using System.Threading.Tasks;
using NUnit.Framework;
using Svrf.Exceptions;
using Svrf.Models;

namespace Svrf.Tests.Integration.Api
{
    [TestFixture]
    public class AuthTest
    {
        [Test]
        public async Task Authenticate_AutoAuthWithValidKey_DoesNotThrowAnything()
        {
            var svrf = ClientFactory.GetClient(new ApiOptions { IsManualAuthentication = false });
            await svrf.Media.GetTrendingAsync(); // Ensure the auth was successful.
        }

        [Test]
        public void Authenticate_AutoAuthWithInvalidKey_ThrowsException()
        {
            Assert.ThrowsAsync(typeof(ApiKeyNotFoundException), async () =>
            {
                var svrf = new SvrfClient("invalid", new ApiOptions { IsManualAuthentication = false });
                await svrf.Media.GetTrendingAsync();
            });
        }

        [Test]
        public async Task Authenticate_ManualAuthWithValidKey_DoesNotThrowAnything()
        {
            var svrf = ClientFactory.GetClient(new ApiOptions { IsManualAuthentication = true });
            await svrf.AuthenticateAsync();
        }

        [Test]
        public void Authenticate_ManualAuthWithInvalidKey_ThrowsException()
        {
            Assert.ThrowsAsync(typeof(ApiKeyNotFoundException), async () =>
            {
                var svrf = new SvrfClient("invalid", new ApiOptions { IsManualAuthentication = true });
                await svrf.AuthenticateAsync();
            });
        }
    }
}
