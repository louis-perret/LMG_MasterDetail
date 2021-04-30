using System;
using System.Collections.Generic;
using System.Text;

/// A FINIR : comment on peut lier le nom du genre par rapport à sa description ?
///  ToString qui affiche la liste  des collections est testée est marche

namespace Modele
{
    public class Genre
    {
        public List<Manga> lesMangas; ///à modifier le type de collection maybe?

        private string description; ///a modifier dans le diagramme de classe

        private string nomGenre;

        public Genre(string description)
        {
            this.description = description;
            lesMangas = new List<Manga>();
        }

        public string GetDescription()
        {
            return description;
        }

        public string getNomGenre()
        {
            return nomGenre; 
        }
        public List<Manga> GetLesMangas()
        {
            return lesMangas;
        }

        public void AjouterManga(Manga m) ///testé mais utile ? meme methode dans admin (je me perd surement)s
        {
            if (lesMangas == null)
                lesMangas = new List<Manga>();
            lesMangas.Add(m);
        }

        public override bool Equals(object obj)
        {
            return obj is Genre genre &&
                   description == genre.description;
        }


        public override string ToString() ///testé
        {
            string r;
            r = $"[Genre] {description} \n";
            if(lesMangas!=null)
            {
                r += "Liste des mangas : \n";
                foreach (Manga m in lesMangas)
                {
                    r += "\n\t\t" + m;
                }
            }
 
            return r;
        }
    }

    




}
