using System.Collections.Generic;
using System.Threading.Tasks;

namespace Svrf.Http
{
    internal interface IHttpClient
    {
        Task<T> GetAsync<T>(string uri, IDictionary<string, object> requestParams = null);
        Task<T> PostAsync<T>(string uri, object body);
    }
}
