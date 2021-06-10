using Modele;
using System;
using System.IO;

namespace Data
{
    /// <summary>
    /// Cette classe va permettre de charger nos données à partir d’un objet Listes
    /// </summary>
    public abstract class Chargeur
    {
        protected string chemin { get; set; }

        public Chargeur(string chemin)
        {
            this.chemin = chemin;
        }

        /// <summary>
        /// Methode abstraite qui va servir à charger les données à partir de Listes
        /// </summary>
        /// <returns></returns>
        public abstract Listes Load();
    }
    
}
