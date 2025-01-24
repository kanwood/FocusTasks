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
    public partial class EditUsers : Window
    {

        private Users _currentuser = new Users();
        public EditUsers(Users selecteduser)
        {
            InitializeComponent();

            if (selecteduser != null)
                _currentuser = selecteduser;
            DataContext = _currentuser;

        }


        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentuser.idUser == 0)
                FocusTasksEntities2.GetContext().Users.Add(_currentuser);
            FocusTasksEntities2.GetContext().SaveChanges();
            MessageBox.Show("Редактирование пользователя произведена!");
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
