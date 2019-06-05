using Svrf.Models.Enums;
using Svrf.Models.Http;

namespace Svrf.Tests.Unit.Mocks
{
    internal static class RequestMocks
    {
        internal static MediaRequestParams MediaRequestParams = new MediaRequestParams
        {
            PageNum = 0,
            Size = 1,
            Type = new[] { MediaType.Photo },
            HasBlendShapes = false,
            RequiresBlendShapes = false,
            IsFaceFilter = false,
            StereoscopicType = StereoscopicType.None
        };
    }
}