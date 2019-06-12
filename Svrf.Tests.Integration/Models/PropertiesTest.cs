using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;
using Svrf.Models.Enums;
using Svrf.Models.Media;

namespace Svrf.Tests.Integration.Models
{
    [TestFixture]
    public class PropertiesTest
    {
        private SvrfClient _svrf;

        private const int PhotoId = 575947;
        private const int VideoId = 184684;
        private const int StereoId = 96870;
        private const int ModelId = 663496;

        [SetUp]
        public void Init()
        {
            _svrf = ClientFactory.GetClient();
        }

        [Test]
        public async Task ParsingResponse_Photo_ParsesBasicProperties()
        {
            var response = await _svrf.Media.GetByIdAsync(PhotoId);
            var media = response.Media;
            
            VerifyBasicFields(media);
            VerifySizeFields(media);
            Assert.AreEqual(MediaType.Photo, media.Type);
        }

        [Test]
        public async Task ParsingResponse_Video_ParsesBasicProperties()
        {
            var response = await _svrf.Media.GetByIdAsync(VideoId);
            var media = response.Media;

            VerifyBasicFields(media);
            VerifySizeFields(media);

            Assert.AreEqual(MediaType.Video, media.Type);

            Assert.IsTrue(media.Duration.HasValue);
            Assert.Positive(media.Duration.Value);
        }

        [Test]
        public async Task ParsingResponse_Model_ParsesBasicProperties()
        {
            var response = await _svrf.Media.GetByIdAsync(ModelId);
            var media = response.Media;

            VerifyBasicFields(media);
            Assert.AreEqual(MediaType.Model3D, media.Type);
        }

        [Test]
        public async Task ParsingResponse_Model_ParsesMetadata()
        {
            var response = await _svrf.Media.GetByIdAsync(ModelId);
            var metadata = response.Media.Metadata;

            Assert.IsNotNull(metadata);
            Assert.IsNotNull(metadata.IsFaceFilter);
            Assert.IsNotNull(metadata.HasBlendShapes);
            Assert.IsNotNull(metadata.RequiresBlendShapes);

            Assert.IsTrue(metadata.IsFaceFilter);
        }

        [Test]
        public async Task ParsingResponse_Photo_ParsesFiles()
        {
            var response = await _svrf.Media.GetByIdAsync(PhotoId);
            var files = response.Media.Files;

            VerifyAllFields(files.Images);
        }

        [Test]
        public async Task ParsingResponse_Video_ParsesFiles()
        {
            var response = await _svrf.Media.GetByIdAsync(VideoId);
            var files = response.Media.Files;

            VerifyAllFields(files.Videos);
        }

        [Test]
        public async Task ParsingResponse_Stereo_ParsesFiles()
        {
            var response = await _svrf.Media.GetByIdAsync(StereoId);
            var files = response.Media.Files;

            CheckString(files.Stereo.Hls);
            CheckString(files.Stereo.Max);
            CheckString(files.Stereo.Width848);
        }

        [Test]
        public async Task ParsingResponse_Model_ParsesFiles()
        {
            var response = await _svrf.Media.GetByIdAsync(ModelId);
            var files = response.Media.Files;

            VerifyAllFields(files.Images);

            CheckString(files.Glb);
            CheckString(files.GlbDraco);
            Assert.IsNotEmpty(files.Gltf);
        }

        private void VerifyBasicFields(MediaModel media)
        {
            CheckString(media.Id);
            CheckString(media.Title);
            CheckString(media.Authors.First());
            CheckString(media.Site);
            CheckString(media.Canonical);
            CheckString(media.Url);
            CheckString(media.EmbedUrl);
            CheckString(media.EmbedHtml);

            Assert.IsNotEmpty(media.Authors);
        }

        private void VerifySizeFields(MediaModel media)
        {
            Assert.IsTrue(media.Height.HasValue);
            Assert.Positive(media.Height.Value);

            Assert.IsTrue(media.Width.HasValue);
            Assert.Positive(media.Width.Value);
        }

        private void VerifyAllFields(object model)
        {
            var props = model.GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.PropertyType == typeof(string))
                .Select(propInfo => new KeyValuePair<string, string>(propInfo.Name, (string)propInfo.GetValue(model)));

            foreach (var keyValue in props)
            {
                CheckString(keyValue.Value, $"{keyValue.Key} property should not be empty");
            }
        }

        private void CheckString(string s, string message = "")
        {
            Assert.IsNotNull(s, message);
            Assert.IsNotEmpty(s, message);
        }
    }
}
