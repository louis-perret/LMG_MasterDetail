using Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;

namespace ProjetManga
{
    public class Navigation : INotifyPropertyChanged
    {

        Listes l => (App.Current as App).l;

        public const string UC_AFFICHAGE_COLLECTION = "AffichageCollection";
        public const string UC_AFFICHAGE_MANGA_DU_MOMENT = "MangaDuMoment";
        public const string UC_Affichage_INFO_MANGA = "InfoManga";

        static Dictionary<string, UserControl> DicoUC = new Dictionary<string, UserControl>()
        {
            [UC_AFFICHAGE_MANGA_DU_MOMENT] = new MangaDuMoment(),
            [UC_AFFICHAGE_COLLECTION] = new AffichageCollection(),
            [UC_Affichage_INFO_MANGA] = new Info_Manga_Window()
        };

        public ContentControl MainPart { get; private set; }

        public Navigation()
        {
            SelectedUserControl = DicoUC.GetValueOrDefault(UC_AFFICHAGE_MANGA_DU_MOMENT);
            //MainPart = mainPart;
        }

        /* public void NavigationTo(string nomUC,ContentControl contentControl)
         {
             if(contentControl != null)
             {
                 MainPart = contentControl; //Permet de toujours garder le ContentControl de MainWindow
             }          

             if (DicoUC.TryGetValue(nomUC, out UserControl u))
             {
                 if (nomUC == UC_Affichage_INFO_MANGA)
                 {
                     u.DataContext = l.MangaCourant;
                 }
                 MainPart.Content = u;

             }
         }*/
        public void NavigationTo(string nomUC)
        {
            SelectedUserControl = DicoUC.GetValueOrDefault(nomUC);
        }

        private UserControl selectedUserControl;

        public event PropertyChangedEventHandler PropertyChanged;

        public UserControl SelectedUserControl
        {
            get => selectedUserControl;
            set
            {
                if (selectedUserControl != value)
                {
                    selectedUserControl = value;
                    OnPropertyChanged(nameof(SelectedUserControl));
                }
            }
        }
        void OnPropertyChanged(string nomProp)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomProp));

    }
}
