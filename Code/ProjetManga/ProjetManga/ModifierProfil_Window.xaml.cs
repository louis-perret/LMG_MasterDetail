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
        private Stub chargeur = new Stub("");
        public Listes l => chargeur.Load("");

        public Compte LeCompte { get; set; }

        
        public ModifierProfil()
        {
            InitializeComponent();
            DataContext = l.CompteCourant; //retourne null ?
            var c = l.CompteCourant;
            LeCompte = new Compte(c.Pseudo, c.dateNaissance.ToString(), c.DateInscription, c.MotDePasse,c.GenresPreferes, c.ImageProfil);
           
        }

        private void Button_CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            l.ModifierProfil(l.CompteCourant.Pseudo, LeCompte.Pseudo, LeCompte.GenresPreferes);
        }

        
    }
}
