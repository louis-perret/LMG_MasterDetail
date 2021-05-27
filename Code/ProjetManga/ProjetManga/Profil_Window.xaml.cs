using Data;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace ProjetManga
{
    /// <summary>
    /// Logique d'interaction pour Profil_Window.xaml
    /// </summary>
    public partial class Profil_Window : Window
    {
        /*private Stub chargeur = new Stub("");
        public Listes l => chargeur.Load("");*/
        public Listes l => (App.Current as App).l;

        private string imageName;
        public Profil_Window()
        {
            InitializeComponent();
            WrapGenre.DataContext = l;
        }

        private void Button_CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            GenreDispo[] tabGenre = new GenreDispo[2];
            int i = 0;
            if(combo1.SelectedItem != null)
            {
                tabGenre[i] =(combo1.SelectedItem as Genre).NomGenre;
                i++;
            }
            
            if (combo2.SelectedItem != null)
            {
                tabGenre[i] = (combo2.SelectedItem as Genre).NomGenre;
            }
            Gestionnaire.AjouterUtilisateur(l, nom_text.Text, dateNaissance_text.Text, mdp_text.Password, tabGenre,imageName); //On a une méthode pour ajouter un utilisateur, autant s'en servir !
            
            Button_CloseWindow(sender, e);
        }

        private void Button_Changer_Image(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choisissez votre photo de profil";
            dialog.Filter = "Fichiers images | *.jpg;*.png;";
            bool? resultat = dialog.ShowDialog();
            if(resultat==true)
            {
                imageName = dialog.FileName;
                imageProfil.Source = new BitmapImage(new Uri( imageName));
            }
        }
    }
}
