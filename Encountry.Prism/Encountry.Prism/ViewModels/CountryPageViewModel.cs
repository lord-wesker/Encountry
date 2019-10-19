﻿using Encountry.Common.Models;
using Prism.Navigation;

namespace Encountry.Prism.ViewModels
{
    public class CountryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private CountryResponse _country;

        public CountryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            Title = "COUNTRY";
        }

        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("country"))
            {
                Country = parameters.GetValue<CountryResponse>("country");
                Title = Country.Name;
            }
        }
    }
}
