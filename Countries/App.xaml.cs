using System.Collections.Generic;
using System.Windows;
using Countries.Dal;
using Countries.Dal.DataManager;
using Countries.Dal.Models.Country;
using Countries.Managers.Factories.CountriesManagerFactory;

namespace Countries
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            InitializeApp();
            base.OnStartup(e);
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