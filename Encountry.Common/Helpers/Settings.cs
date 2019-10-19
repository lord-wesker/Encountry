using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace Encountry.Common.Helpers
{
    public static class Settings
    {
        private const string _countries = "countries";
        private static string _latitude = "latitude";
        private static string _length = "length";
        private static string _countryLabel = "country";
        private static string _countryArea = "area";

        private static readonly string _stringDefault = string.Empty;

        private static ISettings AppSettings => CrossSettings.Current;


        public static string Latitude {
            get => AppSettings.GetValueOrDefault(_latitude, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_latitude, value);
        }

        public static string Length
        {
            get => AppSettings.GetValueOrDefault(_length, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_length, value);
        }

        public static string CountryLabel
        {
            get => AppSettings.GetValueOrDefault(_countryLabel, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_countryLabel, value);
        }

        public static string CountryArea
        {
            get => AppSettings.GetValueOrDefault(_countryArea, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_countryArea, value);
        }

        public static string Countries
        {
            get => AppSettings.GetValueOrDefault(_countries, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_countries, value);
        }

        public static double DoubleFormat(string strNumber) => Convert.ToDouble(strNumber.Replace(".", ","));

    }
}
