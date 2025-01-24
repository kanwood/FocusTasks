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
    /// Логика взаимодействия для AdminAddProjects.xaml
    /// </summary>
    public partial class AdminAddProjects : Window
    {

        private Projects _currentProjects = new Projects();
        public AdminAddProjects()
        {
            InitializeComponent();
            DataContext = _currentProjects;
        }

        private void DataLoad()
        {
            
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            if (_currentProjects.idProject == 0)
            FocusTasksEntities2.GetContext().Projects.Add(_currentProjects);
            FocusTasksEntities2.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно обновлены!");
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
