using System.Threading.Tasks;
using NUnit.Framework;
using Svrf.Exceptions;

namespace Svrf.Tests.Integration.Api
{
    [TestFixture]
    public class GetByIdTest
    {
        private SvrfClient _svrf;

        [SetUp]
        public void Init()
        {
            _svrf = ClientFactory.GetClient();
        }

        [Test]
        public async Task GetById_WithValidId_DoesNotThrowAnything()
        {
            var id = 730873;
            var mediaResponse = await _svrf.Media.GetByIdAsync(id);

            Assert.AreEqual(mediaResponse.Media.Id, id.ToString());
            Assert.NotNull(mediaResponse.Media.Title);
        }

        [Test]
        public void GetById_WithInvalidId_ThrowsException()
        {
            Assert.ThrowsAsync(typeof(MediaNotFoundException), async () =>
            {
                await _svrf.Media.GetByIdAsync("invalid id");
            });
        }
    }
}
