using Encountry.Common.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Encountry.Prism.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            ShowCountryOnMap();
        }

        private void ShowCountryOnMap()
        {
            var position = new Position(Settings.Latitude, Settings.Length);

            EncountryMap.Pins.Add(new Pin()
            {
                Position = position,
                Label = Settings.CountryLabel,
            });

            EncountryMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    position,
                    Distance.FromKilometers(Math.Sqrt(Settings.CountryArea))));
        }
    }
}
