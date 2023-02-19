using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Sdvor
{
    public partial class MoneyCollectionPage : Page
    {
        public MoneyCollectionPage()
        {
            InitializeComponent();
        }

        private void IncasationButtonClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"SavedData.txt";
            var clipboard = double.Parse((string)App.Current.Resources["TextTest"]);

            if (string.IsNullOrEmpty(collectionSumText.Text) & string.IsNullOrEmpty(bagNumberText.Text))
            {
                MessageBox.Show("Введите сумму инкасации и номер сумки");
            } 
            else if (string.IsNullOrEmpty(collectionSumText.Text))
            {
                MessageBox.Show("Введите сумму инкасации");
            }
            else
            {
                var sum = double.Parse(collectionSumText.Text, CultureInfo.InvariantCulture);
                string sumResult = string.Format("{0:f2}", sum);

                if (clipboard - sum < 0)
                {
                    MessageBox.Show("Инкасация невозможна. Недостаточно средств в кассе.");
                }
                else if (string.IsNullOrEmpty(bagNumberText.Text))
                {
                    MessageBox.Show("Инкасация невозможна. Отсутствует номер сумки.");
                }
                else
                {
                    clipboard -= sum;
                    string clipboardResult = string.Format("{0:f2}", clipboard);
                    File.AppendAllText(filePath, $"Cумма в кассе: {clipboardResult}. Операция: {operationName.Content} в сумку № {bagNumberText.Text} (-{sumResult}).{Environment.NewLine}");
                    App.Current.Resources["TextTest"] = clipboardResult;
                    MessageBox.Show("Инкасация проведена. Операция записана в файл SavedData.txt");
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

        private void BagNumberInputFilter(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
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
