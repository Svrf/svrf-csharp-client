﻿using System.Collections.Generic;
using System.Linq;
using Svrf.Models.Media;

namespace Svrf.Models.Http
{
    /// <summary>
    /// Response from a multiple media endpoint (for example, getting trending media).
    /// </summary>
    public class MultipleMediaResponse
    {
        /// <summary>
        /// Result media.
        /// </summary>
        public IEnumerable<MediaModel> Media { get; set; }

        /// <summary>
        /// The next page to query to see more results, whether or not the next page actually exists.
        /// </summary>
        public int NextPageNum { get; set; }

        /// <summary>
        /// The current page number.
        /// </summary>
        public int PageNum { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as MultipleMediaResponse;

            if (other == null)
            {
                return false;
            }

            return Media.SequenceEqual(other.Media)
                   && NextPageNum == other.NextPageNum
                   && PageNum == other.PageNum;
        }

        public override int GetHashCode()
        {
            var hashCode = -685741926;
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<MediaModel>>.Default.GetHashCode(Media);
            hashCode = hashCode * -1521134295 + NextPageNum.GetHashCode();
            hashCode = hashCode * -1521134295 + PageNum.GetHashCode();
            return hashCode;
        }
    }
}
