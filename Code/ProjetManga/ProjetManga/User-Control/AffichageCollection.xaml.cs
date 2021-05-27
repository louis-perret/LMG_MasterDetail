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
        }

        

        private void Click_Ajouter_Manga(object sender, RoutedEventArgs e)
        {
            var ajoutWindow = new Ajout_Window();

            ajoutWindow.ShowDialog();
        }

        private void AffichageDuMangaSelectionne(object sender, SelectionChangedEventArgs e)
        {
            var m = e.AddedItems;
            foreach(Manga manga in m)
            {
                l.MangaCourant = manga; //m contient l'élément cliqué donc forcément il n'y en a qu'un           
            }
            Info_Manga_Window.MangaCourant = l.MangaCourant;
            Navigator.NavigationTo(Navigation.UC_Affichage_INFO_MANGA, null);
        }
    }
}
