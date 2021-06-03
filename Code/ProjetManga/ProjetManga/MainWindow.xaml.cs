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
using Modele;
using Data;
using System.ComponentModel;

namespace ProjetManga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public Listes l => (App.Current as App).l;
        //private Array genreDisponible = Enum.GetValues(typeof(GenreDispo));

        public Navigation Navigator => (App.Current as App).Navigator;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = l;
            contentControl.DataContext = Navigator;
            //bool c = Gestionnaire.ChercherUtilisateur(l, "Nicolas", "azerty123");
            profil.DataContext = l.CompteCourant;
            //Navigator = new Navigation(this.contentControl);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Settings_button_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new Menu();
            menuWindow.m = this;
            menuWindow.ShowDialog();

            //l.CompteCourant = null;
            //var connectionWindow = new Connection_Window();
            //connectionWindow.Show();
            //this.Close();
        }

        


        void OnPropertyChanged(string nomProp)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomProp));


        private void Selection_Changed_Genre(object sender, SelectionChangedEventArgs e)
        {
            l.GenreCourant = genreClick.SelectedItem as Genre;
            
            l.ListeParGenre(l.GenreCourant);
            //Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION,contentControl);
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);

        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            // Navigator.NavigationTo(Navigation.UC_AFFICHAGE_MANGA_DU_MOMENT, contentControl);
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_MANGA_DU_MOMENT);
        }

        private void Button_Click_Hasard(object sender, RoutedEventArgs e)
        {

            Genre g;
            Gestionnaire.GenreAuHasard(l,out g);
            l.GenreCourant = g;
            l.ListeParGenre(g);
            //Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION, contentControl);
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);

        }

        private void Button_Recherche_Clavier(object sender, RoutedEventArgs e)
        {
            
            string m = nom_rechercher.Text;
            l.MangaCourant= Gestionnaire.RechercherMangaParNom(l, m);
            if (l.MangaCourant == null)
            {
                MessageBox.Show("Manga non trouvé. Vous avez-peut-être fait une erreur dans le nom","Problème de recherche");
                return;
            }
            Navigator.NavigationTo(Navigation.UC_Affichage_INFO_MANGA);
            // Navigator.NavigationTo(Navigation.UC_Affichage_INFO_MANGA, null);


        }

        private void Button_Click_ListeFavoris(object sender, RoutedEventArgs e)
        {
            l.RecupererFavoris();
            // Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION, contentControl);
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);
        }

        private void Click_Dark_Mode(object sender, RoutedEventArgs e)
        {
            if(mode_button.IsChecked==true)
            {
                mainCoteDroit.Background = Brushes.DarkGray;
                mainCoteGauche.Background = Brushes.DarkGray;
                genreClick.Background = Brushes.DarkGray;
                
            }
            if (mode_button.IsChecked == false) //marche pas
            {
                mainCoteDroit.Background = Brushes.White;
                mainCoteGauche.Background = Brushes.White;
                genreClick.Background = Brushes.White;
            }

        }
    }


}
    
        






            
        