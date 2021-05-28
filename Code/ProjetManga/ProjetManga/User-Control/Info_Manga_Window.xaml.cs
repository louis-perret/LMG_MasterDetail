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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class Info_Manga_Window : UserControl
    {
        public static Listes l => (App.Current as App).l;

       // private static Manga MangaCourant { get; set; }
        public Info_Manga_Window()
        {
            InitializeComponent();
            //DataContext = this; //ça va nous permettre de pouvoir binder sur MangaCourant de l'UC puis sur chacune de ses propriétés
            //DataContext =l; //mauvaise reference, il faut binder sur une propriété qui comprend le MangaCourant (c'est ce qu'a dit le prof)
            //DataContext = l;
        }

        public void Button_Modifier_Manga(object sender, RoutedEventArgs e)
        {
            var modifWindow = new Modifier_Window();
            modifWindow.ShowDialog();
            
        }

        private void Button_Supprimer_Manga(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous supprimer définitivement ce manga de l'application ?","Supprimer Manga", MessageBoxButton.OKCancel);
        }

        private void Click_Ajout_Favori(object sender, RoutedEventArgs e)
        {
            ///
            ///Gestionnaire.AjouterFavoriManga(l,, l.CompteCourant);
        }

        private void Click_Noter_Manga(object sender, RoutedEventArgs e)
        {
            var noteWindow = new Note_Window();
            noteWindow.ShowDialog();
        }
    }
}
