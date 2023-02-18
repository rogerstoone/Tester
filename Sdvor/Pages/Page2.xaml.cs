using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void SaveSumClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"SavedData.txt";
            var clipboard = Convert.ToDouble(App.Current.Resources["TextTest"]);

            if (entrySumText.Text == "")
            {
                MessageBox.Show("Введите сумму для взноса.");
            }
            else
            {
                var sum = Convert.ToDouble(entrySumText.Text);

                if (sum < 0)
                {
                    MessageBox.Show("Невозможно внести отрицательное значение.");
                }
                else
                {
                    clipboard += sum;
                    File.AppendAllText(filePath, $"Cумма в кассе: {clipboard}. Операция: {operationName.Content} (+{entrySumText.Text}).{Environment.NewLine}");
                    App.Current.Resources["TextTest"] = Convert.ToString(clipboard);
                    MessageBox.Show("Сумма внесена. Операция записана в файл SavedData.txt.");
                }
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Page1.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
