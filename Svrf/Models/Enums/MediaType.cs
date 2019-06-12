using System.Runtime.Serialization;

namespace Svrf.Models.Enums
{
    public enum MediaType
    {
        [EnumMember(Value = "photo")]
        Photo,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "3d")]
        Model3D
    }
}
