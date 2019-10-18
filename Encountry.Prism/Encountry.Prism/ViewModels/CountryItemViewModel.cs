using System;
using Encountry.Common.Helpers;
using Encountry.Common.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Encountry.Prism.ViewModels
{
    public class CountryItemViewModel : CountryResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCountryCommand;
        private DelegateCommand _seeCountryOnMapCommand;

        public CountryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectCountryCommand => _selectCountryCommand ?? (_selectCountryCommand = new DelegateCommand(SelectCountry));

        public DelegateCommand SeeCountryOnMapCommand => _seeCountryOnMapCommand ?? (_seeCountryOnMapCommand = new DelegateCommand(SeeCountryOnMap));

        private async void SelectCountry()
        {
            var parameters = new NavigationParameters()
            {
                { "country", this }
            };

            await _navigationService.NavigateAsync("CountryPage", parameters);
        }

        private async void SeeCountryOnMap()
        {
            var parameters = new NavigationParameters()
            {
                { "country", this }
            };

            Settings.Latitude = this.Latlng[0];
            Settings.Length = this.Latlng[1];
            Settings.CountryLabel = this.Name;
            Settings.CountryArea = Convert.ToDouble(this.Area.Replace(".", ","));

            await _navigationService.NavigateAsync("MapPage", parameters);
        }
    }
}
