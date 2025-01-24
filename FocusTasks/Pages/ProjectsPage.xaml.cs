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
    /// Логика взаимодействия для ProjectsPage.xaml
    /// </summary>
    public partial class ProjectsPage : Page
    {

        public ProjectsPage()
        {
            InitializeComponent();
            DataLoad();
        }

        private void DataLoad()
        {
            DGProject.ItemsSource = FocusTasksEntities2.GetContext().Projects.ToList();
        }

        private void DGProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            AdminAddProjects adminAddProjects = new AdminAddProjects();
            adminAddProjects.Show();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {

            var selectedProject = DGProject.SelectedItem as Projects;

            if (selectedProject == null)
            {
                MessageBox.Show("Выберите проект для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            FocusTasksEntities2.GetContext().Projects.Remove(selectedProject);
            FocusTasksEntities2.GetContext().SaveChanges();

            DataLoad();



            MessageBox.Show("Проект успешно удален.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
