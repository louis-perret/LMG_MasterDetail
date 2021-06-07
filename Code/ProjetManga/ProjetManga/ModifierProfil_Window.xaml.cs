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
        public Listes l => (App.Current as App).l; //Pointe sur le même l de toutes l'application
        public Compte LeCompte { get; set; }

        string imageName;
        
        public ModifierProfil()
        {
            InitializeComponent();
            LeCompte = new Compte(l.CompteCourant.Pseudo, l.CompteCourant.dateNaissance.ToString(), l.CompteCourant.DateInscription, l.CompteCourant.MotDePasse, l.CompteCourant.GenresPreferes, l.CompteCourant.ImageProfil);
            imageName = LeCompte.ImageProfil;
            DataContext = LeCompte;
            WrapGenre.DataContext = l;
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
                l.ModifierProfil(l.CompteCourant.Pseudo, LeCompte.Pseudo, tabGenre.ToArray(), imageName);
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
