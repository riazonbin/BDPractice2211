using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace BDPractice2211.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReceptCreationPage.xaml
    /// </summary>
    public partial class ReceptCreationPage : Page
    {
        public byte[] ReceptPhoto { get; set; }

        public ReceptCreationPage()
        {
            InitializeComponent();
            cbIngridients.ItemsSource = App.Connection.Material.ToList();
        }

        private void AddIngridientBtn(object sender, RoutedEventArgs e)
        {
            if(cbIngridients.SelectedIndex == -1)
            {
                MessageBox.Show("No chosen ingridient!");
                return;
            }
            if(cbTotalIngridients.Items.Contains(cbIngridients.SelectedItem))
            {
                MessageBox.Show("Already chosen such ingridient!");
                return;
            }
            cbTotalIngridients.Items.Add(cbIngridients.SelectedItem);
            MessageBox.Show("Successfully chosen ingridient!");
        }

        private void SaveReceptButton(object sender, RoutedEventArgs e)
        {
            if(cbTotalIngridients.Items.Count == 0)
            {
                MessageBox.Show("Choose ingridients first!");
                return;
            }

            if(ReceptPhoto is null)
            {
                MessageBox.Show("Choose photo!");
                return;
            }
            if(tbNameOfIngridient.Text == "")
            {
                MessageBox.Show("Give a name to ingridient!");
                return;
            }

            Recept newRecept = new Recept()
            {
                Recept_Photo = ReceptPhoto,
                Info = tbNameOfIngridient.Text
            };

            App.Connection.Recept.Add(newRecept);

            foreach (Material item in cbTotalIngridients.Items)
            {
                App.Connection.MaterialRecept.Add(new MaterialRecept()
                {
                    Material = item, 
                    Recept = newRecept
                });
            }

            App.Connection.SaveChanges();
            MessageBox.Show("Successfully added new recept!");

        }

        private void ImageSelectionButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var btnSelect = sender as Button;
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() != null)
                {
                    ReceptPhoto = File.ReadAllBytes(dialog.FileName);
                    btnSelect.Background = Brushes.Green;
                }
            }
            catch
            {
                MessageBox.Show("Только фото!", "Ошибка");
            }
        }
    }
}
