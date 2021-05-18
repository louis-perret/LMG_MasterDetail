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

namespace ProjetManga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*private Stub chargeur = new Stub("");
        public Listes l => chargeur.Load("");*/

        public Listes l => (App.Current as App).l;
        //private Array genreDisponible = Enum.GetValues(typeof(GenreDispo));

        public MainWindow()
        {
            InitializeComponent();
            //l = chargeur.Load("");
            ListeDesGenresDisponibles.DataContext = l;
        }

        private void settings_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
