using Data;
using Microsoft.Win32;
using Modele;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetManga
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal Listes l { get; set; }

        internal Chargeur chargeur = new ChargeurXML("../../..//XML");
        internal Sauveur sauveur = new SauveurXML("../../..//XML");
        public Navigation Navigator { get; set; }
        public App()
        {
            /*l = new Stub("").Load();
            sauveur.Save(l);*/
            
            l = chargeur.Load();
            

            Navigator = new Navigation();           
        }

        public string Button_Changer_Image()
        {
            string imageName = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choisissez votre photo";
            dialog.Filter = "Fichiers images | *.jpg;*.png;";
            bool? resultat = dialog.ShowDialog();
            if (resultat == true)
            {
                imageName = dialog.FileName;               
            }
            
            return imageName;
        }
    }
}
