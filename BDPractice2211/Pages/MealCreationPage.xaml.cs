using BDPractice2211.ADOApp;
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

namespace BDPractice2211.Pages
{
    /// <summary>
    /// Логика взаимодействия для MealCreationPage.xaml
    /// </summary>
    public partial class MealCreationPage : Page
    {
        public MealCreationPage()
        {
            InitializeComponent();
            lvRecepts.ItemsSource = App.Connection.Recept.ToList();
        }

        private void ReceptSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Material> mats = new List<Material>();
            var recept = lvRecepts.SelectedItem as Recept;
            var receptMats = recept.MaterialRecept;
            foreach(var item in receptMats)
            {
                mats.Add(App.Connection.Material.FirstOrDefault(x => x.Id == item.Material_Id));
            }
            cbNeededIngridients.ItemsSource = mats;
        }

        private void MealAddButton(object sender, RoutedEventArgs e)
        {
            if(lvRecepts.SelectedIndex == -1)
            {
                MessageBox.Show("Choose recept!");
                return;
            }

            if(tbNameOfMeal.Text == "")
            {
                MessageBox.Show("Give a name to a meal!");
                return;
            }

            foreach(Material item in cbNeededIngridients.Items)
            {
                if(item.Count == 0)
                {
                    MessageBox.Show("Not enough ingridients!");
                    return;
                }
            }

            foreach(Material item in cbNeededIngridients.Items)
            {
                item.Count--;
            }

            Meal newMeal = new Meal()
            {
                Name = tbNameOfMeal.Text,
                Recept = lvRecepts.SelectedItem as Recept,
                
            };
            App.Connection.Meal.Add(newMeal);
            App.Connection.SaveChanges();

            MessageBox.Show("Successfull meal adding!");
        }
    }
}
