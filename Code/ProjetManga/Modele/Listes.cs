using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modele   
{
    public class Listes//fini et testé
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
            return null; //tester dans gestionnaire, si la valeur est null ça veut dire que le mdp ou le pseudo sont incorrects (ou que le compte n'existe pas)
        }

        public void AjouterUtilisateur(Compte c) //Les informations sur le compte sont reçues parle Gestionnaire qui l'instancie en Compte et lui envoie l'instance (faut bien qu'il serve à qqch !)
        {            
            if(!ListeCompte.Contains(c))
            {
                ListeCompte.Add(c);
            }
        }

        public void AjouterFavoriManga(Manga m, Compte c)
        {
            ChercherUtilisateur(c.Pseudo, c.MotDePasse).AjouterFavori(m);
        }

        public void SupprimerFavoriManga(Manga m, Compte c)
        {
            ChercherUtilisateur(c.Pseudo, c.MotDePasse).SupprimerFavori(m);
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
