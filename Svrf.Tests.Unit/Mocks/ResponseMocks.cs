using System.Collections.Generic;
using Svrf.Models.Http;
using Svrf.Models.Media;

namespace Svrf.Tests.Unit.Mocks
{
    internal static class ResponseMocks
    {
        internal static AuthResponse AuthResponse = new AuthResponse
        {
            ExpiresIn = 5184000,
            Token = "abc",
        };

        internal static SingleMediaResponse SingleMediaResponse = new SingleMediaResponse
        {
            Media = MediaMocks.Media
        };

        internal static MultipleMediaResponse MultipleMediaResponse = new MultipleMediaResponse
        {
            Media = new List<MediaModel> { MediaMocks.Media },
            NextPageNum = 1,
            PageNum = 0
        };
    }
}
