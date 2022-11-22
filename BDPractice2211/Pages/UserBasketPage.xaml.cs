using BDPractice2211.ADOApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BDPractice2211.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserBasketPage.xaml
    /// </summary>
    public partial class UserBasketPage : Page
    {
        public Login login;
        public List<Basket> UsersBasket { get; set; }
        public List<Material> materialsList = new List<Material>();

        public UserBasketPage(Login login)
        {
            this.login = login;
            InitializeComponent();
            ListOfMaterials.ItemsSource = App.Connection.Material.ToList();
            UsersBasket = App.Connection.Basket.Where(x => x.User_Id == login.User_Id).ToList();
            foreach (var item in UsersBasket)
            {
                materialsList.Add(App.Connection.Material.Where(x => x.Id == item.Material_Id).FirstOrDefault());
            }
            UsersMaterials.ItemsSource = materialsList;
        }

        private void ListOfMaterialsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mat = ListOfMaterials.SelectedItem as Material;

            var newBasket = new Basket
            {
                Material = mat,
                User_Id = login.User_Id,
            };

            App.Connection.Basket.Add(newBasket);
            App.Connection.SaveChanges();

            materialsList.Add(mat);
            UsersMaterials.Items.Refresh();
        }
    }
}
