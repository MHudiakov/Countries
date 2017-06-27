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
    using System.Windows;

    /// <summary>
    /// Countries list viewModel
    /// </summary>
    internal class CountriesCollectionViewModel : INotifyPropertyChanged
    {
        public CountriesCollectionViewModel()
        {
            IEnumerable<CountryViewModel> countries = DalContainer.GetDataManager.CountryRepository.CountryCollection.Select(country => new CountryViewModel(country));
            CountryCollection = new ObservableCollection<CountryViewModel>(countries);

            CvsCountries = new CollectionViewSource();
            CvsCountries.Source = this.CountryCollection;
            CvsCountries.Filter += ApplyFilter;

            this._isHelpPopupOpen = false;
        }

        private readonly MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

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

        #region HelpPopupText

        private string _helpPopupText;

        public string HelpPopupText
        {
            get { return this._helpPopupText; }
            set
            {
                this._helpPopupText = value;
                OnPropertyChanged("HelpPopupText");
            }
        }

        #endregion

        #region TechnologiesPopupText

        private string _technologiesPopupText;

        public string TechnologiesPopupText
        {
            get { return this._technologiesPopupText; }
            set
            {
                this._technologiesPopupText = value;
                OnPropertyChanged("TechnologiesPopupText");
            }
        }

        #endregion

        #region IsHelpPopupOpen

        private bool _isHelpPopupOpen;

        public bool IsHelpPopupOpen
        {
            get { return this._isHelpPopupOpen; }
            set
            {
                this._isHelpPopupOpen = value;
                OnPropertyChanged("IsHelpPopupOpen");
            }
        }

        #endregion

        #region IsTechnologiesPopupOpen

        private bool _isTechnologiesPopupOpen;

        public bool IsTechnologiesPopupOpen
        {
            get { return this._isTechnologiesPopupOpen; }
            set
            {
                this._isTechnologiesPopupOpen = value;
                OnPropertyChanged("IsTechnologiesPopupOpen");
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

        #region ShowHelpCommand

        private BaseCommand _showHelpCommand;

        public BaseCommand ShowHelpCommand
        {
            get
            {
                return _showHelpCommand ??
                       (_showHelpCommand = new BaseCommand(obj =>
                           {
                               string help = (string)this._mainWindow.FindResource("HelpInfo");
                               this.HelpPopupText = help;
                               this.IsHelpPopupOpen = !this.IsHelpPopupOpen;
                           }
                        ));
            }
        }

        #endregion

        #region OpenSettingsCommand

        private BaseCommand _openSettingsCommand;

        public BaseCommand OpenSettingsCommand
        {
            get
            {
                return _openSettingsCommand ??
                    (_openSettingsCommand = new BaseCommand(
                         obj =>
                             {
                                 // Close popups and switch buttons in default mode
                                 // Закрываем popup-ы, 
                                 this._mainWindow.TechnologiesPopup.IsOpen = false;
                                 this._mainWindow.HelpPopup.IsOpen = false;
                                 this._mainWindow.BtHellp.IsChecked = false;
                                 this._mainWindow.BtTechnology.IsChecked = false;

                                 if (SelectedCountry == null)
                                 {
                                     MessageBox.Show("Please, select country", "Info");
                                     return;
                                 }

                                 SettingsWindow settingsWindow = new SettingsWindow();

                                 string eMessage = $"Country info. Name: {this.SelectedCountry.Name}, capital: {this.SelectedCountry.Capital}, "
                                                   + $"major currencies: {SelectedCountry.Currencies}";

                                 SettingsViewModel settingsViewModel = new SettingsViewModel(eMessage);
                                 settingsWindow.DataContext = settingsViewModel;
                                 settingsWindow.ShowDialog();
                             }));
            }
        }

        #endregion

        #region ShowTechnologiesCommand

        private BaseCommand _showTechnologiesCommand;

        public BaseCommand ShowTechnologiesCommand
        {
            get
            {
                return _showTechnologiesCommand ??
                    (_showTechnologiesCommand = new BaseCommand(obj =>
                        {
                            string technologiesInfo = (string)this._mainWindow.FindResource("TechnologiesInfo");
                            this.TechnologiesPopupText = technologiesInfo;
                            this.IsTechnologiesPopupOpen = !this.IsTechnologiesPopupOpen;
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