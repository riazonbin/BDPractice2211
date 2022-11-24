using Microsoft.Win32;
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
using System.IO;

namespace BDPractice2211.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public byte[] ImageMat { get; set; }

        public AdminPage()
        {
            InitializeComponent();
        }

        private void GoToReceptCreationPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReceptCreationPage());
        }

        private void GoToMealCreationPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MealCreationPage());
        }

        private void GoToMaterialCreationPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MaterialCreationPage());
        }
    }
}
