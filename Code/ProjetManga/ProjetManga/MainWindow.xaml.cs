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
            menuWindow.M = this;
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
            l.GenreAuHasard(l,out g);
            l.GenreCourant = g;
            l.ListeParGenre(g);
            //Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION, contentControl);
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);

        }

        private void Button_Recherche_Clavier(object sender, RoutedEventArgs e)
        {
            
            string m = nom_rechercher.Text;
            l.MangaCourant= l.RechercherMangaParNom(m);
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
            l.GenreCourant = null;
            // Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION, contentControl);
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);
        }

        private void Click_Dark_Mode(object sender, RoutedEventArgs e)
        {
            
            Navigation.DicoUC.TryGetValue(Navigation.UC_AFFICHAGE_MANGA_DU_MOMENT, out UserControl u1);
            Navigation.DicoUC.TryGetValue(Navigation.UC_AFFICHAGE_COLLECTION, out UserControl u2);
            Navigation.DicoUC.TryGetValue(Navigation.UC_Affichage_INFO_MANGA, out UserControl u3);

            if (mode_button.IsChecked==true)
            {
                mainCoteDroit.Background = Brushes.DarkGray;
                mainCoteGauche.Background = Brushes.DarkGray;
                genreClick.Background = Brushes.DarkGray;
                ((MangaDuMoment)u1).SetColor(Brushes.DarkGray);
                ((AffichageCollection) u2).SetColor(Brushes.DarkGray);
                ((Info_Manga_Window)u3).SetColor(Brushes.DarkGray);

                u3.Background = Brushes.DarkGray;

            }
            else 
               
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(208, 224, 232));
                mainCoteDroit.Background = brush;
                mainCoteGauche.Background = brush;
                genreClick.Background = brush;

                ((MangaDuMoment)u1).SetColor(brush);
                ((AffichageCollection)u2).SetColor(brush);
                ((Info_Manga_Window)u3).SetColor(brush);

                u3.Background = brush;
            }

        }
    }


}
    
        






            
        