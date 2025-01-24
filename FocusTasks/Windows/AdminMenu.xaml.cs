using FocusTasks.Pages;
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
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void Tasks_Button_Click(object sender, RoutedEventArgs e)
        {
            FrameObject.Navigate(new Uri("../Pages/AdminTasksPage.xaml", UriKind.Relative));
        }

        private void ProjectA_Click(object sender, RoutedEventArgs e)
        {
            FrameObject.Navigate(new Uri("../Pages/ProjectsPage.xaml", UriKind.Relative));
        }

        private void TeamsA_Click(object sender, RoutedEventArgs e)
        {
            FrameObject.Navigate(new Uri("../Pages/TeamsPage.xaml", UriKind.Relative));
        }

        private void AccountA_Click(object sender, RoutedEventArgs e)
        {
            FrameObject.Navigate(new Uri("../Pages/AdminAccountsPage.xaml", UriKind.Relative));
        }

        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
