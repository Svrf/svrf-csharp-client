using System.Threading.Tasks;
using NUnit.Framework;

namespace Svrf.Tests.Integration
{
    [TestFixture]
    public class UnitTest1
    {
        private int _singleRequestId = 730873;

        [Test]
        public async Task GetById()
        {
            var svrfApi = new SvrfClient(apiKey: "key");

            var mediaResponse = await svrfApi.Media.GetByIdAsync(_singleRequestId);

            Assert.AreEqual(mediaResponse.Media.Id, _singleRequestId.ToString());
        }
    }
}
