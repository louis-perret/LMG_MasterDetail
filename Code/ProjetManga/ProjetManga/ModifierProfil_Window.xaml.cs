using Data;
using Microsoft.Win32;
using Modele;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ModifierProfil : Window
    {
        public Listes L => (App.Current as App).L; 
        public Compte LeCompte { get; set; }

        string imageName;
        
        public ModifierProfil()
        {
            InitializeComponent();
            LeCompte = new Compte(L.CompteCourant.Pseudo, L.CompteCourant.dateNaissance.ToString(), L.CompteCourant.DateInscription, L.CompteCourant.MotDePasse, L.CompteCourant.GenresPreferes, L.CompteCourant.ImageProfil);
            imageName = LeCompte.ImageProfil;
            DataContext = LeCompte;
            WrapGenre.DataContext = L;
        }
        
        private void Button_CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            List<GenreDispo> tabGenre = new List<GenreDispo>();

            if (combo1.SelectedItem != null)
            {
                tabGenre.Add((combo1.SelectedItem as Genre).NomGenre);
            }

            if (combo2.SelectedItem != null)
            {
                GenreDispo g = (combo2.SelectedItem as Genre).NomGenre;
                if (g  != tabGenre[0])
                {
                    tabGenre.Add(g);
                }
                else
                {
                    MessageBox.Show("Veuillez ne pas mettre deux fois le même genre", "Problème", MessageBoxButton.OK);
                    return;
                }
                
            }
            try
            {
                L.ModifierProfil(L.CompteCourant.Pseudo, LeCompte.Pseudo, tabGenre.ToArray(), imageName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Problème", MessageBoxButton.OK);
                return;
            }
            Button_CloseWindow(sender,e);
        }

        private void Button_Changer_Image(object sender, RoutedEventArgs e)
        {
            imageName = (App.Current as App).Button_Changer_Image();
            if(imageName != null) imageProfil.Source = new BitmapImage(new Uri(imageName));
        }
    }
}
