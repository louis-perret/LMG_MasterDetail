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
            Close();

        }

        private void Button_Modif(object sender, RoutedEventArgs e)
        {
            var modifProfilWindow = new ModifierProfil();
            modifProfilWindow.ShowDialog();
        }
    }
}
