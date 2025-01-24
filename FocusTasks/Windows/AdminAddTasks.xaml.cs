using FocusTasks.DB;
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
    public partial class AdminAddTasks : Window
    {
        private Tasks _currenttasks = new Tasks();

        public AdminAddTasks(Tasks selectedTasks)
        {
            InitializeComponent();
            LoadData();

            if (selectedTasks != null)
                _currenttasks = selectedTasks;
            DataContext = _currenttasks;

            
        }

        private void LoadData()
        {
            StatusCB.ItemsSource = FocusTasksEntities2.GetContext().Statuses.ToList();
            ProjectCB.ItemsSource = FocusTasksEntities2.GetContext().Projects.ToList();
            TeamCB.ItemsSource = FocusTasksEntities2.GetContext().Teams.ToList();
            UserCB.ItemsSource = FocusTasksEntities2.GetContext().Users.ToList();

        }


        private void AddTasks_Click(object sender, RoutedEventArgs e)
        {
            if (_currenttasks.idTask == 0)
                FocusTasksEntities2.GetContext().Tasks.Add(_currenttasks);
            FocusTasksEntities2.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно обновлены!");
            this.Close();
            

        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
