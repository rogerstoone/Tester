using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void IncasationButtonClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"SavedData.txt";
            var clipboard = Convert.ToDouble(App.Current.Resources["TextTest"]);

            if (collectionSumText.Text == "" & bagNumberText.Text == "")
            {
                MessageBox.Show("Введите сумму инкасации и номер сумки");
            } 
            else if (collectionSumText.Text == "")
            {
                MessageBox.Show("Введите сумму инкасации");
            }
            else
            {
                var sum = Convert.ToDouble(collectionSumText.Text);

                if (clipboard - sum < 0)
                {
                    MessageBox.Show("Инкасация невозможна. Недостаточно средств в кассе.");
                }
                else if (bagNumberText.Text == "")
                {
                    MessageBox.Show("Инкасация невозможна. Отсутствует номер сумки.");
                }
                else
                {
                    clipboard -= sum;
                    File.AppendAllText(filePath, $"Cумма в кассе: {clipboard}. Операция: {operationName.Content} в сумку № {bagNumberText.Text} (-{collectionSumText.Text}).{Environment.NewLine}");
                    App.Current.Resources["TextTest"] = Convert.ToString(clipboard);
                    MessageBox.Show("Инкасация проведена. Операция записана в файл SavedData.txt");
                }
            }
        }


        private void ExitClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Page1.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
