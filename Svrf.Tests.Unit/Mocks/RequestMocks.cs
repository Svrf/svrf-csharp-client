using System.Collections.Generic;
using Svrf.Models.Http;
using Svrf.Models.Media;

namespace Svrf.Tests.Unit.Mocks
{
    internal static class RequestMocks
    {
        internal static MediaRequestParams MediaRequestParams = new MediaRequestParams
        {
            PageNum = 0,
            Size = 1,
            Type = new List<MediaType> { MediaType.Photo },
            HasBlendShapes = false,
            RequiresBlendShapes = false,
            IsFaceFilter = false,
            StereoscopicType = StereoscopicType.None
        };
    }
}