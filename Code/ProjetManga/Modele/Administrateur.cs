using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Administrateur : Utilisateur
    {
        public Administrateur(string pseudo, int age, DateTime dateInscription, string motDePasse)
        : base(pseudo, age, dateInscription, motDePasse);
    }

    public override string ToString()
    {
        return $"[Admin] {Pseudo} / {Age} / {DateInscription} / *{MotDePasse}*";
    }
}
