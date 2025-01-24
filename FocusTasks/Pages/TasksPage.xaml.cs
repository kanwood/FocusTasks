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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FocusTasks.Pages
{
    public partial class TasksPage : Page
    {
        List<Tasks> tasks;
        List<Tasks> filteredtasks = new List<Tasks>();
        
        public TasksPage()
        {
            InitializeComponent();
            tasks = FocusTasksEntities2.GetContext().Tasks.ToList();
            DGTasksClient.ItemsSource = tasks;
        }

        private void DGTasksClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            filteredtasks.Clear();

            string userSearch = searchTB.Text;

            if (userSearch == string.Empty)
            {
                DGTasksClient.ItemsSource = null;
                DGTasksClient.ItemsSource = tasks;
            }
            else
            {
                filteredtasks = tasks.Where(task => task.Title.Contains(userSearch) || task.Description.Contains(userSearch)).ToList() ;
                DGTasksClient.ItemsSource = filteredtasks;
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            DGTasksClient.ItemsSource = null;
            DGTasksClient.ItemsSource = tasks;
        }

    }
}
