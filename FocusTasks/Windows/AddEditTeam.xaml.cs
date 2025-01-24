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
    /// Логика взаимодействия для AddEditTeam.xaml
    /// </summary>
    public partial class AddEditTeam : Window
    {
        private Users _currentuser;
        public AddEditTeam(Users selectedUser)
        {
            InitializeComponent();
            LoadData();
            
            if(selectedUser != null)
                _currentuser = selectedUser;
            DataContext = _currentuser;
        }

        private void LoadData()
        {
            TeamCB.ItemsSource = FocusTasksEntities2.GetContext().Teams.ToList();
        }

        private void AddTeam_Click(object sender, RoutedEventArgs e)
        {
            string selectedteam = TeamCB.SelectedItem.ToString();
            MessageBox.Show(selectedteam);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
