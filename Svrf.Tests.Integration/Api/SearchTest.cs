using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Svrf.Models.Enums;
using Svrf.Models.Http;

namespace Svrf.Tests.Integration.Api
{
    [TestFixture]
    public class SearchTest
    {
        private SvrfClient _svrf;

        private const string Query = "everest";
        private const string FaceFilterQuery = "avocado";
        private const string PopularQuery = "vr";

        [SetUp]
        public void Init()
        {
            _svrf = ClientFactory.GetClient();
        }

        [Test]
        public async Task Search_OnlyQuery_LoadsMedia()
        {
            var response = await _svrf.Media.SearchAsync(FaceFilterQuery);
            foreach (var media in response.Media)
            {
                Assert.IsTrue(media.Title.ToLower().Contains(FaceFilterQuery));
            }
        }

        [Test]
        public async Task Search_AllParams_LoadsMedia()
        {
            var options = new MediaRequestParams
            {
                Category = Category.FaceFilters,
                HasBlendShapes = false,
                IsFaceFilter = true,
                RequiresBlendShapes = true,
                Type = new[] { MediaType.Model3D }
            };
            var response = await _svrf.Media.SearchAsync(FaceFilterQuery, options);

            Assert.IsNotEmpty(response.Media);

            foreach (var media in response.Media)
            {
                Assert.AreEqual(options.HasBlendShapes, media.Metadata.HasBlendShapes);
                Assert.AreEqual(options.IsFaceFilter, media.Metadata.IsFaceFilter);
                Assert.AreEqual(options.RequiresBlendShapes, media.Metadata.RequiresBlendShapes);
                Assert.AreEqual(options.Type.First(), media.Type);
            }
        }

        [Test]
        public async Task Search_Pagination_HandlesPageChanging()
        {
            var options = new MediaRequestParams
            {
                PageNum = 0,
                Size = 3
            };
            var firstPage = await _svrf.Media.SearchAsync(Query, options);

            options.PageNum = 1;
            var secondPage = await _svrf.Media.SearchAsync(Query, options);

            Assert.AreEqual(0, firstPage.PageNum);
            Assert.AreEqual(1, firstPage.NextPageNum);
            Assert.AreEqual(1, secondPage.PageNum);
            Assert.AreEqual(2, secondPage.NextPageNum);

            Assert.AreEqual(options.Size, firstPage.Media.Count());
            Assert.AreEqual(options.Size, secondPage.Media.Count());

            var firstPageIds = firstPage.Media.Select(m => m.Id);
            var secondPageIds = secondPage.Media.Select(m => m.Id);

            var intersection = firstPageIds.Intersect(secondPageIds);
            Assert.IsEmpty(intersection);
        }

        [Test]
        public async Task Search_MultipleTypes_SearchesMultipleTypes()
        {
            var options = new MediaRequestParams
            {
                Type = new[] { MediaType.Photo, MediaType.Video }
            };
            var response = await _svrf.Media.SearchAsync(Query, options);

            Assert.IsNotEmpty(response.Media.Where(m => m.Type == MediaType.Photo));
            Assert.IsNotEmpty(response.Media.Where(m => m.Type == MediaType.Video));
        }

        [Test]
        public async Task Search_MinimumWidth_HandlesMinimumWidth()
        {
            var options = new MediaRequestParams
            {
                MinimumWidth = 4000
            };
            var response = await _svrf.Media.SearchAsync(Query, options);

            foreach (var media in response.Media)
            {
                Assert.GreaterOrEqual(media.Width, options.MinimumWidth);
            }
        }

        [Test]
        public async Task Search_StereoType_HandlesStereoType()
        {
            var options = new MediaRequestParams
            {
                StereoscopicType = StereoscopicType.LeftRight
            };
            var leftRightResponse = await _svrf.Media.SearchAsync(PopularQuery, options);

            options.StereoscopicType = StereoscopicType.TopBottom;
            var topBottomResponse = await _svrf.Media.SearchAsync(PopularQuery, options);

            var leftRightIds = leftRightResponse.Media.Select(m => m.Id).ToArray();
            var topBottomIds = topBottomResponse.Media.Select(m => m.Id).ToArray();
            Assert.IsNotEmpty(leftRightIds);
            Assert.IsNotEmpty(topBottomIds);

            Assert.IsEmpty(leftRightIds.Intersect(topBottomIds));
        }
    }
}
