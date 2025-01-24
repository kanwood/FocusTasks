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
    /// Логика взаимодействия для TeamsPage.xaml
    /// </summary>
    public partial class TeamsPage : Page
    {
        public TeamsPage()
        {
            InitializeComponent();
            DataLoad();
        }

        private void DataLoad()
        {
            DGTeams.ItemsSource = FocusTasksEntities2.GetContext().Teams.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            AdminAddTeams adminAddTeams = new AdminAddTeams();
            adminAddTeams.Show();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {

            var selectedTeam =  DGTeams.SelectedItem as Teams;

            if (selectedTeam == null)
            {
                MessageBox.Show("Выберите команду для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            FocusTasksEntities2.GetContext().Teams.Remove(selectedTeam);
            FocusTasksEntities2.GetContext().SaveChanges();

            DataLoad();



            MessageBox.Show("Команда успешно удалена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
