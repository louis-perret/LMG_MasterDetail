using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Modele
{
    public class Gestionnaire 
    {

       

        public static SortedSet<Manga> GenreAuHasard(Listes l, out Genre g) 
        {
            Dictionary<Genre, SortedSet<Manga>> genreHasard = new Dictionary<Genre, SortedSet<Manga>>();

            Array genreDispo = Enum.GetValues(typeof(GenreDispo));
            Random random = new Random();
            int index = random.Next(1, 4);
            GenreDispo gd =(GenreDispo)genreDispo.GetValue(index);
            g = l.RecupererGenre(gd);
            return l.ListeParGenre(g);              
        }

        public static void AjouterManga(Listes l, string to, string ta, string au, string dess,string maisJ,string maisFr, DateTime pTome, DateTime dTome,int nbTome, string couv, string synop,GenreDispo g)
         {
            Manga m = new Manga(to, ta, au, dess, maisJ, maisFr, pTome, dTome, nbTome, couv, synop,g);
            l.AjouterManga(m, l.RecupererGenre(g));
         }
        
        public static void SupprimerManga(Listes l,Manga m, GenreDispo g)
        {            
            l.SupprimerManga(m, l.RecupererGenre(g));
        }

        public static void ModifierManga(Listes l, GenreDispo g, string to, DateTime dTome, int nbTome, string couv, string synop)
        {           
            l.ModifierManga(l.RecupererGenre(g), to, dTome, nbTome, couv, synop);
        }

        public static Manga RechercherMangaParNom(Listes l, string nomManga)
        {
            Manga m=null;
            foreach(KeyValuePair<Genre,SortedSet<Manga>> kvp in l.CollectionManga)
            {
                var Manga = kvp.Value.Where(manga => manga.TitreOriginal.ToLower().Equals(nomManga.ToLower()));
                if(Manga.Count<Manga>() != 0)
                {
                    m = Manga.FirstOrDefault();
                    return m;
                }
            }
            return m;
        }
        public static void AjouterAvis(Listes l,Compte util, string comm, int note,GenreDispo g, Manga m)
        {
            Avis a = new Avis(comm, note, util);
            l.AjouterAvis(a, l.RecupererGenre(g), m);
        }

        public static Manga MangaDuMoment(Listes l)
        {
            Manga m = l.ChercherMeilleurManga();
            return m;
        }
        
        public static void ModifierProfil(Listes l,string oldPseudo, string newPseudo, GenreDispo[] g)
        {
            l.ModifierProfil(oldPseudo, newPseudo, g);
        }

        public static bool ChercherUtilisateur(Listes l, string pseudo, string mdp)
        {

            bool c = l.ChercherUtilisateur(pseudo, mdp);
            return c;
        }
        
        public static void AjouterUtilisateur(Listes l,string pse, string dateN,string mdp, GenreDispo[] g, string photo_profil)
        {
            Compte c = new Compte(pse, dateN, DateTime.Today, mdp, g,photo_profil);
            l.AjouterUtilisateur(c);
        }

        public static void AjouterFavoriManga(Listes l, Manga m, Compte c)
        {
            l.AjouterFavoriManga(m, c);
        }

        public static SortedSet<Manga> ListeParGenre(Listes l,Genre g)
        {
            SortedSet<Manga> listeMangaParGenre = new SortedSet<Manga>();
            listeMangaParGenre = l.ListeParGenre(g);
            return listeMangaParGenre;
        }
        public static void SupprimerFavoriManga(Listes l,Manga m, Compte c)
        {
            l.SupprimerFavoriManga(m, c);
        }

        
    }
}
