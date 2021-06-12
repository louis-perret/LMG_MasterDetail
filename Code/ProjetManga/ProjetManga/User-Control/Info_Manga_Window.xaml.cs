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

namespace ProjetManga
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class Info_Manga_Window : UserControl
    {
        public static Listes L => (App.Current as App).L;

        public Navigation Navigator => (App.Current as App).Navigator;


        public Info_Manga_Window()
        {
            InitializeComponent();
            
            DataContext = L;
        }

        /// <summary>
        /// Permet d'ouvrir la fenetre pour modifier le manga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_Modifier_Manga(object sender, RoutedEventArgs e)
        {

            var modifWindow = new Modifier_Window();
            modifWindow.ShowDialog();
        }
        /// <summary>
        /// Permet de supprimer un manga de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Supprimer_Manga(object sender, RoutedEventArgs e)
        {
            //Controle pour eviter les fausses manipulations
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous supprimer définitivement ce manga de l'application ?","Supprimer Manga", MessageBoxButton.OKCancel,MessageBoxImage.Question);
            if(result==MessageBoxResult.OK)
            {
                L.SupprimerManga( L.MangaCourant, L.RecupererGenre(L.MangaCourant.Genre));
                Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);
            }
            
        }
        /// <summary>
        /// Permet d'ajouter un favori à la liste des favoris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Ajout_Favori(object sender, RoutedEventArgs e)
        {
           //Si le manga est deja en favori, il est retiré des favoris
           if(L.CompteCourant.LesFavoris.Contains(L.MangaCourant))
            {
                L.SupprimerFavoriManga(L.MangaCourant, L.CompteCourant);
                //L.RecupererFavoris();
                //Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);
            }
            else
            {
                L.AjouterFavoriManga( L.MangaCourant, L.CompteCourant);
            }
        }
        /// <summary>
        /// Permet d'ouvrir la fenetre pour noter un manga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Noter_Manga(object sender, RoutedEventArgs e)
        {
            var noteWindow = new Note_Window();
            noteWindow.ShowDialog();
        }
        /// <summary>
        /// Permet de retourner à l'affichage de la collection de manga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Retour_Arriere(object sender, RoutedEventArgs e)
        {
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);
        }

        /// <summary>
        /// Permet de changer la couleur de certaines parties de la fenetre
        /// </summary>
        /// <param name="b"></param>
        public void SetColor(SolidColorBrush b)
        {
            fond.Background = b;
        }
    }
}
