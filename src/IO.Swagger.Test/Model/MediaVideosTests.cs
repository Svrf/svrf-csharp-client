/* 
 * SVRF API
 *
 * # Getting Started  SVRF's API allows you to supercharge your project or app with the first and largest search engine for immersive experiences. We make it simple for any developer to incorporate highly immersive experiences with all kinds of applications: virtual reality, augmented reality, mixed reality, mobile, and web.  The SVRF API is based on REST principles, allowing it to integrate cross-platform. Our endpoints return responses in [JSON][]. We support [CORS][], allowing you to access immersive experiences indexed by SVRF on your own web domains. We provide a variety of resolutions, projections, and file formats to support most modern clients.  The SVRF API Documentation is available at [https://developers.svrf.com][SVRF Dev].  ## Access and API Keys  The SVRF API is currently in private beta and access is limited to select partners. If you are interested in using the SVRF API for your app or project, please contact us at [api@svrf.com][API Email]. We cannot guarantee immediate access for all requests, but we will announce a public release in the coming months.  See our [terms of service][TOS] for restrictions on using the SVRF API.  If you have any questions please contact us at [api@svrf.com][API Email]. Submit API corrections via [GitHub Issues][].  ## API Highlights  ### Search Endpoint  The [SVRF Search Endpoint][Docs Search] brings the power of immersive search found on [SVRF.com][SVRF] to your app or project. Our search engine enables your users to instantly find the immersive experience they are seeking. Content is sorted by the SVRF rating system, ensuring that the highest quality and most relevant search results are returned first.  ### Trending Endpoint  The [SVRF Trending Endpoint][Docs Trending] provides your app or project with the hottest immersive content - curated by real humans. The experiences returned mirror the [SVRF homepage][SVRF], from timely cultural content to trending pop-culture references. The experiences are updated regularly to ensure users always get a fresh list of immersive content.  ## Attribution  ### Authors and Site Credit  At SVRF, we believe in giving credit where credit is due. Do your best to provide attribution to the `authors` and `site` where the content originated. We suggest using the format: __by {authors} via {site}__.  If possible, provide a way for users to discover and visit the page the content originally came from (`url`).  ### Powered By SVRF  As per section 5a of the [terms of service][TOS], __we require all apps that use the SVRF API to conspicuously display \"Powered By SVRF\" attribution marks where the API is utilized.__  ## Rate Limits  The SVRF API has a generous rate limit to ensure the best experience for your users. We rate limit by IP address with a maximum of 100 requests per second. If you exceed this rate limit, requests will be blocked for 60 seconds. Requests blocked by the rate limit will return with status code `429`.  [API Email]: mailto:api@svrf.com [CORS]: https://en.wikipedia.org/wiki/Cross-origin_resource_sharing [Docs Search]: https://developers.svrf.com/#tag/Media/paths/~1vr~1search?q={q}/get [Docs Trending]: https://developers.svrf.com/#tag/Media/paths/~1vr~1trending/get [GitHub Issues]: https://github.com/Svrf/svrf-api/issues [JSON]: http://www.json.org/ [SVRF]: https://www.svrf.com [SVRF Dev]: https://developers.svrf.com [TOS]: https://www.svrf.com/terms 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: api@svrf.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */


using NUnit.Framework;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using IO.Swagger.Api;
using IO.Swagger.Model;
using IO.Swagger.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing MediaVideos
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the model.
    /// </remarks>
    [TestFixture]
    public class MediaVideosTests
    {
        // TODO uncomment below to declare an instance variable for MediaVideos
        //private MediaVideos instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            // TODO uncomment below to create an instance of MediaVideos
            //instance = new MediaVideos();
        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of MediaVideos
        /// </summary>
        [Test]
        public void MediaVideosInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOfType" MediaVideos
            //Assert.IsInstanceOfType<MediaVideos> (instance, "variable 'instance' is a MediaVideos");
        }


        /// <summary>
        /// Test the property '_848'
        /// </summary>
        [Test]
        public void _848Test()
        {
            // TODO unit test for the property '_848'
        }
        /// <summary>
        /// Test the property '_1440'
        /// </summary>
        [Test]
        public void _1440Test()
        {
            // TODO unit test for the property '_1440'
        }
        /// <summary>
        /// Test the property '_2160'
        /// </summary>
        [Test]
        public void _2160Test()
        {
            // TODO unit test for the property '_2160'
        }
        /// <summary>
        /// Test the property 'Clip'
        /// </summary>
        [Test]
        public void ClipTest()
        {
            // TODO unit test for the property 'Clip'
        }
        /// <summary>
        /// Test the property 'Hls'
        /// </summary>
        [Test]
        public void HlsTest()
        {
            // TODO unit test for the property 'Hls'
        }
        /// <summary>
        /// Test the property 'Max'
        /// </summary>
        [Test]
        public void MaxTest()
        {
            // TODO unit test for the property 'Max'
        }

    }

}
