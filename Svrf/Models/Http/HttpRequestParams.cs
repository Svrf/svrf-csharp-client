using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Svrf.Extensions;
using Svrf.Models.Media;

namespace Svrf.Models.Http
{
    public class HttpRequestParams
    {
        private int? _pageNum;
        private int? _size;

        public Category? Category { get; set; }
        public bool? HasBlendShapes { get; set; }
        public bool? IsFaceFilter { get; set; }
        public int? MinimumWidth { get; set; }

        public int? PageNum
        {
            get { return _pageNum; }
            set
            {
                value?.ValidateRange(nameof(PageNum), min: 0);
                _pageNum = value;
            }
        }

        public bool? RequiresBlendShapes { get; set; }

        public int? Size
        {
            get { return _size; }
            set
            {
                value?.ValidateRange(nameof(Size), 0, 100);
                _size = value;
            }
        }

        public StereoscopicType? StereoscopicType { get; set; }
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
