using Data;
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
        public Listes l { get; set; }

        Chargeur chargeur = new ChargeurXML("..//XML");
        Sauveur sauveur = new SauveurXML("..//XML");
        public Navigation Navigator { get; set; }
        public App()
        {
            //l = new Stub("").Load();
            //sauveur.Save(l); ;
            l = chargeur.Load();
            Navigator = new Navigation();           
        }

        /*protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            Navigator = new Navigation((MainWindow as MainWindow).contentControl);
        }*/
    }
}
