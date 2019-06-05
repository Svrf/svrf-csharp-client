using System.Threading.Tasks;
using NUnit.Framework;
using Svrf.Models.Enums;
using Svrf.Models.Http;

namespace Svrf.Tests.Integration.Api
{
    [TestFixture]
    public class GetTrendingTest
    {
        private SvrfClient _svrf;

        [SetUp]
        public void Init()
        {
            _svrf = ClientFactory.GetClient();
        }

        [Test]
        public async Task GetTrending_NoParams_LoadsMedia()
        {
            var response = await _svrf.Media.GetTrendingAsync();
            Assert.Positive(response.Media.Count);
        }

        [Test]
        public async Task GetTrending_AllParams_LoadsMedia()
        {
            var options = new MediaRequestParams
            {
                Category = Category.FaceFilters,
                HasBlendShapes = true,
                IsFaceFilter = true,
                PageNum = 1,
                RequiresBlendShapes = false,
                Size = 3,
                Type = new [] { MediaType.Model3D }
            };
            var response = await _svrf.Media.GetTrendingAsync(options);

            Assert.Positive(response.Media.Count);
            Assert.AreEqual(options.PageNum, response.PageNum);
            Assert.AreEqual(options.PageNum + 1, response.NextPageNum);

            foreach (var media in response.Media)
            {
                Assert.AreEqual(true, media.Metadata.HasBlendShapes);
                Assert.AreEqual(true, media.Metadata.IsFaceFilter);
                Assert.AreEqual(false, media.Metadata.RequiresBlendShapes);
                Assert.AreEqual(MediaType.Model3D, media.Type);
            }
        }
    }
}
