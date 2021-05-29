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
    public partial class ModifierProfil : Window
    {
        public Listes l => (App.Current as App).l; //Pointe sur le même l de toutes l'application
        public Compte LeCompte { get; set; }

        
        public ModifierProfil()
        {
            InitializeComponent();
            var c = l.CompteCourant;
            LeCompte = new Compte(c.Pseudo, c.dateNaissance.ToString(), c.DateInscription, c.MotDePasse, c.GenresPreferes, c.ImageProfil);
            DataContext = LeCompte;
            WrapGenre.DataContext = l;
        }

        private void Button_CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            //l.ModifierProfil(l.CompteCourant.Pseudo, LeCompte.Pseudo, new GenreDispo[] { (combo1.SelectedItem as Genre).NomGenre, (combo2.SelectedItem as Genre).NomGenre } ); // pour les genre c'est certainement pas la bonne méthode
            Gestionnaire.ModifierProfil(l,l.CompteCourant.Pseudo, LeCompte.Pseudo, new GenreDispo[] { (combo1.SelectedItem as Genre).NomGenre, (combo2.SelectedItem as Genre).NomGenre });
            Close();
        }

        
    }
}
