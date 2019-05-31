using System.ComponentModel;

namespace Svrf.Models.Media
{
    public enum MediaType
    {
        [Description("photo")]
        Photo,

        [Description("video")]
        Video,

        [Description("3d")]
        Model3D
    }
}
