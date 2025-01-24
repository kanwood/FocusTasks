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
    /// Логика взаимодействия для AdminAddTeams.xaml
    /// </summary>
    public partial class AdminAddTeams : Window
    {

        private Teams _currentTeams = new Teams();
        public AdminAddTeams()
        {
            InitializeComponent();
            DataContext = _currentTeams;
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTeams.idTeam == 0)
                FocusTasksEntities2.GetContext().Teams.Add(_currentTeams);
            FocusTasksEntities2.GetContext().SaveChanges();
            MessageBox.Show("Команда успешно создана");
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
