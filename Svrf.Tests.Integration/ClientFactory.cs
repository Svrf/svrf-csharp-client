using System;
using Svrf.Models;

namespace Svrf.Tests.Integration
{
    internal static class ClientFactory
    {
        private static readonly string ApiKey;

        static ClientFactory()
        {
            ApiKey = Environment.GetEnvironmentVariable("SVRF_TEST_API_KEY");
            if (ApiKey == null)
            {
                throw new Exception("The SVRF_TEST_API_KEY env variable is required for running integration tests");
            }
        }

        internal static SvrfClient GetClient(ApiOptions options = null)
        {
            var client = new SvrfClient(ApiKey, options);
            return client;
        }
    }
}
