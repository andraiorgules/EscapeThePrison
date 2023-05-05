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
    /// Interaction logic for NPCpage.xaml
    /// </summary>
    public partial class NPCpage : Page
    {
        public NPCpage()
        {
            InitializeComponent();
            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            NPCname.Content = MainWindow.game.CurrentRoom.SouvenierNpc.Name;
            //StoreButton.Content = MainWindow.game.CurrentRoom.SouvenierNpc.NPCItem.Name;
            Uri NPCItemImageUri = new Uri(MainWindow.game.CurrentRoom.SouvenierNpc.NPCItem.ImagePath, UriKind.Relative);
            NPCItemImage.Source = (ImageSource)imageSourceConverter.ConvertFrom(NPCItemImageUri);

        }

        private void LeaveStore_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Location.xaml", UriKind.Relative));
        }


        private void NPCItemImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string itemName = MainWindow.game.CurrentRoom.SouvenierNpc.NPCItem.Name;
            string requiredItemName = MainWindow.game.CurrentRoom.SouvenierNpc.RequiredItem.Name;
            if (MainWindow.game.player.SearchInventory(requiredItemName))
            {
                if (!MainWindow.game.player.SearchInventory(itemName))
                {
                    MainWindow.game.player.Trade(itemName, requiredItemName);
                    MainWindow.game.NPCInventory.Add(requiredItemName);
                    MessageBox.Show($"You have traded {requiredItemName} for {itemName}");

                }
            }
            else
            {
                MessageBox.Show($"You do not have {requiredItemName}");
            }
        }
    }
}
