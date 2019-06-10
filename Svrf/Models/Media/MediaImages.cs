using Newtonsoft.Json;

namespace Svrf.Models.Media
{
    public class MediaImages
    {
        /// <summary>
        /// The image in its largest available size (the original size).
        /// </summary>
        public string Max { get; set; }

        [JsonProperty("8192")]
        public string Width8192 { get; set; }

        [JsonProperty("4096")]
        public string Width4096 { get; set; }

        [JsonProperty("1080")]
        public string Width1080 { get; set; }

        [JsonProperty("1080Watermarked")]
        public string Width1080Watermarked { get; set; }

        [JsonProperty("720")]
        public string Width720 { get; set; }

        [JsonProperty("720x720")]
        public string Size720x720 { get; set; }

        [JsonProperty("720x540")]
        public string Size720x540 { get; set; }

        [JsonProperty("720x405")]
        public string Size720x405 { get; set; }

        [JsonProperty("540")]
        public string Width540 { get; set; }

        [JsonProperty("136")]
        public string Width136 { get; set; }
    }
}
