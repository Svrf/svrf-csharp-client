using System.Collections.Generic;
using Svrf.Models.Media;

namespace Svrf.Models.Http
{
    /// <summary>
    /// Response from a single media endpoint (for example, getting media by id).
    /// </summary>
    public class SingleMediaResponse
    {
        /// <summary>
        /// Result media.
        /// </summary>
        public MediaModel Media { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as SingleMediaResponse;

            if (other == null)
            {
                return false;
            }

            return Media.Equals(other.Media);
        }

        public override int GetHashCode()
        {
            return 284070683 + EqualityComparer<MediaModel>.Default.GetHashCode(Media);
        }
    }
}
