using System.Windows;
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
            DataContext = new CountriesCollectionViewModel();
        }
    }
}