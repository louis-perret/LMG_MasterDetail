using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Classe qui represente un manga
    /// </summary>
    public class Manga
    {
        
        public string TitreOriginal { get; set; }
        ///private string titreOriginal --> vu avec le prof, ne sert à rien a part pour stocker des données donc pas utile dans ce cas 
        ///On met donc ca quand on a besoin de recalculer/modifier dans le setter

        public string TitreAlternatif { get; set; }
        

        public string Auteur { get; set; }
       

        public string Dessinateur { get; set; }
        

        public string MaisonEdition { get; set; }
        

        public DateTime PremierTome { get; set; }
        

        public DateTime? DernierTome { get; set; }
         //Le ? permet de dire que cette variable peut-être nulle

        public int NombreTome { get; set; }
        

        private string couverture;

        public string Synopsis { get; set; }

        /* a completer 
         public string SommeNote
         {
             get
             {
                 return (un truc + sommeNote)
             }
         }
         private string sommeNote;

        */

        /// <summary>
        /// Constructeur de cette classe
        /// </summary>
        /// <param name="commentaire">Valeur du commentaire</param>
        public Manga(string titreOriginal, string titreAlternatif, string auteur, string dessinateur, string maisonEdition, DateTime premierTome, DateTime? dernierTome, int nombreTome, string couverture, string synopsis)
        {
            TitreOriginal = titreOriginal ?? throw new ArgumentNullException(nameof(titreOriginal));
            TitreAlternatif = titreAlternatif ?? throw new ArgumentNullException(nameof(titreAlternatif));
            Auteur = auteur ?? throw new ArgumentNullException(nameof(auteur));
            Dessinateur = dessinateur ?? throw new ArgumentNullException(nameof(dessinateur));
            MaisonEdition = maisonEdition ?? throw new ArgumentNullException(nameof(maisonEdition));
            PremierTome = premierTome;
            DernierTome = dernierTome;
            NombreTome = nombreTome;
            this.couverture = couverture ?? throw new ArgumentNullException(nameof(couverture));
            Synopsis = synopsis ?? throw new ArgumentNullException(nameof(synopsis));
        }

        /// <summary>
        /// Permet de transformer une instance en chaîne de caractères
        /// </summary>
        public override string ToString()
        {
            return $"[Manga] {TitreOriginal} / {TitreAlternatif} / {Auteur} / {Dessinateur} / {MaisonEdition} / {PremierTome} / {DernierTome} / {NombreTome} / {Synopsis}";
        }

        public override bool Equals(object obj)
        {
            if (TitreOriginal == ((Manga)obj).TitreOriginal && Auteur == ((Manga)obj).Auteur)
                return true;
            return false;
        }

        public void AjouterAvis()
        {
            Console.WriteLine("Saisir votre avis :");
            Avis a = new Avis(Console.ReadLine());
            ///completer
            Console.WriteLine("Votre avis a bien été saisi, merci !");
            Console.WriteLine("Votre avis :");
            Console.WriteLine(a);

        }
       


    }
}
