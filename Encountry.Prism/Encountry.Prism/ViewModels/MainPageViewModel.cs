using Encountry.Common.Models;
using Encountry.Common.Services;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace Encountry.Prism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<CountryItemViewModel> _countries;
        private bool _loading;

        public MainPageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            Title = "Encountry";
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public ObservableCollection<CountryItemViewModel> Countries {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public bool Loading
        {
            get => _loading;
            set => SetProperty(ref _loading, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            GetCountriesAsync();
        }

        private async void GetCountriesAsync()
        {
            Loading = true;

            var url = App.Current.Resources["UrlAPI"].ToString();

            var connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                Loading = false;
                await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                return;
            }

            var response = await _apiService.GetCountriesAsync(url, "rest/v2", "/all");

            if (!response.IsSuccess)
            {
                Loading = false;
                await App.Current.MainPage.DisplayAlert("Error", "Problem data loading, call support.", "Accept");
                return;
            }  

            Countries = new ObservableCollection<CountryItemViewModel>(response.Result.Select(r => new CountryItemViewModel(_navigationService) {
                Alpha2Code = r.Alpha2Code,
                Alpha3Code = r.Alpha3Code,
                AltSpellings = r.AltSpellings,
                Area= r.Area,
                Borders = r.Borders,
                CallingCodes = r.CallingCodes,
                Capital = r.Capital,
                Cioc = r.Cioc,
                Currencies = r.Currencies,
                Demonym = r.Demonym,
                Flag = r.Flag,
                Gini = r.Gini,
                Languages = r.Languages,
                Latlng = r.Latlng,
                Name = r.Name,
                NativeName = r.NativeName,
                NumericCode = r.NumericCode,
                Population = r.Population,
                Region = r.Region,
                RegionalBlocs = r.RegionalBlocs,
                Subregion = r.Subregion,
                Timezones = r.Timezones,
                TopLevelDomain = r.TopLevelDomain,
                Translations = r.Translations,
            }).ToList());

            Loading = false;
        }
    }
}
