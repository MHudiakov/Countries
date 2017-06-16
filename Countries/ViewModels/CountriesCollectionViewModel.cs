using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using Countries.Commands;
using Countries.Dal;

namespace Countries.ViewModels
{
    internal class CountriesCollectionViewModel : INotifyPropertyChanged
    {
        public CountriesCollectionViewModel()
        {

            IEnumerable<CountryViewModel> countries = DalContainer.GetDataManager.CountryRepository.CountryCollection.Select(country => new CountryViewModel(country));
            CountryCollection = new ObservableCollection<CountryViewModel>(countries);

            CvsCountries = new CollectionViewSource();
            CvsCountries.Source = this.CountryCollection;
            CvsCountries.Filter += ApplyFilter;
        }

        public ObservableCollection<CountryViewModel> CountryCollection { get; set; }

        internal CollectionViewSource CvsCountries { get; set; }

        public ICollectionView AllCountries => CvsCountries.View;

        #region SelectedCountry

        private CountryViewModel _selectedCountry;

        public CountryViewModel SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
                OnPropertyChanged("SelectedCountry");
            }
        }

        #endregion

        #region CountryFilterPattern

        private string _countryFilterPattern;

        public string CountryFilterPattern
        {
            get { return _countryFilterPattern; }
            set
            {
                _countryFilterPattern = value;
                OnPropertyChanged("CountryFilterPattern");
            }
        }

        #endregion

        #region CapitalFilterPattern

        private string _capitalFilterPattern;

        public string CapitalFilterPattern
        {
            get { return _capitalFilterPattern; }
            set
            {
                _capitalFilterPattern = value;
                OnPropertyChanged("CapitalFilterPattern");
            }
        }

        #endregion

        #region Filter

        private void OnFilterChanged()
        {
            CvsCountries.View.Refresh();
        }

        private void ApplyFilter(object sender, FilterEventArgs e)
        {
            CountryViewModel countryViewModel = (CountryViewModel)e.Item;

            if (string.IsNullOrWhiteSpace(this.CountryFilterPattern))
                this.CountryFilterPattern = string.Empty;

            if (string.IsNullOrWhiteSpace(this.CapitalFilterPattern))
                this.CapitalFilterPattern = string.Empty;

            e.Accepted = countryViewModel.Name.ToLower().Contains(CountryFilterPattern.ToLower()) &&
                         countryViewModel.Capital.ToLower().Contains(CapitalFilterPattern.ToLower());
        }

        #endregion

        #region FilterCommand

        private BaseCommand _filterCommand;

        public BaseCommand FilterCommand
        {
            get
            {
                return _filterCommand ??
                       (_filterCommand = new BaseCommand(obj =>
                       {
                           OnFilterChanged();
                       }));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}