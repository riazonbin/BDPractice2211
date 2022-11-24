using BDPractice2211.ADOApp;
using Microsoft.Win32;
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

namespace BDPractice2211.Pages
{
    /// <summary>
    /// Interaction logic for MaterialCreationPage.xaml
    /// </summary>
    public partial class MaterialCreationPage : Page
    {
        public byte[] ImageMat { get; set; }

        public MaterialCreationPage()
        {
            InitializeComponent();
        }

        private void ImageSelectionButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var btnSelect = sender as Button;
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() != null)
                {
                    ImageMat = File.ReadAllBytes(dialog.FileName);
                    btnSelect.Background = Brushes.Green;
                }
            }
            catch
            {
                MessageBox.Show("Только фото!", "Ошибка");
            }
        }

        private void SaveMaterialClick(object sender, RoutedEventArgs e)
        {
            Material material = new Material
            {
                Name = tbName.Text,
                Info = tbInfo.Text,
                BytePhoto = ImageMat,
                Cost = Convert.ToInt32(tbCost.Text)
            };

            App.Connection.Material.Add(material);
            App.Connection.SaveChanges();
            MessageBox.Show("Successfully added new material!");
            NavigationService.Navigate(new MaterialCreationPage());
        }
    }
}
