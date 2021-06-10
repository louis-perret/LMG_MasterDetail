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
    /// Logique d'interaction pour Ajout_Window.xaml
    /// </summary>
    public partial class Ajout_Window : Window
    {
        public static Listes l => (App.Current as App).l;

        private string imageName;
        public Ajout_Window()
        {
            InitializeComponent();
            comboGenre.DataContext = l;
        }

        /// <summary>
        /// Permet de fermer la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Valide l'ajout du manga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            //Des controles sont effectués pour tous les cas
            string p = pTome_text.Text;
            string d = dTome_text.Text;
            if (comboGenre.SelectedItem == null)
            {
                MessageBox.Show("Veuillez rentrer un genre");
                return;
            }
            GenreDispo g = (comboGenre.SelectedItem as Genre).NomGenre;
            int nb = 0;

            try
            {
                nb = Int32.Parse(NbTome_text.Text);
            }
            catch(Exception exception)
            {
                MessageBox.Show("Nombre de tome incorrect", "Problème", MessageBoxButton.OK);
                return;
            }

            if (imageName == null)
            {
                MessageBox.Show("Vous devez ajouter une couverture pour le manga", "Problème image", MessageBoxButton.OK);
                Button_Changer_Image(sender, e);
                return;
            }

            try
            {
                l.AjouterManga(to_text.Text, ta_text.Text, auteur_text.Text, dess_text.Text, maisonJ_text.Text, maisonFr_text.Text, p, d, nb, imageName, syno_text.Text, l.RecupererGenre(g));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Problème", MessageBoxButton.OK);
                return;
            }
            Close();
        }

        /// <summary>
        /// Permet d'ouvrir une fenetre pour selectionner l'image à changer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Changer_Image(object sender, RoutedEventArgs e)
        {
            imageName = (App.Current as App).Button_Changer_Image();
            if(imageName != null) couv_img.Source = new BitmapImage(new Uri(imageName));
        }
    }
}
