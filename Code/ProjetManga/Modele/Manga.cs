using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Manga
    {
        public string TitreOriginal { get; set; }
        private string titreOriginal;

        public string TitreAlternatif { get; set; }
        private string titreAlternatif;

        public string Auteur { get; set; }
        private string auteur;

        public string Dessinateur { get; set; }
        private string dessinateur;

        public string MaisonEdition { get; set; }
        private string maisonEdition;

        public DateTime PremierTome { get; set; }
        private DateTime premierTome;

        public DateTime? DernierTome { get; set; }
        private DateTime? dernierTome; //Le ? permet de dire que cette variable peut-être nulle

        public int NombreTome { get; set; }
        private int nombreTome;

        private string couverture;

        public string Synopsis { get; set; }
        private string synopsis;

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

        /*public override string ToString()
        {
            return $"Manga {TitreOriginal}/{TitreAlternatif} : ";
        } A Finir*/

    }
}
