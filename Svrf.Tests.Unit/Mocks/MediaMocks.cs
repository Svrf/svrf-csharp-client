using System.Collections.Generic;
using Svrf.Models.Media;

namespace Svrf.Tests.Unit.Mocks
{
    internal static class MediaMocks
    {
        internal static Media Media = new Media
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
            Type = "photo",
            Url = "url"
        };
    }
}
