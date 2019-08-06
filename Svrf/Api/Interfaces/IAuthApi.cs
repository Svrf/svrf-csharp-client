using System.Threading.Tasks;

namespace Svrf.Api.Interfaces
{
    internal interface IAuthApi
    {
        Task AuthenticateAsync();
    }
}
