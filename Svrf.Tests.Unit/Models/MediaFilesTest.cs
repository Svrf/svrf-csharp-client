using System.Collections.Generic;
using NUnit.Framework;
using Svrf.Models.Media;

namespace Svrf.Tests.Unit.Models
{
    [TestFixture]
    public class MediaFilesTest
    {
        private const string GltfFileName = "DogeBlender2.gltf";
        private const string GltfUrl = "https://www.svrf.com/storage/svrf-models/676167/gltf/DogeBlender2.gltf";

        private readonly Dictionary<string, string> _nonGltfFiles = new Dictionary<string, string>
        {
            {"brow.jpg", "https://www.svrf.com/storage/svrf-models/676167/gltf/brow.jpg"},
            {"buffer.bin", "https://www.svrf.com/storage/svrf-models/676167/gltf/buffer.bin"},
            {"eye.jpg", "https://www.svrf.com/storage/svrf-models/676167/gltf/eye.jpg"},
            {"eyelids.jpg", "https://www.svrf.com/storage/svrf-models/676167/gltf/eyelids.jpg"},
            { "face.jpg", "https://www.svrf.com/storage/svrf-models/676167/gltf/face.jpg"},
        };

        [Test]
        public void GltfMain_NoGltfFiles_IsNull()
        {
            var files = new MediaFiles();
            Assert.IsNull(files.GltfMain);
        }

        [Test]
        public void GltfMain_EmptyGltfDictionary_IsNull()
        {
            var files = new MediaFiles {Gltf = new Dictionary<string, string>()};
            Assert.IsNull(files.GltfMain);
        }

        [Test]
        public void GltfMain_NoMainFile_IsNull()
        {
            var gltfFiles = new Dictionary<string, string>(_nonGltfFiles);
            var files = new MediaFiles { Gltf = gltfFiles };

            Assert.IsNull(files.GltfMain);
        }

        [Test]
        public void GltfMain_HasGltfFiles_ReturnsMainFile()
        {
            var gltfFiles = new Dictionary<string, string>(_nonGltfFiles);
            gltfFiles.Add(GltfFileName, GltfUrl);

            var files = new MediaFiles {Gltf = gltfFiles};

            Assert.AreEqual(GltfUrl, files.GltfMain);
        }

        [Test]
        public void GltfMain_UpperCaseValues_ReturnsMainFile()
        {
            var gltfUrl = GltfExtensionToUpper(GltfUrl);

            var gltfFiles = new Dictionary<string, string>(_nonGltfFiles);
            gltfFiles.Add(GltfExtensionToUpper(GltfFileName), gltfUrl);

            var files = new MediaFiles { Gltf = gltfFiles };

            Assert.AreEqual(gltfUrl, files.GltfMain);
        }

        private string GltfExtensionToUpper(string s)
        {
            return s.Replace("gltf", "GLTF");
        }
    }
}
