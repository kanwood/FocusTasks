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
    /// Логика взаимодействия для AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Window
    {
        public AllUsers()
        {
            InitializeComponent();
            DataLoad();
        }

        private void DataLoad()
        {
            DGAllUser.ItemsSource = FocusTasksEntities2.GetContext().Users.ToList();
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {

            var selectedUser = DGAllUser.SelectedItem as Users;

            if (selectedUser == null)
            {
                MessageBox.Show("Выберите задачу для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            FocusTasksEntities2.GetContext().Users.Remove(selectedUser);
            FocusTasksEntities2.GetContext().SaveChanges();

            DataLoad();


            MessageBox.Show("Задача успешно удалена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditPass_Click(object sender, RoutedEventArgs e)
        {
            EditUsers editUsers = new EditUsers((sender as Button).DataContext as Users);
            editUsers.Show();
        }

        private void EditRole_Click(object sender, RoutedEventArgs e)
        {
            var selectedUserItem = DGAllUser.SelectedItem;
            if (selectedUserItem == null)
            {
                MessageBox.Show("Выберите команду");
            }
            else
            {
                Users selectedUser = selectedUserItem as Users;
                EditUser edituser = new EditUser(selectedUser);
                edituser.Show();
            }
        }

        private void DGAccountAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
