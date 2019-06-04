using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Svrf.Extensions;
using Svrf.Models.Media;

namespace Svrf.Models.Http
{
    /// <summary>
    /// Additional params for requesting multiple media.
    /// </summary>
    public class MediaRequestParams
    {
        private int? _pageNum;
        private int? _size;

        /// <summary>
        /// Search only for Media with a particular category.
        /// </summary>
        public Category? Category { get; set; }

        /// <summary>
        /// Search only for Media that has blend shapes.
        /// </summary>
        public bool? HasBlendShapes { get; set; }

        /// <summary>
        /// Search only for face filters.
        /// </summary>
        public bool? IsFaceFilter { get; set; }

        /// <summary>
        /// The minimum width for video and photo Media, in pixels.
        /// </summary>
        public int? MinimumWidth { get; set; }

        /// <summary>
        /// Pagination control to fetch the next page of results, if applicable.
        /// </summary>
        public int? PageNum
        {
            get { return _pageNum; }
            set
            {
                value?.ValidateRange(nameof(PageNum), min: 0);
                _pageNum = value;
            }
        }

        /// <summary>
        /// Search only for Media that requires blend shapes.
        /// </summary>
        public bool? RequiresBlendShapes { get; set; }

        /// <summary>
        /// The number of results per page.
        /// </summary>
        public int? Size
        {
            get { return _size; }
            set
            {
                value?.ValidateRange(nameof(Size), 0, 100);
                _size = value;
            }
        }

        /// <summary>
        /// Search only for Media with a particular stereoscopic type.
        /// </summary>
        public StereoscopicType? StereoscopicType { get; set; }

        /// <summary>
        /// The type(s) of Media to be returned.
        /// </summary>
        public List<MediaType> Type { get; set; }

        internal IDictionary<string, object> ToDictionary()
        {
            return GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary
                (
                    propInfo => propInfo.Name,
                    propInfo => propInfo.GetValue(this)
                );
        }
    }
}
