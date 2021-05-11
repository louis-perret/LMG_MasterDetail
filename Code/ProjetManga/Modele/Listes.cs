using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modele   
{
    public class Listes
{
        public IList<Compte> ListeCompte { get; private set; } 
        public Dictionary<Genre, SortedSet<Manga>> CollectionManga { get; private set; }

        public Listes(List<Compte> lCompte, Dictionary<Genre, SortedSet<Manga>> cManga)
        {
            ListeCompte = lCompte;
            CollectionManga = cManga;

        }

       public Genre RecupererGenre(GenreDispo nomGenre)
       {
            var genres = CollectionManga.Keys;
            var g = from genre in genres
                      where genre.NomGenre.Equals(nomGenre)
                      select genre;
            return g.FirstOrDefault();
        }

        public SortedSet<Manga> ListeParGenre(Genre g) 
        {
            SortedSet<Manga> listeDuGenre = new SortedSet<Manga>();
            var temp = from k in CollectionManga

                       where k.Key.NomGenre.Equals(g.NomGenre)
                       select k.Value;

            foreach (var t in temp)
            {

                foreach (Manga m in t)
                {
                    listeDuGenre.Add(m);
                }
            }
            return listeDuGenre;


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

        public void ModifierManga(Genre g, string to, DateTime dTome, int nbTome, string couv, string synop)
        {
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                if (kvp.Key.Equals(g))
                {
                    foreach(Manga manga in kvp.Value)
                    {
                        if (manga.TitreOriginal.Equals(to))
                        {
                            manga.Modifier(dTome, nbTome, couv, synop);
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
                            man.AjouterAvis(a);
                        }
                    }
                }
            }
        }

        public Manga ChercherMeilleurManga()
        {
            Manga leMeilleur = new Manga("test", "test", "test", "test", "test", "test", new DateTime(2000), new DateTime(2001), 1, "/test/", "testtest",GenreDispo.Shonen);

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

        public void ModifierProfil(string oldPseudo, string newPseudo, GenreDispo[] genrePref)
        {
            foreach(Compte compte in ListeCompte)
            {
                if (compte.Pseudo.Equals(oldPseudo))
                {
                    compte.ModifierProfil(newPseudo, genrePref);
                }
            }
        }

        public Compte ChercherUtilisateur(string pseudo, string motDePasse)
        {
            foreach(Compte c in ListeCompte)
            {
                if(c.Pseudo.Equals(pseudo) && c.MotDePasse.Equals(motDePasse))
                {
                    return c;
                }
            }
            return null; 
        }

        public void AjouterUtilisateur(Compte c)
        {            
            if(!ListeCompte.Contains(c))
            {
                ListeCompte.Add(c);
            }
        }

        public void AjouterFavoriManga(Manga m, Compte c)
        {
            c.AjouterFavori(m);
        }

        public void SupprimerFavoriManga(Manga m, Compte c)
        {
            c.SupprimerFavori(m);
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
