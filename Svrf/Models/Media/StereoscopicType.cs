using System.ComponentModel;

namespace Svrf.Models.Media
{
    public enum StereoscopicType
    {
        [Description("none")]
        None,

        [Description("top-bottom")]
        TopBottom,

        [Description("left-right")]
        LeftRight
    }
}
