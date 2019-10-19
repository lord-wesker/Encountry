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
            var lat = Settings.DoubleFormat(Settings.Latitude);
            var len = Settings.DoubleFormat(Settings.Length);
            var area = Settings.DoubleFormat(Settings.CountryArea);

            var position = new Position(lat, len);

            EncountryMap.Pins.Add(new Pin()
            {
                Position = position,
                Label = Settings.CountryLabel,
            });

            EncountryMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    position,
                    Distance.FromKilometers(Math.Sqrt(area))));
        }
    }
}
