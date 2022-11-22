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
using BDPractice2211.ADOApp;

namespace BDPractice2211.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrateButtonClick(object sender, RoutedEventArgs e)
        {
            if(tbLogin.Text != "" && tbPassword.Text != "" && tbName.Text != "" && tbRole.Text != "")
            {
                User newUser = new User()
                {
                    Name = tbName.Text,
                    Role_Id = Convert.ToInt32(tbRole.Text)
                };
                Login newLogin = new Login()
                {
                    Login1 = tbLogin.Text,
                    Password = tbPassword.Text
                };

                newUser.Login.Add(newLogin);

                App.Connection.User.Add(newUser);
                App.Connection.SaveChanges();
                MessageBox.Show("Registration is successfull!");
            }
            else
            {
                MessageBox.Show("Incorrect data!");
            }
        }
    }
}
