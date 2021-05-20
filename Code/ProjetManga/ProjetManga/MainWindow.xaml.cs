using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modele;
using Data;
using System.Windows;
using System.Windows.Controls;

namespace ProjetManga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public Listes l => (App.Current as App).l;
        //private Array genreDisponible = Enum.GetValues(typeof(GenreDispo));

        public MainWindow()
        {
            InitializeComponent();
            //l = chargeur.Load("");
            //ListeDesGenresDisponibles.DataContext = l;
            DataContext = l;
            //bool c = Gestionnaire.ChercherUtilisateur(l, "Nicolas", "azerty123");
            profil.DataContext = l.CompteCourant;
        }

        private void settings_button_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new Menu();
            menuWindow.ShowDialog();
            l.CompteCourant = null;
            var connectionWindow = new Connection_Window();
            connectionWindow.Show();
            this.Close();
            
            
            
        }
    }
}
