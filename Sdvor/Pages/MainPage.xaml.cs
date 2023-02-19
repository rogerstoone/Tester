using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sdvor
{
    public partial class MainPage : Page
    {
        string textFilePath = @"SavedData.txt";
        public MainPage()
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
                App.Current.Resources["TextTest"] = "0";
            }
        }

        private void MoneyEntryClick(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/Pages/MoneyEntryPage.xaml");
        }

        private void MoneyCollectionClick(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/Pages/MoneyCollectionPage.xaml");
        }

        private void MoneyMoveClick(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/Pages/MoneyMovePage.xaml");
        }

        private void OpenTextFile(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(textFilePath);
        }

        protected void NavigateToPage(string uri)
        {
            NavigationService.Navigate(new Uri(uri, UriKind.RelativeOrAbsolute));
        }
    }
}
