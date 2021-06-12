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
        public Listes L => (App.Current as App).L;
        public MangaDuMoment()
        {
            InitializeComponent();   
            DataContext = L; 
        }

        /// <summary>
        /// Permet de modifier les couleurs de certaines parties de la fenetre
        /// </summary>
        /// <param name="b"></param>
        public void SetColor(SolidColorBrush b)
        {
            fond.Background = b;
        }
    }
}
