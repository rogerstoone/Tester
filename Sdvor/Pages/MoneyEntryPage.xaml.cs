using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Sdvor
{
    public partial class MoneyEntryPage : Page
    {
        public MoneyEntryPage()
        {
            InitializeComponent();
        }

        private void SaveSumClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"SavedData.txt";
            var clipboard = double.Parse((string)App.Current.Resources["TextTest"]);

            if (string.IsNullOrEmpty(entrySumText.Text))
            {
                MessageBox.Show("Введите сумму для взноса.");
            }
            else
            {
                var sum = double.Parse(entrySumText.Text, CultureInfo.InvariantCulture);
                string sumResult = string.Format("{0:f2}", sum);

                if (sum < 0)
                {
                    MessageBox.Show("Невозможно внести отрицательное значение.");
                }
                else
                {
                    clipboard += sum;
                    string clipboardResult = string.Format("{0:f2}", clipboard);
                    File.AppendAllText(filePath, $"Cумма в кассе: {clipboardResult}. Операция: {operationName.Content} (+{sumResult}).{Environment.NewLine}");
                    App.Current.Resources["TextTest"] = clipboardResult;
                    MessageBox.Show("Сумма внесена. Операция записана в файл SavedData.txt.");
                }
            }
        }

        private void InputFilter(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") 
                && (!(sender as TextBox).Text.Contains("."))
                && ((sender as TextBox).Text.Length != 0)))
            {
                e.Handled = true; 
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
