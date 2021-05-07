using System;

namespace Modele
{
    /// <summary>
    /// Classe représentant les avis des utilisateurs
    /// </summary>
    //Testée & fonctionnelle
    public class Avis
    {
        public string Commentaire { get; private set; }
       
        public int Note { get; private set; }
       
        public Compte Util { get; private set; }
        public DateTime Date { get; private set; }
        /// <summary>
        /// Constructeur de cette classe
        /// </summary>
        /// <param name="commentaire">Valeur du commentaire</param>
        public Avis(String commentaire, int note, DateTime date, Compte Util)
        {
            Note = note;
            Commentaire = commentaire;
            Date = date;
            this.Util = Util;

        }

        /// <summary>
        /// Permet de transformer une instance en chaîne de caractères
        /// </summary>
        /// <returns></returns>
        public override string ToString() ///testé
        {
            return $" écrit par {Util.Pseudo} le  {Date} : {Commentaire} \n\t\t Note : {Note} \n\t  ";
        }
    }
}
