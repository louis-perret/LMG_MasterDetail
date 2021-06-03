using Modele;
using System;
using System.IO;

namespace Data
{

    public abstract class Chargeur
    {
        protected string chemin { get; set; }

        public Chargeur(string chemin)
        {
            this.chemin = chemin;
        }
        public abstract Listes Load();
    }
    
}
