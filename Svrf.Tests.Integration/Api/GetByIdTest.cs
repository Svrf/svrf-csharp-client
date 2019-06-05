using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Svrf.Exceptions;
using Svrf.Models;

namespace Svrf.Tests.Integration.Api
{
    [TestFixture]
    public class GetByIdTest
    {
        private int _singleRequestId = 730873;
        private string _apiKey = Environment.GetEnvironmentVariable("SVRF_TEST_API_KEY");

        [Test]
        public async Task GetById()
        {
            var svrfApi = new SvrfClient(_apiKey);
            var mediaResponse = await svrfApi.Media.GetByIdAsync(_singleRequestId);

            Assert.AreEqual(mediaResponse.Media.Id, _singleRequestId.ToString());
            Assert.NotNull(mediaResponse.Media.Title);
        }

    }
}
