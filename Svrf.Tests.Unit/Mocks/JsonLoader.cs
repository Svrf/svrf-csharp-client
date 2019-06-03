using System.IO;
using NUnit.Framework;

namespace Svrf.Tests.Unit.Mocks
{
    internal static class JsonLoader
    {
        internal static string Load(string filename)
        {
            string json;

            var path = $"{TestContext.CurrentContext.TestDirectory}\\..\\..\\Mocks\\Json\\{filename}";

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }

        internal static string LoadMediaJson() => Load("Media.json");
        internal static string LoadSingleMediaApiResponse() => Load("SingleMediaApiResponse.json");
        internal static string LoadMultipleMediaApiResponse() => Load("MultipleMediaApiResponse.json");
    }
}
