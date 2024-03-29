﻿using Encountry.Common.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace Encountry.Prism.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private CountryResponse _country;

        public MapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "MAP";
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
