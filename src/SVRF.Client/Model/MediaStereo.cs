/*
 * SVRF API
 *
 * OpenAPI spec version: 1.0.0
 * Contact: api@svrf.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = SVRF.Client.Client.SwaggerDateConverter;

namespace SVRF.Client.Model
{
    /// <summary>
    /// Resized versions of the Media, matching the Media&#39;s type, in stereo. Only included if the Media is stereoscopic. Resolutions larger than the original size will not be included (the original is included as &#x60;max&#x60;).
    /// </summary>
    [DataContract]
    public partial class MediaStereo :  IEquatable<MediaStereo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaStereo" /> class.
        /// </summary>
        /// <param name="_848">848px wide video with a 1.3MBps video rate, 96KBps audio rate. Only included if the Media is a &#x60;video&#x60;..</param>
        /// <param name="_1440">1440px wide video with a 4.4MBps video rate, 128KBps audio rate. Only included if the Media is a &#x60;video&#x60;..</param>
        /// <param name="_2160">2160px wide video with a 10MBps video rate, 192KBps audio rate. Only included if the Media is a &#x60;video&#x60;..</param>
        /// <param name="_4096">4096px wide image. This image should be used on mobile devices, as larger images may cause some devices to crash. Only included if the Media is a &#x60;photo&#x60;..</param>
        /// <param name="Hls">URL for an HLS master playlist containing streams in all of the above resolutions which are no wider than the original Media. Only included if the Media is a &#x60;video&#x60;..</param>
        /// <param name="Max">The Media in its largest available size (the original size)..</param>
        public MediaStereo(string _848 = default(string), string _1440 = default(string), string _2160 = default(string), string _4096 = default(string), string Hls = default(string), string Max = default(string))
        {
            this._848 = _848;
            this._1440 = _1440;
            this._2160 = _2160;
            this._4096 = _4096;
            this.Hls = Hls;
            this.Max = Max;
        }
        
        /// <summary>
        /// 848px wide video with a 1.3MBps video rate, 96KBps audio rate. Only included if the Media is a &#x60;video&#x60;.
        /// </summary>
        /// <value>848px wide video with a 1.3MBps video rate, 96KBps audio rate. Only included if the Media is a &#x60;video&#x60;.</value>
        [DataMember(Name="848", EmitDefaultValue=false)]
        public string _848 { get; set; }

        /// <summary>
        /// 1440px wide video with a 4.4MBps video rate, 128KBps audio rate. Only included if the Media is a &#x60;video&#x60;.
        /// </summary>
        /// <value>1440px wide video with a 4.4MBps video rate, 128KBps audio rate. Only included if the Media is a &#x60;video&#x60;.</value>
        [DataMember(Name="1440", EmitDefaultValue=false)]
        public string _1440 { get; set; }

        /// <summary>
        /// 2160px wide video with a 10MBps video rate, 192KBps audio rate. Only included if the Media is a &#x60;video&#x60;.
        /// </summary>
        /// <value>2160px wide video with a 10MBps video rate, 192KBps audio rate. Only included if the Media is a &#x60;video&#x60;.</value>
        [DataMember(Name="2160", EmitDefaultValue=false)]
        public string _2160 { get; set; }

        /// <summary>
        /// 4096px wide image. This image should be used on mobile devices, as larger images may cause some devices to crash. Only included if the Media is a &#x60;photo&#x60;.
        /// </summary>
        /// <value>4096px wide image. This image should be used on mobile devices, as larger images may cause some devices to crash. Only included if the Media is a &#x60;photo&#x60;.</value>
        [DataMember(Name="4096", EmitDefaultValue=false)]
        public string _4096 { get; set; }

        /// <summary>
        /// URL for an HLS master playlist containing streams in all of the above resolutions which are no wider than the original Media. Only included if the Media is a &#x60;video&#x60;.
        /// </summary>
        /// <value>URL for an HLS master playlist containing streams in all of the above resolutions which are no wider than the original Media. Only included if the Media is a &#x60;video&#x60;.</value>
        [DataMember(Name="hls", EmitDefaultValue=false)]
        public string Hls { get; set; }

        /// <summary>
        /// The Media in its largest available size (the original size).
        /// </summary>
        /// <value>The Media in its largest available size (the original size).</value>
        [DataMember(Name="max", EmitDefaultValue=false)]
        public string Max { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MediaStereo {\n");
            sb.Append("  _848: ").Append(_848).Append("\n");
            sb.Append("  _1440: ").Append(_1440).Append("\n");
            sb.Append("  _2160: ").Append(_2160).Append("\n");
            sb.Append("  _4096: ").Append(_4096).Append("\n");
            sb.Append("  Hls: ").Append(Hls).Append("\n");
            sb.Append("  Max: ").Append(Max).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as MediaStereo);
        }

        /// <summary>
        /// Returns true if MediaStereo instances are equal
        /// </summary>
        /// <param name="input">Instance of MediaStereo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MediaStereo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this._848 == input._848 ||
                    (this._848 != null &&
                    this._848.Equals(input._848))
                ) && 
                (
                    this._1440 == input._1440 ||
                    (this._1440 != null &&
                    this._1440.Equals(input._1440))
                ) && 
                (
                    this._2160 == input._2160 ||
                    (this._2160 != null &&
                    this._2160.Equals(input._2160))
                ) && 
                (
                    this._4096 == input._4096 ||
                    (this._4096 != null &&
                    this._4096.Equals(input._4096))
                ) && 
                (
                    this.Hls == input.Hls ||
                    (this.Hls != null &&
                    this.Hls.Equals(input.Hls))
                ) && 
                (
                    this.Max == input.Max ||
                    (this.Max != null &&
                    this.Max.Equals(input.Max))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this._848 != null)
                    hashCode = hashCode * 59 + this._848.GetHashCode();
                if (this._1440 != null)
                    hashCode = hashCode * 59 + this._1440.GetHashCode();
                if (this._2160 != null)
                    hashCode = hashCode * 59 + this._2160.GetHashCode();
                if (this._4096 != null)
                    hashCode = hashCode * 59 + this._4096.GetHashCode();
                if (this.Hls != null)
                    hashCode = hashCode * 59 + this.Hls.GetHashCode();
                if (this.Max != null)
                    hashCode = hashCode * 59 + this.Max.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
