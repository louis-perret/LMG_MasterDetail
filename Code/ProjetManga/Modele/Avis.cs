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
       
        public string NomUtil { get; private set; }
        public DateTime Date { get; private set; }
        /// <summary>
        /// Constructeur de cette classe
        /// </summary>
        /// <param name="commentaire">Valeur du commentaire</param>
        public Avis(String commentaire, int note, DateTime date, string nomUtil)
        {
            Note = note;
            Commentaire = commentaire;
            Date = date;
            NomUtil = nomUtil;

        }

        /// <summary>
        /// Permet de transformer une instance en chaîne de caractères
        /// </summary>
        /// <returns></returns>
        public override string ToString() ///testé
        {
            return $" écrit par {NomUtil} le  {Date} : {Commentaire} \n\t\t Note : {Note} \n\t  ";
        }
    }
}
