using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPGGameNavigation
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : Page
    {
        public Location()
        {
            InitializeComponent();


            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();






            Uri roomImage = new Uri(MainWindow.game.CurrentRoom.ImagePath, UriKind.Relative);
            RoomImage.Source = (ImageSource)imageSourceConverter.ConvertFrom(roomImage);


            NameLabel.Content = MainWindow.game.CurrentRoom.Name;
            DescriptionLabel.Text = MainWindow.game.CurrentRoom.Description;
            //Item1Button.Content = MainWindow.game.CurrentRoom.Items[0].Name;
            //Item2Button.Content = MainWindow.game.CurrentRoom.Items[1].Name;
            NPCbutton.Content = MainWindow.game.CurrentRoom.SouvenierNpc.Name;
            MainWindow.game.CurrentRoom.Visited = true;

            Uri Item1ImageUri = new Uri(MainWindow.game.CurrentRoom.Items[0].ImagePath, UriKind.Relative);
            Item1Image.Source = (ImageSource)imageSourceConverter.ConvertFrom(Item1ImageUri);
            Uri Item2ImageUri = new Uri(MainWindow.game.CurrentRoom.Items[1].ImagePath, UriKind.Relative);
            Item2Image.Source = (ImageSource)imageSourceConverter.ConvertFrom(Item2ImageUri);






        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Start.xaml", UriKind.Relative));
        }


        private void NPCbutton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("NPCpage.xaml", UriKind.Relative));
        }

        private void ItemImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;

            string itemName = String.Empty;
            switch (image.Name)
            {
                case "Item1Image":
                    //Bedroom
                    itemName = MainWindow.game.CurrentRoom.Items[0].Name;
                    break;
                case "Item2Image":
                    //Kitchen
                    itemName = MainWindow.game.CurrentRoom.Items[1].Name;
                    break;
                default:
                    break;
            }
            if (!MainWindow.game.player.SearchInventory(itemName) && !MainWindow.game.NPCInventory.Contains(itemName))
            {
                MainWindow.game.player.InventoryAdd(itemName);

                MessageBox.Show($"Hey, you have added {itemName} to your inventory.");

            }
            else
            {
                MessageBox.Show($"Hey, you have already have or traded {itemName}");
            }
        }
    }
}
