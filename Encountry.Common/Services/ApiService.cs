using Encountry.Common.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Encountry.Common.Services
{
    public class ApiService : IApiService
    {
        public async Task<bool> CheckConnectionAsync(string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return false;
            }

            return await CrossConnectivity.Current.IsRemoteReachable(url);
        }

        public async Task<Response<CountryResponse>> GetCountriesAsync(string urlBase, string servicePrefix, string controller)
        {
            try
            {
                //var request = new EmailRequest { Email = email };
                //var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<CountryResponse>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var countries = JsonConvert.DeserializeObject<CountryResponse>(result);
                return new Response<CountryResponse>
                {
                    IsSuccess = true,
                    Result = countries,
                };
            }
            catch (Exception ex)
            {
                return new Response<CountryResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
