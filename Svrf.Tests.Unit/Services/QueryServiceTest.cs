using System.Collections.Generic;
using NUnit.Framework;
using Svrf.Models.Enums;
using Svrf.Services;
using Svrf.Tests.Unit.Mocks;

namespace Svrf.Tests.Unit.Services
{
    [TestFixture]
    class QueryServiceTest
    {
        public QueryService QueryService { get; set; }

        [SetUp]
        public void Init()
        {
            QueryService = new QueryService();
        }

        [Test]
        public void Build_WithoutEnums_ReturnsQueryString()
        {
            var withoutEnums = new Dictionary<string, object>
            {
                { "TestFieldOne", "testField1" },
                { "TestFieldTwo", "testField2" }
            };

            const string expected = "testFieldOne=testField1&testFieldTwo=testField2";
            var actual = QueryService.Build(withoutEnums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Build_WithSpaces_ReturnsQueryString()
        {
            var withSpaces = new Dictionary<string, object>
            {
                { "TestFieldOne", "test field 1" },
                { "TestFieldTwo", "test field 2" }
            };

            const string expected = "testFieldOne=test%20field%201&testFieldTwo=test%20field%202";
            var actual = QueryService.Build(withSpaces);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Build_WithEnums_ReturnsQueryString()
        {
            var withEnums = new Dictionary<string, object>
            {
                { "TestFieldOne", MockEnum.TestEnumFieldOne },
                { "TestFieldTwo", MockEnum.TestEnumFieldTwo }
            };

            const string expected = "testFieldOne=testEnumField1&testFieldTwo=testEnumField2";
            var actual = QueryService.Build(withEnums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Build_WithList_ReturnsQueryString()
        {
            var withList = new Dictionary<string, object>
            {
                { "TestField", new List<string> { "value", "another" } }
            };

            const string expected = "testField=value,another";
            var actual = QueryService.Build(withList);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Build_WithMediaTypes_ReturnsQueryString()
        {
            var withEnumsList = new Dictionary<string, object>
            {
                { "TestField", new List<MediaType> { MediaType.Video, MediaType.Photo } }
            };

            const string expected = "testField=video,photo";
            var actual = QueryService.Build(withEnumsList);

            Assert.AreEqual(expected, actual);
        }
    }
}
