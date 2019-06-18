using System.Collections.Generic;
using System.Linq;
using Svrf.Models.Enums;

namespace Svrf.Models.Media
{
    public class MediaModel
    {
        public string Id { get; set; }
        public string Src { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public string Site { get; set; }
        public string Canonical { get; set; }
        public string Url { get; set; }
        public string EmbedUrl { get; set; }
        public string EmbedHtml { get; set; }
        public MediaType Type { get; set; }
        public bool Adult { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public float? Duration { get; set; }
        public MediaMetadata Metadata { get; set; }
        public MediaFiles Files { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as MediaModel;

            if (other == null)
            {
                return false;
            }

            return string.Equals(Id, other.Id)
                   && string.Equals(Src, other.Src)
                   && string.Equals(Title, other.Title)
                   && string.Equals(Description, other.Description)
                   && Authors.SequenceEqual(other.Authors)
                   && string.Equals(Site, other.Site)
                   && string.Equals(Canonical, other.Canonical)
                   && string.Equals(Url, other.Url)
                   && string.Equals(EmbedUrl, other.EmbedUrl)
                   && string.Equals(EmbedHtml, other.EmbedHtml)
                   && string.Equals(Type, other.Type)
                   && Adult == other.Adult
                   && Width == other.Width
                   && Height == other.Height
                   && Metadata.Equals(other.Metadata)
                   && Files.Equals(other.Files);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Src != null ? Src.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Site != null ? Site.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Canonical != null ? Canonical.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Url != null ? Url.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EmbedUrl != null ? EmbedUrl.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EmbedHtml != null ? EmbedHtml.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Type.GetHashCode();
                hashCode = (hashCode * 397) ^ Adult.GetHashCode();
                hashCode = (hashCode * 397) ^ Width.GetHashCode();
                hashCode = (hashCode * 397) ^ Height.GetHashCode();
                hashCode = (hashCode * 397) ^ Duration.GetHashCode();
                hashCode = (hashCode * 397) ^ (Metadata != null ? Metadata.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Files != null ? Files.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
