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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow x = new MainWindow();    
            x.Show();
            this.Close();
        }

        private void RememberButton_Click(object sender, RoutedEventArgs e)
        {
            RememberPassWindow rememberPassWindow = new RememberPassWindow();
            rememberPassWindow.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            string loginValue = LoginBox.Text;
            string passValue = PasswordBox.Password.ToString();

            List<Users> foundUser = FocusTasksEntities2.GetContext().Users.Where(u => u.Username == loginValue && u.Password == passValue).ToList();
            
            if (foundUser.Count > 0)
            {
                FocusTasksEntities2.GetContext().Username = foundUser[0].Username;
                if (foundUser[0].idRole == 1)
                {
                    AdminMenu menu = new AdminMenu();
                    menu.Show();
                    this.Close();
                }
                else
                {
                    ClientMenu menu = new ClientMenu();
                    menu.Show();
                    this.Close();
                }
            }

            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }


        }
    }
}
