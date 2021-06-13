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
    public partial class MainWindow : Window
    {

        public Listes L => (App.Current as App).L;

        public Navigation Navigator => (App.Current as App).Navigator;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = L;
            contentControl.DataContext = Navigator;
            profil.DataContext = L.CompteCourant;
        }


        private void Settings_button_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new Menu();
            menuWindow.M = this;
            menuWindow.ShowDialog();
        }

        private void Selection_Changed_Genre(object sender, SelectionChangedEventArgs e)
        {
            L.GenreCourant = genreClick.SelectedItem as Genre;            
            L.ListeParGenre(L.GenreCourant);
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_MANGA_DU_MOMENT);
        }

        private void Button_Click_Hasard(object sender, RoutedEventArgs e)
        {

            L.GenreAuHasard();
            L.ListeParGenre(L.GenreCourant);
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);

        }

        private void Button_Recherche_Clavier(object sender, RoutedEventArgs e)
        {
            
            string m = nom_rechercher.Text;
            L.MangaCourant= L.RechercherMangaParNom(m);
            if (L.MangaCourant == null)
            {
                Navigator.NavigationTo(Navigation.UC_AFFICHAGE_MANGA_DU_MOMENT);
                MessageBox.Show("Manga non trouvé. Vous avez-peut-être fait une erreur dans le nom", "Problème de recherche");
                return;
            }
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_INFO_MANGA);


        }

        private void Button_Click_ListeFavoris(object sender, RoutedEventArgs e)
        {
            L.RecupererFavoris();
            L.GenreCourant = null;
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);
        }

        private void Click_Dark_Mode(object sender, RoutedEventArgs e)
        {
            
            Navigation.DicoUC.TryGetValue(Navigation.UC_AFFICHAGE_MANGA_DU_MOMENT, out UserControl u1);
            Navigation.DicoUC.TryGetValue(Navigation.UC_AFFICHAGE_COLLECTION, out UserControl u2);
            Navigation.DicoUC.TryGetValue(Navigation.UC_AFFICHAGE_INFO_MANGA, out UserControl u3);

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
                SolidColorBrush brushMain = new SolidColorBrush(Color.FromRgb(232, 240, 240));
                mainCoteDroit.Background = brush;
                mainCoteGauche.Background = brush;
                genreClick.Background = brush;

                ((MangaDuMoment)u1).SetColor(brushMain);
                ((AffichageCollection)u2).SetColor(brush);
                ((Info_Manga_Window)u3).SetColor(brush);

                u3.Background = brush;
            }

        }
    }


}
    
        






            
        