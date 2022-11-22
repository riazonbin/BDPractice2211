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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            if(tbLogin.Text != "" && tbPassword.Text != "")
            {
                var data = App.Connection.Login.Where(x => x.Password == tbPassword.Text 
                && x.Login1 == tbLogin.Text).FirstOrDefault();
                if(data != null)
                {
                    if(data.User.Role_Id == 1)
                    {
                        NavigationService.Navigate(new AdminPage());
                    }
                    else
                    {
                        NavigationService.Navigate(new UserBasketPage(data));
                    }
                }
                else
                {
                    MessageBox.Show("No such user!");
                }
            }
            else
            {
                MessageBox.Show("Uncorrect input data!");
            }
        }

        private void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
