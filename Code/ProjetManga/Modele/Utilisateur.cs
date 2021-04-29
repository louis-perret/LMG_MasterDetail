using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Utilisateur
    {
        public List<Manga> LesFavoris;
        public string Pseudo { get; set; }

        public int Age { get; set; }

        public DateTime DateInscription { get; set; }

        public string MotDePasse { get; set; }


        public Utilisateur(string pseudo, int age, DateTime dateInscription, string motDePasse )
        {
            Pseudo = pseudo ?? throw new ArgumentNullException(nameof(pseudo));
            Age = age;
            DateInscription = dateInscription;
            MotDePasse = motDePasse ?? throw new ArgumentNullException(nameof(motDePasse));

            LesFavoris = new List<Manga>();
            
        }

        public override string ToString()
        {
            return $"[Utilisateur] {Pseudo} / {Age} / {DateInscription} / *{MotDePasse}*";
        }

        public override bool Equals(object obj)
        {
            if(Pseudo == ((Utilisateur)obj).Pseudo && MotDePasse == ((Utilisateur)obj).MotDePasse)
                return true;
            return false;
        }

        public void AjouterFavori(Manga m)
        {
            if(LesFavoris==null)
            {
                LesFavoris = new List<Manga>();
            }
            LesFavoris.Add(m);

        }
        public void SupprimerFavori(Manga m)
        {
            if (LesFavoris.Contains(m));
            {
                LesFavoris.Remove(m);
            } 
            
        }

    }
}
