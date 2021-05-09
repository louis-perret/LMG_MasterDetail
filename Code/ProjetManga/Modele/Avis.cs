using System;

namespace Modele
{
    /// <summary>
    /// Classe représentant les avis des utilisateurs
    /// </summary>

    public class Avis
    {
        public string Commentaire { get; private set; }
       
        public int Note { get; private set; }
       
        public Compte Util { get; private set; }
        public DateTime Date { get; private set; }

  
        public Avis(String commentaire, int note, Compte nomUtil)
        {
            Note = note;
            Commentaire = commentaire;
            Date = DateTime.Today;
            Util = nomUtil;

        }

        /// <summary>
        /// Permet de transformer une instance en chaîne de caractères
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            return $" écrit par {Util.Pseudo} le  {Date} : {Commentaire} \n\t\t Note : {Note} \n\t  ";
        }
    }
}
