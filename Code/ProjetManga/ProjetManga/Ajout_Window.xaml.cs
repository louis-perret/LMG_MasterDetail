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
        private Stub chargeur = new Stub("");
        public Listes l => chargeur.Load("");

        private string imageName;
        public Ajout_Window()
        {
            InitializeComponent();
            DataContext = l.CollectionManga.Values;
            comboGenre.DataContext = l;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            GenreDispo g=(comboGenre.SelectedItem as Genre).NomGenre;
            DateTime p = Convert.ToDateTime(pTome_text.Text);
            DateTime d = Convert.ToDateTime(dTome_text.Text);
            int nb = Int32.Parse(NbTome_text.Text);
            

           
            Gestionnaire.AjouterManga(l, to_text.Text, ta_text.Text, auteur_text.Text, dess_text.Text, maisonJ_text.Text, maisonFr_text.Text, p, d, nb, imageName, syno_text.Text, g);
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
