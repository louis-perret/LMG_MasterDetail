using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data
{
    public abstract class Sauveur
    {
        protected string chemin { get; set; }

        public Sauveur(string chemin)
        {
            this.chemin = chemin;
        }

        public abstract void Save(Listes l);
    }
}
