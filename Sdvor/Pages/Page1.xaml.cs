using System;
using System.Collections.Generic;
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

namespace Sdvor
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            var clipboard = App.Current.Resources["TextTest"];
            if (clipboard != null)
            {
                moneyText.Text = (string)clipboard;
            } 
            else
            {
                moneyText.Text = "0";
            }
        }

        private void MoneyEntryClick(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/Pages/Page2.xaml");
        }

        private void MoneyCollectionClick(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/Pages/Page3.xaml");
        }

        private void MoneyMoveClick(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/Pages/Page4.xaml");
        }

        public void NavigateToPage(string uri)
        {
            NavigationService.Navigate(new Uri(uri, UriKind.RelativeOrAbsolute));
        }
    }

    
}
