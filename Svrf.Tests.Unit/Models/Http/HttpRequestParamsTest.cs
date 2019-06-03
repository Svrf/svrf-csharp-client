using System;
using NUnit.Framework;
using Svrf.Models.Http;

namespace Svrf.Tests.Unit.Models.Http
{
    [TestFixture]
    public class HttpRequestParamsTest
    {
        [Test]
        public void PageNum_PositiveValue_DoesNotThrowAnyException()
        {
            Assert.DoesNotThrow(() =>
            {
                var requestParams = new HttpRequestParams {PageNum = 1};
            });
        }

        [Test]
        public void PageNum_NegativeValue_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var requestParams = new HttpRequestParams {PageNum = -1};
            });
        }

        [Test]
        public void Size_BetweenZeroAndHundred_DoesNotThrowAnyException()
        {
            Assert.DoesNotThrow(() =>
            {
                var requestParams = new HttpRequestParams { Size = 50 };
            });
        }

        [Test]
        public void Size_LessThanZero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var requestParams = new HttpRequestParams {Size = -1};
            });
        }

        [Test]
        public void Size_MoreThanHundred_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var requestParams = new HttpRequestParams {Size = 101};
            });
        }
    }
}
