using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        private static readonly List<CultureInfo> s_Languages = new List<CultureInfo>();

        public static List<CultureInfo> Languages => s_Languages;

        public App()
        {
            s_Languages.Clear();
            s_Languages.Add(new CultureInfo("en-US")); //Нейтральная культура для этого проекта
            s_Languages.Add(new CultureInfo("ru-RU"));
        }

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

        //Евент для оповещения всех окон приложения
        public static event EventHandler LanguageChanged;

        public static CultureInfo Language
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                //1. Меняем язык приложения:
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                //2. Создаём ResourceDictionary для новой культуры
                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "ru-RU":
                        dict.Source = new Uri(String.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative);
                        break;
                    default:
                        dict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                        break;
                }

                //3. Находим старую ResourceDictionary и удаляем его и добавляем новую ResourceDictionary
                ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                    where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
                    select d).First();
                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }

                //4. Вызываем евент для оповещения всех окон.
            //    LanguageChanged(Application.Current, new EventArgs());
            }
        }
    }
}