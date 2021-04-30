using System;
using System.Collections.Generic;
using System.Text;

/// A FINIR : comment on peut lier le nom du genre par rapport à sa description ?
/// Louis -> Réponse : Tout simplement en indiquant que le nom est de type de l'énumération GenreDispo
/// Louis -> Testée et fontionne (j'ai essayé les expcetions mais je galère un peu
namespace Modele
{
    public class Genre
    {
        public string Description { get; set; }

        public GenreDispo NomGenre { get; set; }

        public Genre(string description, GenreDispo type)
        {
            NomGenre = type;
            /*if(String.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description requise");
            }*/
            Description = description;
        }

        /*public List<Manga> GetLesMangas()
        {
            return lesMangas;
        }*/

        /*public void AjouterManga(Manga m) ///testé mais utile ? meme methode dans admin (je me perd surement) 
                                          ///Réponse : La méthode admin ajouterManga appelera cette m
        {
            if (lesMangas == null)
                lesMangas = new List<Manga>();
            lesMangas.Add(m);
        }*/

        public override bool Equals(object obj)
        {
            return obj is Genre genre &&
                   Description == genre.Description;
        }


        /*public override string ToString() ///testé
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
        }*/
        public override string ToString() ///testé
        {
            string r;
            r = $"{NomGenre} : {Description} \n";
            return r;
        }


    }



}
