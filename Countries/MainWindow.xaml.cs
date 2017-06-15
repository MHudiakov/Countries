using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Countries.Dal;
using Countries.Dal.DataManager;
using Countries.Dal.Models.Country;
using Countries.Managers.CountriesManager;
using Countries.Managers.Factories.CountriesManagerFactory;
using Countries.ViewModels;

namespace Countries
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeApp();
            DataContext = new CountriesCollectionViewModel();
        }

        private void InitializeApp()
        {
            IDataManager dataManager = new DataManager();
            DalContainer.RegisterDataManger(dataManager);
            AbstractCountriesManagerFactory countriesManagerFactory = new CountriesManagerFactory();
            var countriesManager = countriesManagerFactory.CreateCountriesManager();
            DalContainer.GetDataManager.CountryRepository.CountryCollection = (IList<ICountry>)countriesManager.GetCountries();
        }
    }
}