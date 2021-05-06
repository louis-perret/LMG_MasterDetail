using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Listes
    {
        public HashSet<Compte> ListeCompte { get; private set; }
        public Dictionary<Genre, SortedSet<Manga>> CollectionManga { get; private set; }

        public Listes(HashSet<Compte> lCompte, Dictionary<Genre, SortedSet<Manga>> cManga)
        {
            ListeCompte = lCompte;
            CollectionManga = cManga;

        }

        public override string ToString()
        {
            string r= "Liste des comptes : \n\n ";
           
            foreach(Compte c in ListeCompte)
            {
                r += $"{c} \n";
            }
            r += " Collection de mangas : \n\n ";
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                r += $"{kvp.Key} : \n ";
                foreach (Manga m in kvp.Value)
                {
                    r += $"{m} \n";
                }
            }
            return r;
        }


    }
}
