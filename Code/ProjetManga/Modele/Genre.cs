using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Genre : IEquatable<Genre>  
    {
        public string Description { get; private set; }

        public GenreDispo NomGenre { get; private set; }

        public Genre(string description, GenreDispo type)
        {
            NomGenre = type;
            /*if(String.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description requise");
            }*/
            Description = description;
        }

       


       
        public override string ToString()
        {
            string r;
            r = $"{NomGenre} : {Description} \n";
            return r;
        }

        public bool Equals(Genre other)
        {
            return NomGenre.Equals(other.NomGenre)
                && Description == other.Description;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType().Equals(obj.GetType())) return false;
            return Equals((obj as Genre));
        }

        public override int GetHashCode()
        {
            var hashCode = -1633598879;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + NomGenre.GetHashCode();
            return hashCode;
        }
    }



}
