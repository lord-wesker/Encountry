using Encountry.Common.Models;
using System.Threading.Tasks;

namespace Encountry.Common.Services
{
    public interface IApiService
    {
        Task<Response<CountryResponse>> GetCountriesAsync(
            string urlBase,
            string servicePrefix,
            string controller);

        Task<bool> CheckConnectionAsync(string url);
    }
}
