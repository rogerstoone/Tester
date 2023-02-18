using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
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
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void MoveButtonClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"SavedData.txt";
            var clipboard = Convert.ToDouble(App.Current.Resources["TextTest"]);

            if (moveSumText.Text == "" & reasonList.SelectedItem == null)
            {
                MessageBox.Show("Введите сумму переноса и его причину");
            }
            else if (moveSumText.Text == "")
            {
                MessageBox.Show("Введите сумму для переноса");
            }
            else
            {
                var sum = Convert.ToDouble(moveSumText.Text);

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
                    File.AppendAllText(filePath, $"Cумма в кассе: {clipboard}. Операция: {operationName.Content}. Причина: {reasonList.Text} (-{moveSumText.Text}).{Environment.NewLine}");
                    App.Current.Resources["TextTest"] = Convert.ToString(clipboard);
                    MessageBox.Show("Перемещение проведено. Операция записана в файл SavedData.txt");
                }
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Page1.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
