using System.Collections.Generic;

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
        public Media.Media Media { get; set; }

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
            return 284070683 + EqualityComparer<Media.Media>.Default.GetHashCode(Media);
        }
    }
}
