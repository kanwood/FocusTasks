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
    /// Логика взаимодействия для ClientMenu.xaml
    /// </summary>
    public partial class ClientMenu : Window
    {
        public ClientMenu()
        {
            InitializeComponent();
           
        }


        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Tasks_Button_Click(object sender, RoutedEventArgs e)
        {
            FrameObject.Navigate(new Uri("../Pages/TasksPage.xaml", UriKind.Relative));
        }

        private void Project_Click(object sender, RoutedEventArgs e)
        {
            FrameObject.Navigate(new Uri("../Pages/ProjectsPage.xaml", UriKind.Relative));
        }

        private void Teams_Click(object sender, RoutedEventArgs e)
        {
            FrameObject.Navigate(new Uri("../Pages/TeamsPage.xaml", UriKind.Relative));
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            FrameObject.Navigate(new Uri("../Pages/AccountsPage.xaml", UriKind.Relative));
        }

    }
}
