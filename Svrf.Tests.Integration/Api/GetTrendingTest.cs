
﻿using System.Linq;
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

            Assert.IsNotEmpty(response.Media);
            Assert.AreEqual(options.PageNum, response.PageNum);
            Assert.AreEqual(options.PageNum + 1, response.NextPageNum);

            foreach (var media in response.Media)
            {
                Assert.AreEqual(options.HasBlendShapes, media.Metadata.HasBlendShapes);
                Assert.AreEqual(options.IsFaceFilter, media.Metadata.IsFaceFilter);
                Assert.AreEqual(options.RequiresBlendShapes, media.Metadata.RequiresBlendShapes);
                Assert.AreEqual(options.Type.First(), media.Type);
            }
        }

        [Test]
        public async Task GetTrending_Category_LoadsMedia()
        {
            var options = new MediaRequestParams
            {
                Category = Category.FaceFilters
            };
            var response = await _svrf.Media.GetTrendingAsync(options);

            foreach (var media in response.Media)
            {
                Assert.AreEqual(MediaType.Model3D, media.Type);
            }
        }

        [Test]
        public async Task GetTrending_MediaType_LoadMedia()
        {
            var options = new MediaRequestParams
            {
                Type = new [] { MediaType.Photo }
            };

            var response = await _svrf.Media.GetTrendingAsync(options);

            foreach (var media in response.Media)
            {
                Assert.AreEqual(MediaType.Photo, media.Type);
            }
        }

        [Test]
        public async Task GetTrending_MinimumWidth_LoadsMedia()
        {
            var options = new MediaRequestParams
            {
                MinimumWidth = 2000
            };
            var response = await _svrf.Media.GetTrendingAsync(options);

            foreach (var media in response.Media)
            {
                Assert.GreaterOrEqual(media.Width, options.MinimumWidth);
            }
        }

        [Test]
        public async Task GetTrending_Pagination_LoadsMedia()
        {
            var options = new MediaRequestParams
            {
                PageNum = 5
            };
            var responseWithoutPageNumber= await _svrf.Media.GetTrendingAsync();
            var responseWithSpecifiedPageNumber = await _svrf.Media.GetTrendingAsync(options);
            
            Assert.AreEqual(responseWithoutPageNumber.PageNum + 1, responseWithoutPageNumber.NextPageNum);
            Assert.AreEqual(options.PageNum, responseWithSpecifiedPageNumber.PageNum);
        }

        [Test]
        public async Task GetTrending_Size_LoadsMedia()
        {
            var options = new MediaRequestParams
            {
                Size = 13
            };
            var firstPageResponse = await _svrf.Media.GetTrendingAsync(options);
            options.PageNum = 1;
            var secondPageResponse = await _svrf.Media.GetTrendingAsync(options);
            
            Assert.AreEqual(firstPageResponse.Media.Count, options.Size);
            Assert.AreEqual(secondPageResponse.Media.Count, options.Size);
        }

        [Test]
        public async Task GetTrending_IsFaceFilter_LoadsMedia()
        {
            var options = new MediaRequestParams
            {
                IsFaceFilter = true
            };
            var response = await _svrf.Media.GetTrendingAsync(options);

            foreach (var media in response.Media)
            {
                Assert.AreEqual(media.Metadata.IsFaceFilter, options.IsFaceFilter);    
            }
        }

        [Test]
        public async Task GetTrending_HasBlendShapes_LoadsMedia()
        {
            var options = new MediaRequestParams
            {
                HasBlendShapes = true,
            };
            var response = await _svrf.Media.GetTrendingAsync(options);

            foreach (var media in response.Media)
            {
                Assert.AreEqual(media.Metadata.HasBlendShapes, options.HasBlendShapes);
            }
        }

        [Test]
        public async Task GetTrending_RequiresBlendShapes_LoadsMedia()
        {
            var options = new MediaRequestParams
            {
                RequiresBlendShapes = true
            };
            var response = await _svrf.Media.GetTrendingAsync(options);

            foreach (var media in response.Media)
            {
                Assert.AreEqual(media.Metadata.RequiresBlendShapes, options.RequiresBlendShapes);
            }
        }

        [Test]
        public async Task GetTrending_StereoscopicType_LoadsMedia()
        {
            var leftRightOptions = new MediaRequestParams
            {
                StereoscopicType = StereoscopicType.TopBottom,
            };
            var topBottomOptions = new MediaRequestParams
            {
                StereoscopicType = StereoscopicType.LeftRight
            };
            var leftRightResponse = await _svrf.Media.GetTrendingAsync(leftRightOptions);
            var leftRightIds = leftRightResponse.Media.Select(m => m.Id).ToArray();

            var topBottomResponse = await _svrf.Media.GetTrendingAsync(topBottomOptions);
            var topBottomIds = topBottomResponse.Media.Select(m => m.Id).ToArray();
            
            Assert.IsNotEmpty(leftRightIds);
            Assert.IsNotEmpty(topBottomIds);

            Assert.IsEmpty(leftRightIds.Intersect(topBottomIds));
        }
    }
}
