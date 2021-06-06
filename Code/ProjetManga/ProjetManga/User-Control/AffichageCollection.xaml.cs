using Modele;
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
using System.Linq;

namespace ProjetManga
{
    /// <summary>
    /// Logique d'interaction pour AffichageCollection.xaml
    /// </summary>
    public partial class AffichageCollection : UserControl
    {

        public Listes l => (App.Current as App).l;
        public Navigation Navigator => (App.Current as App).Navigator;
        public AffichageCollection()
        {
            InitializeComponent();
            DataContext = l;
        }

        

        private void Click_Ajouter_Manga(object sender, RoutedEventArgs e)
        {
            var ajoutWindow = new Ajout_Window();

            ajoutWindow.ShowDialog();
        }

        private void AffichageDuMangaSelectionne(object sender, SelectionChangedEventArgs e)
        {
                                  
                l.MangaCourant = (sender as ListBox).SelectedItem as Manga;
                Navigator.NavigationTo(Navigation.UC_Affichage_INFO_MANGA);
               
                      
        }

        public void SetColor(SolidColorBrush b)
        {
            fond.Background = b;
            bas.Background = b;
           
        }
    }
}
