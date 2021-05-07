using Modele;
using System;

namespace Data
{
   /// <summary>
   ///  je ne sais pas si on doit faire ca avec Listes ou Gestionnaire
   ///  11h50 -- Il faut mettre dans un coin du diagramme de classe la vue, la data,etc SAUF LES TESTS (pas besoin)
   ///        -- Ne pas surcharger les classes de méthodes ToString, Equals, etc sauf si c'est "clé"
   /// </summary>
    public abstract class Chargeur
    {
        private string chemin;

        public Chargeur(string chemin)
        {
            this.chemin = chemin;
        }
        public abstract Listes Load(string chemin);
    }
    
}
