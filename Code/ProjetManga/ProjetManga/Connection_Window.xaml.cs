using Data;
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
    /// Logique d'interaction pour Connection_Window.xaml
    /// </summary>
    public partial class Connection_Window : Window
    {
        public Listes l => new Stub("").Load("");
        public Connection_Window()
        {
            InitializeComponent();
        }

        private void Button_FermerApplication(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_CreerProfil(object sender, RoutedEventArgs e)
        {
            var profilWindow = new Profil_Window();
            profilWindow.ShowDialog();
        }

        private void Button_Connexion(object sender, RoutedEventArgs e)
        {

            if (!Gestionnaire.ChercherUtilisateur(l, nom_texte.Text, mdp_texte.Password))
            {
                MessageBox.Show("Ce compte n'existe pas", "Connexion", MessageBoxButton.OK);
            }

            else
            {
                Compte c = l.CompteCourant;
                var mainWindow = new MainWindow();
                mainWindow.Show();
                Button_FermerApplication(sender, e);               
            }
        }
    }
}
