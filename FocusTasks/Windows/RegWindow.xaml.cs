using FocusTasks.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    public partial class RegWindow : Window
    {   

        public RegWindow()
        { 
            InitializeComponent();



        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {

                string loginValue = LoginBox.Text;
            string passValue = PasswordBox.Password.ToString();
            string emailValue = EmailBox.Text;
            string fullNameValue = FullNameBox.Text;


            if (loginValue == string.Empty || passValue == string.Empty || emailValue == string.Empty || fullNameValue == string.Empty)
            {
                MessageBox.Show("Неккоректно введены данные.");
            }

            else
            {
                Users users = new Users()
                {
                    Username = loginValue,
                    Password = passValue,
                    Email = emailValue,
                    FullName = fullNameValue,
                    idRole = 2,
                    idTeam = null
                };

                FocusTasksEntities2.GetContext().Users.Add(users);
                FocusTasksEntities2.GetContext().SaveChanges();

                MessageBox.Show("Вы успешно зарегистрировались!");

                new LoginWindow().Show();
                this.Close();

            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
