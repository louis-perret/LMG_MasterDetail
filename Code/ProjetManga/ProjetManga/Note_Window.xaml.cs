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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Note_Window : Window
    {
        private Stub chargeur = new Stub("");
        public Listes l => chargeur.Load("");
        public Note_Window()
        {
            InitializeComponent();
            DataContext = l;
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            try
            {
                Avis a = new Avis(avis_text.Text, noteBox.SelectedIndex, l.CompteCourant);
            }
            catch(Exception e1)
            {
                MessageBoxResult result = MessageBox.Show(e1.Message, "Erreur", MessageBoxButton.OK);
            }
            int note = (int)noteBox.SelectedIndex;
            Gestionnaire.AjouterAvis(l, l.CompteCourant, avis_text.Text, note,l.MangaCourant.Genre,l.MangaCourant);
            
        }

        private void Button_Annuler(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
