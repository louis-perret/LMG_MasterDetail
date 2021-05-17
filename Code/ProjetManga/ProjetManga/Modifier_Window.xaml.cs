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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Modifier_Window : Window
    {
        private Stub chargeur = new Stub("");
        public Listes l => chargeur.Load("");
       

        public Modifier_Window()
        {
            InitializeComponent();
            
            
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
