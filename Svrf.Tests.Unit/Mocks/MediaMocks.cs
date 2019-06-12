using System.Collections.Generic;
using Svrf.Models.Enums;
using Svrf.Models.Media;

namespace Svrf.Tests.Unit.Mocks
{
    internal static class MediaMocks
    {
        internal static MediaModel Media = new MediaModel
        {
            Id = "1",
            Adult = false,
            Description = "description",
            Authors = new List<string> { "author" },
            Canonical = "canonical",
            EmbedUrl = "embedUrl",
            Files = new MediaFiles(),
            Site = "site",
            Src = "src",
            Metadata = new MediaMetadata(),
            Title = "title",
            Type = MediaType.Photo,
            Url = "url"
        };
    }
}
