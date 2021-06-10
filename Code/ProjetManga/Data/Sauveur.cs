using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data
{
    /// <summary>
    /// Cette classe abstraite va permettre de sérialiser notre instance de Listes.
    /// </summary>
    public abstract class Sauveur
    {
        protected string chemin { get; set; }

        public Sauveur(string chemin)
        {
            this.chemin = chemin;
        }
        /// <summary>
        /// Methode abstraite pour sauvegarder les données
        /// </summary>
        /// <param name="l">Listes à serializer</param>
        public abstract void Save(Listes l);
    }
}
