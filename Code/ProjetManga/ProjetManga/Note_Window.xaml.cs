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

        public Listes l => (App.Current as App).l;
        public Note_Window()
        {
            InitializeComponent();
            DataContext = l;
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            int note = (int)noteBox.SelectedIndex;
            /*try //Inutile car on ne fait pas de vérification lors de l'appel au constructeur donc ça marchera toujours
            {
                //Avis a = new Avis(avis_text.Text, note, l.CompteCourant);
                
            }
            catch(Exception e1)
            {
                MessageBoxResult result = MessageBox.Show(e1.Message, "Erreur", MessageBoxButton.OK);
            }
            */
            l.AjouterAvis(l.CompteCourant, avis_text.Text, note, l.RecupererGenre(l.MangaCourant.Genre), l.MangaCourant);
            l.MeilleurManga = l.ChercherMeilleurManga();
            Close();
            
        }

        private void Button_Annuler(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
