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

        public static Listes l => (App.Current as App).l;
        //public Manga LeManga { get; set; }
        private string imageName;

        private Manga m = new Manga(l.MangaCourant.TitreOriginal, l.MangaCourant.TitreAlternatif, l.MangaCourant.Auteur, l.MangaCourant.Dessinateur, l.MangaCourant.MaisonEditionJap,
            l.MangaCourant.MaisonEditionFr, l.MangaCourant.DatePremierTome, l.MangaCourant.DateDernierTome, l.MangaCourant.NombreTome, l.MangaCourant.Couverture, l.MangaCourant.Synopsis, l.MangaCourant.Genre);

        public Modifier_Window()
        {
            InitializeComponent();
            /*var m = l.MangaCourant;
            
            LeManga = new Manga(m.TitreOriginal,m.TitreAlternatif,m.Auteur,m.Dessinateur,m.MaisonEditionJap,m.MaisonEditionFr,m.PremierTome,m.DernierTome,m.NombreTome,m.Couverture,m.Synopsis,m.Genre);
            DataContext = LeManga;
            */
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
                l.ModifierManga(l.RecupererGenre(m.Genre), m.TitreOriginal, modif_dTome.Text ,nb, imageName, m.Synopsis); //je crois que c'est qu'il manque parfois des 0

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
