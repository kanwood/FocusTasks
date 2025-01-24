using FocusTasks.DB;
using FocusTasks.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FocusTasks.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountsPage.xaml
    /// </summary>
    public partial class AccountsPage : Page
    {
        public AccountsPage()
        {
            InitializeComponent();
            string usernamedb = FocusTasksEntities2.GetContext().Username;
            DGAccountClient.ItemsSource = FocusTasksEntities2.GetContext().Users.Where(u => u.Username == usernamedb).ToList();


        }


        private void DGAccountClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditPass_Click(object sender, RoutedEventArgs e)
        {
            EditPassWindow editPassWindow = new EditPassWindow();
            editPassWindow.Show();
        }

        private void AddTeamClick(object sender, RoutedEventArgs e)
        {
            var items = DGAccountClient.Items;
            Users currentuser = (Users)items[0];
            if (currentuser == null)
            {
                MessageBox.Show("Выберите команду");
            }
            else
            {
                AddEditTeam addEditTeam = new AddEditTeam(currentuser);
                addEditTeam.Show();
            }
        }
    }
}
