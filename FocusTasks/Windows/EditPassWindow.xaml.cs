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
    /// Логика взаимодействия для EditPassWindow.xaml
    /// </summary>
    public partial class EditPassWindow : Window
    {
        public EditPassWindow()
        {
            InitializeComponent();

        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string password = EditPass.Text;
            string usernamedb = FocusTasksEntities2.GetContext().Username;

            List<Users> foundUserList = FocusTasksEntities2.GetContext().Users.Where(b => b.Username == usernamedb).ToList();


            if (foundUserList.Count > 0)
            {
                foundUserList[0].Password = EditPass.Text;
                FocusTasksEntities2.GetContext().SaveChanges();
            }
            this.Close();

        }

        private void EditPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
