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
        private Stub chargeur = new Stub("");
        public Listes l => chargeur.Load("");

        private string fileName;
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
            GenreDispo[] tabGenre = null;
            int i = 1;
            if(combo1.SelectedItem != null)
            {
                tabGenre[i] =(combo1.SelectedItem as Genre).NomGenre;
                i++;
            }
            
            if (combo2.SelectedItem != null)
            {
                tabGenre[i] = (combo2.SelectedItem as Genre).NomGenre;
            }
            Compte c = new Compte(nom_text.Text, dateNaissance_text.Text, DateTime.Today,mdp_text.Text, tabGenre,null);
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
                fileName = dialog.FileName;
                imageProfil.Source = new BitmapImage(new Uri( fileName));
            }
        }
    }
}
