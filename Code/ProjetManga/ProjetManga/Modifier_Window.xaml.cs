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


        public Modifier_Window()
        {
            InitializeComponent();
            /*var m = l.MangaCourant;
            
            LeManga = new Manga(m.TitreOriginal,m.TitreAlternatif,m.Auteur,m.Dessinateur,m.MaisonEditionJap,m.MaisonEditionFr,m.PremierTome,m.DernierTome,m.NombreTome,m.Couverture,m.Synopsis,m.Genre);
            DataContext = LeManga;
            */
            DataContext = l.MangaCourant;
            


        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            DateTime? d = null;
            int nb = Int32.Parse(modif_nb.Text);
            if (!String.IsNullOrEmpty(modif_dTome.Text))
            {
                try 
                {
                    d = Convert.ToDateTime(modif_dTome.Text);
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Mauvais format pour la dernière date de parution","Problème", MessageBoxButton.OK);
                }               
            }
            if(imageName == null)
            {
                imageName = l.MangaCourant.Couverture;
            }
            Gestionnaire.ModifierManga(l, l.MangaCourant.Genre, l.MangaCourant.TitreOriginal, d, nb, imageName, modif_syno.Text); //je crois que c'est qu'il manque parfois des 0
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
                imageManga.Source = new BitmapImage(new Uri(imageName));
            }
        }
    }
}
