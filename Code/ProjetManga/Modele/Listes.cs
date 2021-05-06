using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AjouterManga(Manga m, Genre g)
        {
            foreach(KeyValuePair<Genre,SortedSet<Manga>> kvp in CollectionManga)
            {
                if (kvp.Key.Equals(g))
                {
                    if (!kvp.Value.Contains(m))
                    {
                        kvp.Value.Add(m);
                    }
                }
            }
        }

        public void SupprimerManga(Manga m, Genre g)
        {
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                if (kvp.Key.Equals(g))
                {
                    if (kvp.Value.Contains(m))
                    {
                        kvp.Value.Remove(m);
                    }
                }
            }
        }

        public void ModifierManga(Manga m, Genre g)
        {
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                if (kvp.Key.Equals(g))
                {
                    foreach(Manga manga in kvp.Value)
                    {
                        if (manga.Equals(m))
                        {
                            kvp.Value.Remove(manga);
                            kvp.Value.Add(m);
                            break;
                        }
                    }
                }
            }
        }

        public void AjouterAvis(Avis a, Genre g, Manga m)
        {
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                if (kvp.Key.Equals(g))
                {
                    foreach (Manga man in kvp.Value)
                    {
                        if (man.Equals(m))
                        {
                            man.LesAvis.Add(a);
                        }
                    }
                }
            }
        }

        public Manga ChercherMeilleurManga()
        {
            Manga leMeilleur = new Manga("test", "test", "test", "test", "test", "test", new DateTime(2000), new DateTime(2001), 1, "/test/", "testtest");

            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                //var m = kvp.Value.Max(man => man.MoyenneNote);
                foreach (Manga man in kvp.Value)
                {
                    if (man.MoyenneNote > leMeilleur.MoyenneNote)
                    {
                        leMeilleur = man;
                    }
                }
            }
            return leMeilleur;

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
