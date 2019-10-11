using Prism.Navigation;

namespace Encountry.Prism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Encountry";
            _navigationService = navigationService;
        }
    }
}
