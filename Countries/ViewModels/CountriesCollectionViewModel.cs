using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Countries.Dal;
using Countries.Dal.Models.Country;

namespace Countries.ViewModels
{
    internal class CountriesCollectionViewModel : INotifyPropertyChanged
    {
        private CountryViewModel _selectedCountry;

        public CountriesCollectionViewModel()
        {
            IEnumerable<ICountry> countries = DalContainer.GetDataManager.CountryRepository.CountryCollection;
            CountryCollection = new ObservableCollection<CountryViewModel>();
            foreach (var country in countries)
            {
                CountryViewModel countryViewModel = new CountryViewModel(country);
                CountryCollection.Add(countryViewModel);
            }
        }

        public ObservableCollection<CountryViewModel> CountryCollection { get; set; }

        public CountryViewModel SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
                OnPropertyChanged("SelectedCountry");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
