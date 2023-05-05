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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
            Setup();
        }


        public void Setup()
        {
            Room1.Content = MainWindow.game.Rooms[0].Name;
            Room2.Content = MainWindow.game.Rooms[1].Name;
            Room3.Content = MainWindow.game.Rooms[2].Name;

            if (MainWindow.game.Rooms[0].Visited)
            {
                Color newColor = Color.FromRgb(203, 161, 158);
                Room1.Background = new SolidColorBrush(newColor);
            }

            if (MainWindow.game.Rooms[1].Visited)
            {
                Color newColor = Color.FromRgb(203, 161, 158);
                Room2.Background = new SolidColorBrush(newColor);
            }

            if (MainWindow.game.Rooms[2].Visited)
            {
                Color newColor = Color.FromRgb(203, 161, 158);
                Room3.Background = new SolidColorBrush(newColor);
            }

            string inventory = String.Empty;
            foreach (string item in MainWindow.game.player.Inventory)
            {
                inventory += $"{item}\n";
            }

            CurrentInventory.Text = inventory;



            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();


            foreach (Item item in MainWindow.game.Items)
            {
                Uri itemImageUrl = new Uri(item.ImagePath, UriKind.Relative);


                //Find the image on the page by its name property
                Image image = (Image)this.FindName(item.ID);
                image.Source = (ImageSource)imageSourceConverter.ConvertFrom(itemImageUrl);

                if (MainWindow.game.player.SearchInventory(item.Name))
                {
                    image.Opacity = 1;
                }
                else
                {
                    image.Opacity = 0.2;
                }

            }




        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "Room1":
                    //Bedroom
                    MainWindow.game.CurrentRoom = MainWindow.game.Rooms[0];
                    break;
                case "Room2":
                    //Kitchen
                    MainWindow.game.CurrentRoom = MainWindow.game.Rooms[1];
                    break;
                case "Room3":
                    //Living Room
                    MainWindow.game.CurrentRoom = MainWindow.game.Rooms[2];
                    break;
                default:
                    break;
            }

            //MessageBox.Show(button.Name);
            NavigationService.Navigate(new Uri("Location.xaml", UriKind.Relative));
        }
    }
}
