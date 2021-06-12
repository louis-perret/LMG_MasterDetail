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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Modifier_Window : Window
    {

        public static Listes L => (App.Current as App).L;
        private string imageName;



        private Manga m;

        public Modifier_Window()
        {
            InitializeComponent();
            if(L.MangaCourant.DateDernierTome.Equals("En cours de parution"))
            {
                m = new Manga(L.MangaCourant.TitreOriginal, L.MangaCourant.TitreAlternatif, L.MangaCourant.Auteur, L.MangaCourant.Dessinateur, L.MangaCourant.MaisonEditionJap,
           L.MangaCourant.MaisonEditionFr, L.MangaCourant.PremierTome.ToString("d"), "" , L.MangaCourant.NombreTome, L.MangaCourant.Couverture, L.MangaCourant.Synopsis, L.MangaCourant.Genre);
            }
            else
            {
                m = new Manga(L.MangaCourant.TitreOriginal, L.MangaCourant.TitreAlternatif, L.MangaCourant.Auteur, L.MangaCourant.Dessinateur, L.MangaCourant.MaisonEditionJap,
            L.MangaCourant.MaisonEditionFr, L.MangaCourant.PremierTome.ToString("d"), L.MangaCourant.DateDernierTome, L.MangaCourant.NombreTome, L.MangaCourant.Couverture, L.MangaCourant.Synopsis, L.MangaCourant.Genre);
            }
             
        DataContext = m;         

        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            int nb = 0;
            try
            {
                nb = Int32.Parse(modif_nb.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Nombre de tome incorrect", "Problème", MessageBoxButton.OK);
                return;
            }             
            if(imageName == null)
            {
                imageName = m.Couverture;
            }
            try
            {
                L.ModifierManga(L.RecupererGenre(m.Genre), m.TitreOriginal, modif_dTome.Text ,nb, imageName, m.Synopsis); //je crois que c'est qu'il manque parfois des 0

            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Problème", MessageBoxButton.OK);
                return;
            }
            Close();
        }

        private void Button_Changer_Image(object sender, RoutedEventArgs e)
        {
            imageName = (App.Current as App).Button_Changer_Image();
            if(imageName != null ) imageManga.Source = new BitmapImage(new Uri(imageName));
        }
    }
}
