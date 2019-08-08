using System.Threading.Tasks;
using Svrf.Models.Http;

namespace Svrf.Api.Interfaces
{
    internal interface IMediaApi
    {
        Task<SingleMediaResponse> GetByIdAsync(int id);
        Task<SingleMediaResponse> GetByIdAsync(string id);
        Task<MultipleMediaResponse> GetTrendingAsync(MediaRequestParams mediaRequestParams = null);
        Task<MultipleMediaResponse> SearchAsync(string query, MediaRequestParams mediaRequestParams = null);
    }
}
