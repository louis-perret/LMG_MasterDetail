using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    ///je suis pas sur pour ajouter/supprimer les mangas
    public class Administrateur : Utilisateur
    {
        public Administrateur(string pseudo, int age, DateTime dateInscription, Genre genrepref, string motDePasse)
        : base(pseudo, age, dateInscription,genrepref, motDePasse)
        { }

        public override string ToString() ///testé
        {
            return $"[Admin] {Pseudo} / {Age} / {DateInscription}/ {GenresPreferes} / *{MotDePasse}*";
        }

        public void AjouterManga(Manga m, List<Manga> lm) /// testé
        {
            lm.Add(m);
        }

        public void SupprimerManga(Manga m, List<Manga> lm)
        {
            lm.Remove(m);
        }
        public void ModifierManga(Manga ancienManga, Manga nouvManga, List<Manga> lm)
        {
            if(!lm.Contains(nouvManga))
            {
                SupprimerManga(ancienManga,lm);
                AjouterManga(nouvManga, lm);
            }
        }

    }

   
}
