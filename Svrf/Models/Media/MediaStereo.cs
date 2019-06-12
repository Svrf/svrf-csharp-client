using Newtonsoft.Json;

namespace Svrf.Models.Media
{
    public class MediaStereo
    {
        /// <summary>
        /// Maximum resolution video (original source video),
        /// </summary>
        public string Max { get; set; }

        /// <summary>
        /// URL for an HLS master playlist containing streams in all of the above resolutions
        /// which are no wider than the original Media.
        /// </summary>
        public string Hls { get; set; }

        [JsonProperty("4096")]
        public string Width4096 { get; set; }

        [JsonProperty("2160")]
        public string Width2160 { get; set; }

        [JsonProperty("1440")]
        public string Width1440 { get; set; }

        [JsonProperty("848")]
        public string Width848 { get; set; }
    }
}
