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

        private void AffichageDuMangaSelectionne(object sender, SelectionChangedEventArgs e) //Le problème vient car l'évènement est appelé 2x fois au lieu d'une 
            //Le prof m'a conseillé d'utiliser la propriété SelectionChanged et non l'évènement et de binder notre data context avec
        {
            int i = 0;
            /*var m = e.AddedItems;
            foreach(Manga manga in m)
            {
                l.MangaCourant = manga; //m contient l'élément cliqué donc forcément il n'y en a qu'un           
            }

            Info_Manga_Window.MangaCourant = l.MangaCourant;*/
            if(i == 0)
            {
                l.MangaCourant = (sender as ListBox).SelectedItem as Manga;
                //Navigator.NavigationTo(Navigation.UC_Affichage_INFO_MANGA, null);
                Navigator.NavigationTo(Navigation.UC_Affichage_INFO_MANGA);
                i = i + 1;
            }           
        }
    }
}
