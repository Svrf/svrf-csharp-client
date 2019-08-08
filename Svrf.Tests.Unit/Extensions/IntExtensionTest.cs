using System;
using NUnit.Framework;
using Svrf.Extensions;

namespace Svrf.Tests.Unit.Extentions
{
    [TestFixture]
    public class IntExtensionTest
    {
        private const int DefaultValue = 5;
        private const int MaxValue = 10;
        private const int MinValue = 1;
        private const string ValueName = "name";

        [Test]
        public void ValidateRange_WithoutMinMaxValues()
        {
            Assert.DoesNotThrow(() =>
            {
                DefaultValue.ValidateRange(ValueName);
            });
        }

        [Test]
        public void ValidateRange_WithMaxLimit()
        {
            Assert.DoesNotThrow(() =>
            {
                DefaultValue.ValidateRange(ValueName, null, MaxValue);
            });
        }

        [Test]
        public void ValidateRange_WithMinLimit()
        {
            Assert.DoesNotThrow(() =>
            {
                DefaultValue.ValidateRange(ValueName, MinValue);
            });
        }

        [Test]
        public void ValidateRange_WithAllLimits()
        {
            Assert.DoesNotThrow(() =>
            {
                DefaultValue.ValidateRange(ValueName, MinValue, MaxValue);
            });
        }

        [Test]
        public void ValidateRange_LessThanMinValue_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => { DefaultValue.ValidateRange(ValueName, 6, MaxValue); },
                $"{ValueName} should be equal or greater than {MinValue}");
        }
        
        [Test]
        public void ValidateRange_MoreThanMaxValue_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => { DefaultValue.ValidateRange(ValueName, null, 1); },
                $"{DefaultValue} should be equal or less than {MaxValue}");
        }

        [Test]
        public void ValidateRange_LessThanMinValueMoreThanMaxValue_ThrowsArgumentOutOoRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => { DefaultValue.ValidateRange(ValueName, MaxValue, MinValue); },
                $"{ValueName} should be equal or greater than {MinValue}");
        }

    }
}
