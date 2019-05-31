using System.Collections.Generic;
using System.Linq;

namespace Svrf.Models.Http
{
    public class MultipleMediaApiResponse
    {
        public bool Success { get; internal set; }
        public List<Media.Media> Media { get; internal set; }
        public string NextPageCursor { get; internal set; }
        public int NextPageNum { get; internal set; }
        public int PageNum { get; internal set; }

        public override bool Equals(object obj)
        {
            var other = obj as MultipleMediaApiResponse;

            if (other == null)
            {
                return false;
            }

            return Success == other.Success
                   && Media.SequenceEqual(other.Media)
                   && string.Equals(NextPageCursor, other.NextPageCursor)
                   && NextPageNum == other.NextPageNum
                   && PageNum == other.PageNum;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Success.GetHashCode();
                hashCode = (hashCode * 397) ^ (NextPageCursor != null ? NextPageCursor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NextPageNum;
                hashCode = (hashCode * 397) ^ PageNum;
                return hashCode;
            }
        }
    }
}
