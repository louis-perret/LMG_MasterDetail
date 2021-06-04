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
        public static Listes l => (App.Current as App).l;

        public Navigation Navigator => (App.Current as App).Navigator;


        // private static Manga MangaCourant { get; set; }
        public Info_Manga_Window()
        {
            InitializeComponent();
            //DataContext = this; //ça va nous permettre de pouvoir binder sur MangaCourant de l'UC puis sur chacune de ses propriétés
            //DataContext =l; //mauvaise reference, il faut binder sur une propriété qui comprend le MangaCourant (c'est ce qu'a dit le prof)
            DataContext = l;
        }

        public void Button_Modifier_Manga(object sender, RoutedEventArgs e)
        {

            var modifWindow = new Modifier_Window();
            modifWindow.ShowDialog();
            
        }

        private void Button_Supprimer_Manga(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous supprimer définitivement ce manga de l'application ?","Supprimer Manga", MessageBoxButton.OKCancel,MessageBoxImage.Question);
            if(result==MessageBoxResult.OK)
            {
                Gestionnaire.SupprimerManga(l, l.MangaCourant, l.MangaCourant.Genre);
                Gestionnaire.SupprimerFavoriManga(l, l.MangaCourant, l.CompteCourant);
                Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);
            }
            
        }

        private void Click_Ajout_Favori(object sender, RoutedEventArgs e)
        {
           if(l.CompteCourant.LesFavoris.Contains(l.MangaCourant))
            {
                Gestionnaire.SupprimerFavoriManga(l, l.MangaCourant, l.CompteCourant);
                Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION); //la suppression ne se fait pas quand on revient sur la page, il faut changer puis revenir
               
            }
            else
            {
                Gestionnaire.AjouterFavoriManga(l, l.MangaCourant, l.CompteCourant);
            }
           
        }

        private void Click_Noter_Manga(object sender, RoutedEventArgs e)
        {
         
            var noteWindow = new Note_Window();
            noteWindow.ShowDialog();
        }
        private void Click_Retour_Arriere(object sender, RoutedEventArgs e)
        {
            Navigator.NavigationTo(Navigation.UC_AFFICHAGE_COLLECTION);
        }
    }
}
