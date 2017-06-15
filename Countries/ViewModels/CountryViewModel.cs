using System.ComponentModel;
using System.Runtime.CompilerServices;
using Countries.Dal.Models.Country;

namespace Countries.ViewModels
{
    internal class CountryViewModel : INotifyPropertyChanged
    {
        private readonly ICountry _country;

        public CountryViewModel(ICountry country)
        {
            _country = country;
        }

        [DisplayName("Name")]
        public string Name => _country.Name;

        [DisplayName("Capital")]
        public string Capital => _country.Capital;

        [DisplayName("Currencies")]
        public string Currencies => string.Join(",", _country.CurrencyCollection);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}