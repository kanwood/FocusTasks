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
using System.Windows.Shapes;

namespace FocusTasks.Windows
{
    /// <summary>
    /// Логика взаимодействия для RememberPassWindow.xaml
    /// </summary>
    public partial class RememberPassWindow : Window
    {
        public RememberPassWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rememberemail.Text))
            {
                MessageBox.Show("Пожалуйста, заполните текстовое поле.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                NewPassWindow newPassWindow = new NewPassWindow(rememberemail.Text);
                newPassWindow.Show();
                this.Close();
            }
        }
    }
}
