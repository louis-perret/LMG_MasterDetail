using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Classe réprésentant les genres disponibles de notre application
    /// </summary>
    public class Genre : IEquatable<Genre>  
    {
        public string Description { get; private set; } //Description du genre

        public GenreDispo NomGenre { get; private set; } //Nom du genre à partir de l'enum

        public Genre(string description, GenreDispo type)
        {
            NomGenre = type;
            /*if(String.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description requise");
            }*/
            Description = description;
        }

       


       /// <summary>
       /// Renvoie sous forme de chaîne de caractères l'objet appelant
       /// </summary>
       /// <returns></returns>
        public override string ToString()
        {
            string r;
            r = $"{NomGenre} : {Description} \n";
            return r;
        }

        /// <summary>
        /// Premier Equals de la classe
        /// </summary>
        /// <param name="other">Instance à comparer</param>
        /// <returns>Renvoie true si égaux</returns>
        public bool Equals(Genre other)
        {
            return NomGenre.Equals(other.NomGenre)
                && Description == other.Description;
        }

        /// <summary>
        /// Deuxième equals de la classe
        /// </summary>
        /// <param name="obj">Instance castée en objet à comparer</param>
        /// <returns>Renvoie true si égaux</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType().Equals(obj.GetType())) return false;
            return Equals((obj as Genre));
        }

        /// <summary>
        /// Renvoie un nombre permettant d'identifier une instance de Genre dans une collection
        /// </summary>
        /// <returns>Retourne un int</returns>
        public override int GetHashCode()
        {
            var hashCode = -1633598879;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + NomGenre.GetHashCode();
            return hashCode;
        }
    }



}
