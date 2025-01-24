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
    /// Логика взаимодействия для NewPassWindow.xaml
    /// </summary>
    public partial class NewPassWindow : Window
    {
        private string userEmail;
        string letters = "abcdefgh";
        string numbers = "0123456789";
        string generatedPassword;
        public NewPassWindow(string email)
        {
            InitializeComponent();

            userEmail = email;

            Random rnd = new Random();

            for (int x = 0; x < 10; x++)
            {
                if (rnd.Next(1, 3) == 1)
                {
                    generatedPassword += letters[rnd.Next(0, letters.Length)];
                }

                else
                {
                    generatedPassword += numbers[rnd.Next(0, numbers.Length)];
                }
            }

            newPasswordTB.Text = generatedPassword;
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string password = newPasswordTB.Text;

            List<Users> foundUserList = FocusTasksEntities2.GetContext().Users.Where(u => u.Email == userEmail).ToList();
            

            if (foundUserList.Count > 0)
            {
                foundUserList[0].Password = newPasswordTB.Text;
                FocusTasksEntities2.GetContext().SaveChanges();
            }
            this.Close();
        }
    }
}
