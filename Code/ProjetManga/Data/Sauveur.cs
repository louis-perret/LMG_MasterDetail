using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class Sauveur
    {
        private string chemin;

        public Sauveur(string chemin)
        {
            this.chemin = chemin;
        }

        public abstract void Save(Listes l);
    }
}
