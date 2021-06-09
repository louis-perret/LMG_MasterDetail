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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetManga
{
    /// <summary>
    /// Logique d'interaction pour MangaDuMoment.xaml
    /// </summary>
    public partial class MangaDuMoment : UserControl
    {
        
        
        public Listes l => (App.Current as App).l;
        public MangaDuMoment()
        {
            InitializeComponent();
            //l.ChercherMeilleurManga();
            DataContext = l; //il faut faire un binding sur le resultat de  cette méthode
        }

        public void SetColor(SolidColorBrush b)
        {
            this.mangaDuMomentFond.Background = b;
        }
    }
}
