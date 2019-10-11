using System.Collections.Generic;


// TODO: AFINAR TIPOS DE DATOS
namespace Encountry.Common.Models
{
    public class CountryResponse
    {
        public string Name { get; set; }

        public ICollection<string> TopLevelDomain { get; set; }

        public string Alpha2Code { get; set; }

        public string Alpha3Code { get; set; }

        public long[] CallingCodes { get; set; }

        public string Capital { get; set; }

        public ICollection<string> AltSpellings { get; set; }

        public string Region { get; set; }

        public string Subregion { get; set; }


        public long Population { get; set; }


        public ICollection<decimal> Latlng { get; set; }


        public string Demonym { get; set; }


        public long Area { get; set; }


        public decimal Gini { get; set; }


        public ICollection<string> Timezones { get; set; }


        public ICollection<string> Borders { get; set; }


        public string NativeName { get; set; }


        public int NumericCode { get; set; }


        public ICollection<Currency> Currencies { get; set; }


        public ICollection<Language> Languages { get; set; }


        public Translations Translations { get; set; }


        public string Flag { get; set; }


        public ICollection<RegionalBloc> RegionalBlocs { get; set; }


        public string Cioc { get; set; }
    }
}
