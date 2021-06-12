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

        public Listes L => (App.Current as App).L;
        public Navigation Navigator => (App.Current as App).Navigator;
        public AffichageCollection()
        {
            InitializeComponent();
            DataContext = L;
        }

        
        /// <summary>
        /// Permet d'ouvrir la fenetre pour ajouter un manga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Ajouter_Manga(object sender, RoutedEventArgs e)
        {
            var ajoutWindow = new Ajout_Window();
            
            ajoutWindow.ShowDialog();
            listeManga.SelectedItem = null;
        }

        /// <summary>
        /// Permet de changer le user control pour afficher le manga selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AffichageDuMangaSelectionne(object sender, SelectionChangedEventArgs e)
        {
                                  
                L.MangaCourant = (sender as ListBox).SelectedItem as Manga;
                Navigator.NavigationTo(Navigation.UC_AFFICHAGE_INFO_MANGA);
        }

        /// <summary>
        /// Permet de changer la couleur de certaines parties de la fenetre
        /// </summary>
        /// <param name="b"></param>
        public void SetColor(SolidColorBrush b)
        {
            fond.Background = b;
            listeManga.Background = b;
        }
    }
}
