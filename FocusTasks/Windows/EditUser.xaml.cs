using FocusTasks.DB;
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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private Users _currentuser;
        public EditUser(Users selectedUser)
        {
            InitializeComponent();
            LoadData();

            if (selectedUser != null)
                _currentuser = selectedUser;
            DataContext = _currentuser;
        }

        private void LoadData()
        {
            RoleCB.ItemsSource = FocusTasksEntities2.GetContext().Roles.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (_currentuser.idRole == 0)
                FocusTasksEntities2.GetContext().Users.Add(_currentuser);
            FocusTasksEntities2.GetContext().SaveChanges();
            MessageBox.Show("Роль изменена");
        }

        private void RoleCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
