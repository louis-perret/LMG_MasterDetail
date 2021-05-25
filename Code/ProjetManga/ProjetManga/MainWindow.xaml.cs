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
using System.ComponentModel;

namespace ProjetManga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public Listes l => (App.Current as App).l;
        //private Array genreDisponible = Enum.GetValues(typeof(GenreDispo));

        public MainWindow()
        {
            InitializeComponent();
            DataContext = l;
            //bool c = Gestionnaire.ChercherUtilisateur(l, "Nicolas", "azerty123");
            profil.DataContext = l.CompteCourant;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Settings_button_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new Menu();
            menuWindow.m = this;
            menuWindow.ShowDialog();

            //l.CompteCourant = null;
            //var connectionWindow = new Connection_Window();
            //connectionWindow.Show();
            //this.Close();
        }

        


        void OnPropertyChanged(string nomProp)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomProp));

        
        
       /* public SortedSet<Manga> ListeDeMangaParGenre
        {
            get
            {
                return l.ListeParGenre(genreClick.SelectedItem as Genre);
            }
        }*/

        

        private void Selection_Changed_Genre(object sender, SelectionChangedEventArgs e)
        {
            l.GenreCourant = genreClick.SelectedItem as Genre;
            
            l.ChercherListeParGenre(l.GenreCourant);
            contentControl.Content = new AffichageCollection();

        }
    }


}
    
        






            
        