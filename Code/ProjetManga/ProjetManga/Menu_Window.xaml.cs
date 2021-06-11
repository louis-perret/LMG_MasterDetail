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
    public partial class Menu : Window
    {

        public MainWindow M { get; set; }

        public Listes l => (App.Current as App).l;
        public Sauveur sauveur => (App.Current as App).sauveur;
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Annuler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Deco(object sender, RoutedEventArgs e)
        {
            M.Close();
            var connection_window = new Connection_Window();
            connection_window.Show();
            sauveur.Save(l);
            Close();
        }

        private void Button_Modif(object sender, RoutedEventArgs e)
        {
            var modifProfilWindow = new ModifierProfil();
            modifProfilWindow.ShowDialog();
            modifProfilWindow.Close();
        }
    }
}
