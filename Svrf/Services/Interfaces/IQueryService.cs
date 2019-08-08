using System.Collections.Generic;

namespace Svrf.Services.Interfaces
{
    internal interface IQueryService
    {
        string Build(IDictionary<string, object> requestParams);
    }
}
