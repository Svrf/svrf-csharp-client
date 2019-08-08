using System.Runtime.Serialization;
using NUnit.Framework;
using Svrf.Extensions;

namespace Svrf.Tests.Unit.Extensions
{
    [TestFixture]
    public class EnumExtensionTest
    {
        private enum TestEnums
        {
            One,

            [EnumMember(Value = nameof(One))]
            Two,
        }

        [Test]
        public void GetDescription_ReturnsStringValue()
        {
            Assert.AreEqual(nameof(TestEnums.One), TestEnums.One.GetDescription());
        }

        [Test]
        public void GetDescription_ReturnsDescriptionAttributeValue()
        {
            Assert.AreEqual(nameof(TestEnums.One), TestEnums.Two.GetDescription());
        }
    }
}
