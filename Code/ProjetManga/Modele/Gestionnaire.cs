using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
       //On a oublié la fonctionnalité qui permmet d'afficher les mangas suivant le genre qu'on a  cliqué
       //J'ai pensé que ça pourrait être une méthode qui prendrait le genre selectionné en paramètre et qui renverrait la collection de mangas qui correspond
       //On pourrait utiliser le système de filtrage de linq
    public class Gestionnaire 
    {

       

        public static SortedSet<Manga> GenreAuHasard(Listes l) //testé et fonctionnel ATTENTION les pb d'exceptions sont du au fait que le genre au hasard tombe sur un genre sans aucun manga parfois
        {

            Array genreDispo = Enum.GetValues(typeof(GenreDispo));
            Random random = new Random();
            int index = random.Next(0, 3);
            GenreDispo gd =(GenreDispo)genreDispo.GetValue(index);

            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in l.CollectionManga) /// jai bien besoin de ce bout de code je peux pas rappeler l'autre fonction
            {
                if (kvp.Key.NomGenre.Equals(gd))
                {
                    return kvp.Value;
                }

            }       
            return null;

        }

        /*public static HashSet<Compte> lCompte;
        public static Dictionary<Genre, SortedSet<Manga>> cManga;
        public static Listes l = new Listes(lCompte,cManga);*/
        public static void AjouterManga(Listes l, string to, string ta, string au, string dess,string maisJ,string maisFr, DateTime pTome, DateTime dTome,int nbTome, string couv, string synop, Genre g)
         {
            ///rajouter le parametre Genre dans le diagramme
            Manga m = new Manga(to, ta, au, dess, maisJ, maisFr, pTome, dTome, nbTome, couv, synop);
            l.AjouterManga(m, g);
         }

        ///pour les 2 méthodes dessous, sur de devoir passer tous les parametres ?
        public static void SupprimerManga(Listes l,Manga m, Genre g)
        {
            //Manga m = new Manga(to, ta, au, dess, maisJ, maisFr, pTome, dTome, nbTome, couv, synop);
            l.SupprimerManga(m, g);
        }

        public static void ModifierManga(Listes l,Genre g, string to, string ta, string au, string dess, string maisJ, string maisFr, DateTime pTome, DateTime dTome, int nbTome, string couv, string synop)
        {
            Manga m = new Manga(to, ta, au, dess, maisJ, maisFr, pTome, dTome, nbTome, couv, synop);
            l.ModifierManga(m, g);
        }

        public static void AjouterAvis(Listes l,Compte util, string comm, int note,Genre g, Manga m)
        {
            Avis a = new Avis(comm, note, DateTime.Today, util);
            l.AjouterAvis(a, g, m);
        }

        public static Manga MangaDuMoment(Listes l)
        {
            Manga m = l.ChercherMeilleurManga();
            return m;
        }
        /// classe du dessous : jai rajouté un parametre je voyais pass comment faire autrement
        public static void ModifierProfil(Listes l,string oldPseudo, string newPseudo, GenreDispo[] g)
        {
            l.ModifierProfil(oldPseudo, newPseudo, g);
        }

        public static Compte ChercherUtilisateur(Listes l,string pseudo, string mdp)
        {
            ///sinon si on veut pas faire comme ca, on peut envoyer un Compte dans Listes
            /// donc constructeur de Listes : public Compte ChercherUtilisateur(string pseudo, string motDePasse)
            /// et dans Listes avant de rechercher le compte on extrait son pseudo et mdp de son objet
            Compte c=l.ChercherUtilisateur(pseudo, mdp);
            return c;
        }
        ///string datenaissance a mettre dans le diagramme + supprimer dateInscription + GenreDispo g
        public static void AjouterUtilisateur(Listes l,string pse, string dateN,string mdp, GenreDispo[] g)
        {
            Compte c = new Compte(pse, dateN, DateTime.Today, mdp, g);
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
