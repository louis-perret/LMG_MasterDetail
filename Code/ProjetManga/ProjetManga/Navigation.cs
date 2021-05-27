using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ProjetManga
{
    public class Navigation
    {

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
            //MainPart = mainPart;
        }

        public void NavigationTo(string nomUC,ContentControl contentControl)
        {
            if(contentControl != null)
            {
                MainPart = contentControl; //Permet de toujours garder le ContentControl de MainWindow
            }          

            if (DicoUC.TryGetValue(nomUC, out UserControl u))
            {               
                MainPart.Content = u;
            }
        }
    }
}
