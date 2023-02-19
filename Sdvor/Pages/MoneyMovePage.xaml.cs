using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Sdvor
{
    public partial class MoneyMovePage : Page
    {
        public MoneyMovePage()
        {
            InitializeComponent();
        }

        private void MoveButtonClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"SavedData.txt";
            var clipboard = double.Parse((string)App.Current.Resources["TextTest"]);

            if (string.IsNullOrEmpty(moveSumText.Text) & reasonList.SelectedItem == null)
            {
                MessageBox.Show("Введите сумму переноса и его причину");
            }
            else if (string.IsNullOrEmpty(moveSumText.Text))
            {
                MessageBox.Show("Введите сумму для переноса");
            }
            else
            {
                var sum = double.Parse(moveSumText.Text, CultureInfo.InvariantCulture);
                string sumResult = string.Format("{0:f2}", sum);

                if (clipboard - sum < 0)
                {
                    MessageBox.Show("Перенос невозможен. Недостаточно средств в кассе.");
                }
                else if (reasonList.SelectedItem == null)
                {
                    MessageBox.Show("Перенос невозможен. Не выбрана причина.");
                }
                else
                {
                    clipboard -= sum;
                    string clipboardResult = string.Format("{0:f2}", clipboard);
                    File.AppendAllText(filePath, $"Cумма в кассе: {clipboardResult}. Операция: {operationName.Content}. Причина: {reasonList.Text} (-{sumResult}).{Environment.NewLine}");
                    App.Current.Resources["TextTest"] = clipboardResult;
                    MessageBox.Show("Перемещение проведено. Операция записана в файл SavedData.txt");
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
