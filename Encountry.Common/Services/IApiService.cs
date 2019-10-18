using Encountry.Common.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Encountry.Common.Services
{
    public interface IApiService
    {
        Task<Response<ObservableCollection<CountryResponse>>> GetCountriesAsync(
            string urlBase,
            string servicePrefix,
            string controller);

        Task<bool> CheckConnectionAsync(string url);
    }
}
