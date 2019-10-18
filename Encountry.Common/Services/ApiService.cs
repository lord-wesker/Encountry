using Encountry.Common.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
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

        public async Task<Response<ObservableCollection<CountryResponse>>> GetCountriesAsync(string urlBase, string servicePrefix, string controller)
        {
            try
            {
                //var request = new EmailRequest { Email = email };
                //var requestString = JsonConvert.SerializeObject(request);
                //var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<ObservableCollection<CountryResponse>>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var countries = JsonConvert.DeserializeObject<ObservableCollection<CountryResponse>>(result);

                //var countries = new ObservableCollection<CountryResponse>();
                //countries.Add(countriesResp[0]);

                return new Response<ObservableCollection<CountryResponse>>
                {
                    IsSuccess = true,
                    Result = countries,
                };
            }
            catch (Exception ex)
            {
                return new Response<ObservableCollection<CountryResponse>>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
