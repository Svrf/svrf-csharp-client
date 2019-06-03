using System;
using NUnit.Framework;
using Svrf.Models;
using Svrf.Storage;

namespace Svrf.Tests.Unit.Storage
{
    [TestFixture]
    public class MemoryTokenStorageTest
    {
        public ITokenStorage TokenStorage { get; set; }

        private readonly AppTokenInfo _appTokenInfo = new AppTokenInfo("token", DateTime.Now);

        [SetUp]
        public void Init()
        {
            TokenStorage = new MemoryTokenStorage();
        }

        [Test]
        public void Get_ReturnsNull()
        {
            var appTokenInfo = TokenStorage.Get();

            Assert.IsNull(appTokenInfo);
        }

        [Test]
        public void Get_ReturnsAppTokenInfo()
        {
            TokenStorage.Set(_appTokenInfo);
            var appTokenInfo = TokenStorage.Get();

            Assert.AreEqual(_appTokenInfo, appTokenInfo);
        }

        [Test]
        public void Clear_AppTokenInfo()
        {
            TokenStorage.Set(_appTokenInfo);
            TokenStorage.Clear();

            var appTokenInfo = TokenStorage.Get();

            Assert.IsNull(appTokenInfo);
        }
    }
}
