using FocusTasks.DB;
using FocusTasks.Windows;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

    public partial class AdminTasksPage : Page
    {
        List<Tasks> tasks;
        List<Tasks> filteredtasks = new List<Tasks>();
        public AdminTasksPage()
        {
            InitializeComponent();
            DataTasks();
            tasks = FocusTasksEntities2.GetContext().Tasks.ToList();
            DGTasksAdmin.ItemsSource = tasks;
        }

        private void DataTasks()
        {
            DGTasksAdmin.ItemsSource = FocusTasksEntities2.GetContext().Tasks.ToList();
        }


        private void DGTasksAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            AdminAddTasks adminAddTasks = new AdminAddTasks(null);
            adminAddTasks.Show();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {

            AdminAddTasks adminAddTasks = new AdminAddTasks((sender as Button).DataContext as Tasks);
            adminAddTasks.Show();

        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {

            var selectedTask = DGTasksAdmin.SelectedItem as Tasks;

            if (selectedTask == null)
            {
                MessageBox.Show("Выберите задачу для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            FocusTasksEntities2.GetContext().Tasks.Remove(selectedTask);
            FocusTasksEntities2.GetContext().SaveChanges();

            DataTasks();


            MessageBox.Show("Задача успешно удалена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            filteredtasks.Clear();

            string userSearch = searchTB.Text;

            if (userSearch == string.Empty)
            {
                DGTasksAdmin.ItemsSource = null;
                DGTasksAdmin.ItemsSource = tasks;
            }
            else
            {
                filteredtasks = tasks.Where(task => task.Title.Contains(userSearch) || task.Description.Contains(userSearch)).ToList();
                DGTasksAdmin.ItemsSource = filteredtasks;
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            DGTasksAdmin.ItemsSource = null;
            DGTasksAdmin.ItemsSource = tasks;
        }
    }
}
