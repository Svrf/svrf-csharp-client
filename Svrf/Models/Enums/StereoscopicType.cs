using System.Runtime.Serialization;

namespace Svrf.Models.Enums
{
    public enum StereoscopicType
    {
        [EnumMember(Value = "none")]
        None,

        [EnumMember(Value = "top-bottom")]
        TopBottom,

        [EnumMember(Value = "left-right")]
        LeftRight
    }
}
