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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Ajout_Window : Window
    {
        public static Listes l => (App.Current as App).l;

        private string imageName;
        public Ajout_Window()
        {
            InitializeComponent();
            //DataContext = l.CollectionManga.Values;
            comboGenre.DataContext = l;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(to_text.Text) || String.IsNullOrEmpty(ta_text.Text) || String.IsNullOrEmpty(auteur_text.Text) || String.IsNullOrEmpty(dess_text.Text) || String.IsNullOrEmpty(maisonFr_text.Text)
                 || String.IsNullOrEmpty(maisonJ_text.Text) || String.IsNullOrEmpty(syno_text.Text) || String.IsNullOrEmpty(NbTome_text.Text) || comboGenre.SelectedItem == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Problème", MessageBoxButton.OK);
                return;
            }

            DateTime p;
            DateTime? d;
            try
            {
                p = Convert.ToDateTime(pTome_text.Text);
                d = Convert.ToDateTime(dTome_text.Text);
            }
            catch(Exception exception)
            {
                MessageBox.Show("Erreur dans la saisie des dates de parutions, veuillez entrer l'un des bons formats", "Problème date", MessageBoxButton.OK);
                return;
            }
            if(imageName == null)
            {
                MessageBox.Show("Vous devez ajouter une couverture pour le manga", "Problème image", MessageBoxButton.OK);
                Button_Changer_Image(sender,e);
            }

            
            GenreDispo g = (comboGenre.SelectedItem as Genre).NomGenre;
            int nb = Int32.Parse(NbTome_text.Text);          
            l.AjouterManga( to_text.Text, ta_text.Text, auteur_text.Text, dess_text.Text, maisonJ_text.Text, maisonFr_text.Text, p, d, nb, imageName, syno_text.Text,l.RecupererGenre(g));
            Close();
        }

        private void Button_Changer_Image(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choisissez votre photo de profil";
            dialog.Filter = "Fichiers images | *.jpg;*.png;";
            bool? resultat = dialog.ShowDialog();
            if (resultat == true)
            {
                imageName = dialog.FileName;
                couv_img.Source = new BitmapImage(new Uri(imageName));
            }
        }
    }
}
