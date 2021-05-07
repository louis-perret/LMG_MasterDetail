using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Gestionnaire ///je bug je crois, je sais pas si je dois instancier une liste ou quoi
    ///je sais pas pq, notre classe avis n'avait pas le string nomUtilisateur donc je l'ai  remis
    ///11:35 -- jarrive pas à tester la classe static, je te laisse faire si tu sais faire, jai demandé à un pote il sait pas non plus

    {
        public static HashSet<Compte> lCompte;
        public static Dictionary<Genre, SortedSet<Manga>> cManga;
        public static Listes l = new Listes(lCompte,cManga);
        public static void AjouterManga(Genre g, string to, string ta, string au, string dess,string maisJ,string maisFr, DateTime pTome, DateTime dTome,int nbTome, string couv, string synop)
         {
            ///rajouter le parametre Genre dans le diagramme
            Manga m = new Manga(to, ta, au, dess, maisJ, maisFr, pTome, dTome, nbTome, couv, synop);
            l.AjouterManga(m, g);
         }

        ///pour les 2 méthodes dessous, sur de devoir passer tous les parametres ?
        public static void SupprimerManga(Genre g, string to, string ta, string au, string dess, string maisJ, string maisFr, DateTime pTome, DateTime dTome, int nbTome, string couv, string synop)
        {
            Manga m = new Manga(to, ta, au, dess, maisJ, maisFr, pTome, dTome, nbTome, couv, synop);
            l.SupprimerManga(m, g);
        }

        public static void ModifierManga(Genre g, string to, string ta, string au, string dess, string maisJ, string maisFr, DateTime pTome, DateTime dTome, int nbTome, string couv, string synop)
        {
            Manga m = new Manga(to, ta, au, dess, maisJ, maisFr, pTome, dTome, nbTome, couv, synop);
            l.ModifierManga(m, g);
        }

        public static void AjouterAvis(string pseudo, string comm, int note,Genre g, Manga m)
        {
            Avis a = new Avis(comm, note, DateTime.Today, pseudo);
            l.AjouterAvis(a, g, m);
        }

        public static Manga MangaDuMoment()
        {
            Manga m = l.ChercherMeilleurManga();
            return m;
        }
        /// classe du dessous : jai rajouté un parametre je voyais pass comment faire autrement
        public static void ModifierProfil(string oldPseudo, string newPseudo, GenreDispo[] g)
        {
            l.ModifierProfil(oldPseudo, newPseudo, g);
        }

        public static Compte ChercherUtilisateur(string pseudo, string mdp)
        {
            ///sinon si on veut pas faire comme ca, on peut envoyer un Compte dans Listes
            /// donc constructeur de Listes : public Compte ChercherUtilisateur(string pseudo, string motDePasse)
            /// et dans Listes avant de rechercher le compte on extrait son pseudo et mdp de son objet
            Compte c=l.ChercherUtilisateur(pseudo, mdp);
            return c;
        }
        ///string datenaissance a mettre dans le diagramme + supprimer dateInscription + GenreDispo g
        public static void AjouterUtilisateur(string pse, string dateN,string mdp, GenreDispo[] g)
        {
            Compte c = new Compte(pse, dateN, DateTime.Today, mdp, g);
            l.AjouterUtilisateur(c);
        }

        public static void AjouterFavoriManga(Manga m, Compte c)
        {
            l.AjouterFavorisManga(m, c);
        }

        public static void SupprimerFavoriManga(Manga m, Compte c)
        {
            l.SupprimerFavorisManga(m, c);
        }
    }
}
