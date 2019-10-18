using Encountry.Common.Models;
using Encountry.Common.Services;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace Encountry.Prism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<CountryResponse> _countries;

        public MainPageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            Title = "Encountry";
            _navigationService = navigationService;
            _apiService = apiService;

            GetCountriesAsync();
        }

        public ObservableCollection<CountryResponse> Countries {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        private async void GetCountriesAsync()
        {
            var url = App.Current.Resources["UrlAPI"].ToString();

            var connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                //IsEnabled = true;
                //IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                return;
            }

            var response = await _apiService.GetCountriesAsync(url, "rest/v2", "/all");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Problem with user data, call support.", "Accept");
                return;
            }  

            Countries = new ObservableCollection<CountryResponse>(response.Result);
        }
    }
}
