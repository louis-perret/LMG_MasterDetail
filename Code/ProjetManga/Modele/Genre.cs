using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Genre
    {
        public List<Manga> lesMangas; ///à modifier le type de collection maybe?

        private string description; ///a modifier dans le diagramme de classe

        public Genre(string description)
        {
            this.description = description;
            lesMangas = new List<Manga>();
        }

        public string GetDescription()
        {
            return description;
        }

        public List<Manga> GetLesMangas()
        {
            return lesMangas;
        }

        public void AjouterManga(Manga m)
        {
            if (lesMangas == null)
                lesMangas = new List<Manga>();
            lesMangas.Add(m);
        }

    }

    




}
