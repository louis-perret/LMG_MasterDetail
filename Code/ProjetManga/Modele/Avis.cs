using System;

namespace Modele
{
    /// <summary>
    /// Classe représentant les avis des utilisateurs
    /// </summary>
    public class Avis
    {
        public string Commentaire
        {
            get => commentaire;
            set
            {
                commentaire = value;
            }
        }
        private string commentaire;
        public int? Note { get; set; }
       
        public DateTime Date { get; set; }
        /// <summary>
        /// Constructeur de cette classe
        /// </summary>
        /// <param name="commentaire">Valeur du commentaire</param>
        public Avis(String commentaire, int note, DateTime date)
        {
            Note = note;
            Commentaire = commentaire;
            Date = date;

        }

        /// <summary>
        /// Permet de transformer une instance en chaîne de caractères
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Avis : {Commentaire} {Note} {Date}";
        }
    }
}
