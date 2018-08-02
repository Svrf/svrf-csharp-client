/* 
 * SVRF API
 *
 * # Getting Started  SVRF's API allows you to supercharge your project or app with the first and largest search engine for immersive experiences. We make it simple for any developer to incorporate highly immersive experiences with all kinds of applications: virtual reality, augmented reality, mixed reality, mobile, and web.  The SVRF API is based on REST principles, allowing it to integrate cross-platform. Our endpoints return responses in [JSON][]. We support [CORS][], allowing you to access immersive experiences indexed by SVRF on your own web domains. We provide a variety of resolutions, projections, and file formats to support most modern clients.  The SVRF API Documentation is available at [https://developers.svrf.com][SVRF Dev].  ## Access and API Keys  The SVRF API is currently in private beta and access is limited to select partners. If you are interested in using the SVRF API for your app or project, please contact us at [api@svrf.com][API Email]. We cannot guarantee immediate access for all requests, but we will announce a public release in the coming months.  See our [terms of service][TOS] for restrictions on using the SVRF API.  If you have any questions please contact us at [api@svrf.com][API Email]. Submit API corrections via [GitHub Issues][].  ## API Highlights  ### Search Endpoint  The [SVRF Search Endpoint][Docs Search] brings the power of immersive search found on [SVRF.com][SVRF] to your app or project. Our search engine enables your users to instantly find the immersive experience they are seeking. Content is sorted by the SVRF rating system, ensuring that the highest quality and most relevant search results are returned first.  ### Trending Endpoint  The [SVRF Trending Endpoint][Docs Trending] provides your app or project with the hottest immersive content - curated by real humans. The experiences returned mirror the [SVRF homepage][SVRF], from timely cultural content to trending pop-culture references. The experiences are updated regularly to ensure users always get a fresh list of immersive content.  ## API Libraries  You can use SVRF API libraries to encapsulate endpoint requests: * [C#][CSharp] * [Java][Java] * [JavaScript][JavaScript] * [Objective C][Objective C]  ## Attribution  ### Authors and Site Credit  At SVRF, we believe in giving credit where credit is due. Do your best to provide attribution to the `authors` and `site` where the content originated. We suggest using the format: __by {authors} via {site}__.  If possible, provide a way for users to discover and visit the page the content originally came from (`url`).  ### Powered By SVRF  As per section 5a of the [terms of service][TOS], __we require all apps that use the SVRF API to conspicuously display \"Powered By SVRF\" attribution marks where the API is utilized.__  ## Rate Limits  The SVRF API has a generous rate limit to ensure the best experience for your users. We rate limit by IP address with a maximum of 100 requests per second. If you exceed this rate limit, requests will be blocked for 60 seconds. Requests blocked by the rate limit will return with status code `429`.  [API Email]: mailto:api@svrf.com [CORS]: https://en.wikipedia.org/wiki/Cross-origin_resource_sharing [CSharp]: https://www.nuget.org/packages/SVRF.Client [Docs Search]: https://developers.svrf.com/#tag/Media/paths/~1vr~1search?q={q}/get [Docs Trending]: https://developers.svrf.com/#tag/Media/paths/~1vr~1trending/get [GitHub Issues]: https://github.com/Svrf/svrf-api/issues [Java]: https://mvnrepository.com/artifact/com.svrf/svrf-client [JavaScript]: https://www.npmjs.com/package/svrf-client [JSON]: http://www.json.org/ [Objective C]: https://cocoapods.org/pods/SVRFClient [SVRF]: https://www.svrf.com [SVRF Dev]: https://developers.svrf.com [TOS]: https://www.svrf.com/terms 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: api@svrf.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
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
    /// Media
    /// </summary>
    [DataContract]
    public partial class Media :  IEquatable<Media>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public MediaType? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Media" /> class.
        /// </summary>
        /// <param name="Adult">Whether the Media is adult content (default to false).</param>
        /// <param name="Authors">The Media&#39;s authors. This should be displayed when possible..</param>
        /// <param name="Canonical">The canonical page this Media can be found at via SVRF..</param>
        /// <param name="Description">A description of the Media.</param>
        /// <param name="Duration">The duration of the Media in seconds..</param>
        /// <param name="EmbedHtml">An &#x60;&lt;iframe&gt;&#x60; tag that embeds a player that plays the Media..</param>
        /// <param name="EmbedUrl">A player that can be embedded using an &#x60;&lt;iframe&gt;&#x60; tag to play the Media..</param>
        /// <param name="Files">Files.</param>
        /// <param name="Height">The height, in pixels, of the Media&#39;s source.</param>
        /// <param name="Id">The unique ID of this Media.</param>
        /// <param name="Site">The site that this Media came from. This should be displayed when possible..</param>
        /// <param name="Title">The title of the Media, suitable for displaying.</param>
        /// <param name="Type">Type.</param>
        /// <param name="Url">The original page this Media is located at..</param>
        /// <param name="Width">The width, in pixels, of the Media&#39;s source.</param>
        public Media(bool? Adult = false, List<string> Authors = default(List<string>), string Canonical = default(string), string Description = default(string), decimal? Duration = default(decimal?), string EmbedHtml = default(string), string EmbedUrl = default(string), MediaFiles Files = default(MediaFiles), decimal? Height = default(decimal?), string Id = default(string), string Site = default(string), string Title = default(string), MediaType? Type = default(MediaType?), string Url = default(string), decimal? Width = default(decimal?))
        {
            // use default value if no "Adult" provided
            if (Adult == null)
            {
                this.Adult = false;
            }
            else
            {
                this.Adult = Adult;
            }
            this.Authors = Authors;
            this.Canonical = Canonical;
            this.Description = Description;
            this.Duration = Duration;
            this.EmbedHtml = EmbedHtml;
            this.EmbedUrl = EmbedUrl;
            this.Files = Files;
            this.Height = Height;
            this.Id = Id;
            this.Site = Site;
            this.Title = Title;
            this.Type = Type;
            this.Url = Url;
            this.Width = Width;
        }
        
        /// <summary>
        /// Whether the Media is adult content
        /// </summary>
        /// <value>Whether the Media is adult content</value>
        [DataMember(Name="adult", EmitDefaultValue=false)]
        public bool? Adult { get; set; }

        /// <summary>
        /// The Media&#39;s authors. This should be displayed when possible.
        /// </summary>
        /// <value>The Media&#39;s authors. This should be displayed when possible.</value>
        [DataMember(Name="authors", EmitDefaultValue=false)]
        public List<string> Authors { get; set; }

        /// <summary>
        /// The canonical page this Media can be found at via SVRF.
        /// </summary>
        /// <value>The canonical page this Media can be found at via SVRF.</value>
        [DataMember(Name="canonical", EmitDefaultValue=false)]
        public string Canonical { get; set; }

        /// <summary>
        /// A description of the Media
        /// </summary>
        /// <value>A description of the Media</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// The duration of the Media in seconds.
        /// </summary>
        /// <value>The duration of the Media in seconds.</value>
        [DataMember(Name="duration", EmitDefaultValue=false)]
        public decimal? Duration { get; set; }

        /// <summary>
        /// An &#x60;&lt;iframe&gt;&#x60; tag that embeds a player that plays the Media.
        /// </summary>
        /// <value>An &#x60;&lt;iframe&gt;&#x60; tag that embeds a player that plays the Media.</value>
        [DataMember(Name="embedHtml", EmitDefaultValue=false)]
        public string EmbedHtml { get; set; }

        /// <summary>
        /// A player that can be embedded using an &#x60;&lt;iframe&gt;&#x60; tag to play the Media.
        /// </summary>
        /// <value>A player that can be embedded using an &#x60;&lt;iframe&gt;&#x60; tag to play the Media.</value>
        [DataMember(Name="embedUrl", EmitDefaultValue=false)]
        public string EmbedUrl { get; set; }

        /// <summary>
        /// Gets or Sets Files
        /// </summary>
        [DataMember(Name="files", EmitDefaultValue=false)]
        public MediaFiles Files { get; set; }

        /// <summary>
        /// The height, in pixels, of the Media&#39;s source
        /// </summary>
        /// <value>The height, in pixels, of the Media&#39;s source</value>
        [DataMember(Name="height", EmitDefaultValue=false)]
        public decimal? Height { get; set; }

        /// <summary>
        /// The unique ID of this Media
        /// </summary>
        /// <value>The unique ID of this Media</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// The site that this Media came from. This should be displayed when possible.
        /// </summary>
        /// <value>The site that this Media came from. This should be displayed when possible.</value>
        [DataMember(Name="site", EmitDefaultValue=false)]
        public string Site { get; set; }

        /// <summary>
        /// The title of the Media, suitable for displaying
        /// </summary>
        /// <value>The title of the Media, suitable for displaying</value>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }


        /// <summary>
        /// The original page this Media is located at.
        /// </summary>
        /// <value>The original page this Media is located at.</value>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// The width, in pixels, of the Media&#39;s source
        /// </summary>
        /// <value>The width, in pixels, of the Media&#39;s source</value>
        [DataMember(Name="width", EmitDefaultValue=false)]
        public decimal? Width { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Media {\n");
            sb.Append("  Adult: ").Append(Adult).Append("\n");
            sb.Append("  Authors: ").Append(Authors).Append("\n");
            sb.Append("  Canonical: ").Append(Canonical).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  EmbedHtml: ").Append(EmbedHtml).Append("\n");
            sb.Append("  EmbedUrl: ").Append(EmbedUrl).Append("\n");
            sb.Append("  Files: ").Append(Files).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Site: ").Append(Site).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
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
            return this.Equals(input as Media);
        }

        /// <summary>
        /// Returns true if Media instances are equal
        /// </summary>
        /// <param name="input">Instance of Media to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Media input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Adult == input.Adult ||
                    (this.Adult != null &&
                    this.Adult.Equals(input.Adult))
                ) && 
                (
                    this.Authors == input.Authors ||
                    this.Authors != null &&
                    this.Authors.SequenceEqual(input.Authors)
                ) && 
                (
                    this.Canonical == input.Canonical ||
                    (this.Canonical != null &&
                    this.Canonical.Equals(input.Canonical))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Duration == input.Duration ||
                    (this.Duration != null &&
                    this.Duration.Equals(input.Duration))
                ) && 
                (
                    this.EmbedHtml == input.EmbedHtml ||
                    (this.EmbedHtml != null &&
                    this.EmbedHtml.Equals(input.EmbedHtml))
                ) && 
                (
                    this.EmbedUrl == input.EmbedUrl ||
                    (this.EmbedUrl != null &&
                    this.EmbedUrl.Equals(input.EmbedUrl))
                ) && 
                (
                    this.Files == input.Files ||
                    (this.Files != null &&
                    this.Files.Equals(input.Files))
                ) && 
                (
                    this.Height == input.Height ||
                    (this.Height != null &&
                    this.Height.Equals(input.Height))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Site == input.Site ||
                    (this.Site != null &&
                    this.Site.Equals(input.Site))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.Width == input.Width ||
                    (this.Width != null &&
                    this.Width.Equals(input.Width))
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
                if (this.Adult != null)
                    hashCode = hashCode * 59 + this.Adult.GetHashCode();
                if (this.Authors != null)
                    hashCode = hashCode * 59 + this.Authors.GetHashCode();
                if (this.Canonical != null)
                    hashCode = hashCode * 59 + this.Canonical.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Duration != null)
                    hashCode = hashCode * 59 + this.Duration.GetHashCode();
                if (this.EmbedHtml != null)
                    hashCode = hashCode * 59 + this.EmbedHtml.GetHashCode();
                if (this.EmbedUrl != null)
                    hashCode = hashCode * 59 + this.EmbedUrl.GetHashCode();
                if (this.Files != null)
                    hashCode = hashCode * 59 + this.Files.GetHashCode();
                if (this.Height != null)
                    hashCode = hashCode * 59 + this.Height.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Site != null)
                    hashCode = hashCode * 59 + this.Site.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.Width != null)
                    hashCode = hashCode * 59 + this.Width.GetHashCode();
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
