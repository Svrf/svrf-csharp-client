using System.Collections.Generic;
using Newtonsoft.Json;

namespace Svrf.Models.Media
{
    public class MediaFiles
    {
        public MediaImages Images { get; set; }
        public MediaVideos Videos { get; set; }
        public MediaStereo Stereo { get; set; }
        public Dictionary<string, string> Gltf { get; set; }
        public string Glb { get; set; }

        [JsonProperty("glb-draco")]
        public string GlbDraco { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as MediaFiles;

            if (other == null)
            {
                return false;
            }

            return Images == other.Images || (Images != null && Images.Equals(other.Images))
                   && Videos == other.Videos || (Videos != null && Videos.Equals(other.Videos))
                   && Stereo == other.Stereo || (Stereo != null && Stereo.Equals(other.Stereo))
                   && Gltf == other.Gltf || (Gltf != null && Gltf.Equals(other.Gltf))
                   && Glb == other.Glb || (Glb != null && Glb.Equals(other.Glb))
                   && GlbDraco == other.GlbDraco || (GlbDraco != null && GlbDraco.Equals(other.GlbDraco));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Images != null ? Images.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Videos != null ? Videos.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Stereo != null ? Stereo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Gltf != null ? Gltf.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Glb != null ? Glb.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (GlbDraco != null ? GlbDraco.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
