using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Classe qui represente un manga
    /// </summary>
    //Testée & Fonctionelle
    public class Manga : IEquatable<Manga>, IComparable<Manga>, IComparable
    {           
        public string TitreOriginal { get; private set; }       

        public string TitreAlternatif { get; private set; }
        
        public string Auteur { get; private set; }
       

        public string Dessinateur { get; private set; }
        

        public string MaisonEditionJap { get; private set; }

        public string MaisonEditionFr { get; private set; } //Rajout de la maison d'édition française car on l'avait oublié


        public DateTime PremierTome { get; private set; }
        

        public DateTime? DernierTome { get; private set; }
         //Le ? permet de dire que cette variable peut-être nulle

        public int NombreTome { get; private set; }       

        public string Couverture { get; private set; } //Le prof a dit qu'il fallait tous mettre en propriété car ça serait plus simple

        public string Synopsis { get; private set; }

        public List<Avis> LesAvis { get; private set; }

        public float MoyenneNote 
        { 
            get
            {
                int nbNotes = 0;
                float sommeNotes = 0;

                if (LesAvis != null)
                {
                    foreach (Avis a in LesAvis)
                    {
                        nbNotes++;
                        
                        sommeNotes += a.Note;
                    }
                }
                return sommeNotes / nbNotes;
            }
        
        }

       

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="titreOriginal">Le titre originale de l'oeuvre (souvent en japonais)</param>
        /// <param name="titreAlternatif">Le titre alternatif de l'oeuvre (en anglais ou français)</param>
        /// <param name="auteur">Le nom de l'auteur </param>
        /// <param name="dessinateur">Le nom du dessinateur</param>
        /// <param name="maisonEdition">Le nom de la maison d'édition japonaise</param>
        /// <param name="premierTome">La date de parution du premier</param>
        /// <param name="dernierTome">La date de parution du dernier tome (null si aucune)</param>
        /// <param name="nombreTome">Nombre de tome</param>
        /// <param name="couverture">Chemin du fichier de la couverture</param>
        /// <param name="synopsis">Synopsis de l'oeuvre</param>
        public Manga(string titreOriginal, string titreAlternatif, string auteur, string dessinateur, string maisonEditionJap, string maisonEditionFr, DateTime premierTome, DateTime? dernierTome, int nombreTome, string couverture, string synopsis)
        {
            TitreOriginal = titreOriginal ?? throw new ArgumentNullException(nameof(titreOriginal));
            TitreAlternatif = titreAlternatif ?? throw new ArgumentNullException(nameof(titreAlternatif));
            Auteur = auteur ?? throw new ArgumentNullException(nameof(auteur));
            Dessinateur = dessinateur ?? throw new ArgumentNullException(nameof(dessinateur));
            MaisonEditionJap = maisonEditionJap ?? throw new ArgumentNullException(nameof(maisonEditionJap));
            MaisonEditionFr = maisonEditionFr ?? throw new ArgumentNullException(nameof(maisonEditionFr));
            PremierTome = premierTome;
            DernierTome = dernierTome;
            NombreTome = nombreTome;
            Couverture = couverture ?? throw new ArgumentNullException(nameof(couverture));
            Synopsis = synopsis ?? throw new ArgumentNullException(nameof(synopsis));
        }

        /// <summary>
        /// Permet de transformer une instance en chaîne de caractères
        /// </summary>
        public override string ToString() /// testé et fonctionne
        {
            string r;
            r= $"[Manga] {TitreOriginal} / {TitreAlternatif} / {Auteur} / {Dessinateur} / {MaisonEditionJap} / {MaisonEditionFr}/ {PremierTome} / {DernierTome} / {NombreTome} / {Synopsis} / {MoyenneNote} \n";
            
            
            if (LesAvis != null)
            {
                r += "\n\t\tListe des avis : \n";
                foreach (Avis a in LesAvis)
                {
                    r += "\n\t\t" + a;
                }
            }

            return r;
        }

       

        /// <summary>
        /// Ajoute un avis dans la collection des avis de l'instance de manga concernée
        /// </summary>
        /// <param name="a"> Avis à ajouter </param>
        public void AjouterAvis(Avis a)
        {
            if (LesAvis == null)
            {
                LesAvis = new List<Avis>();
            }
            LesAvis.Add(a);

        }

        public bool Equals(Manga other)
        {
            if (TitreOriginal == other.TitreOriginal && TitreAlternatif == other.TitreAlternatif)
                return true;
            return false;
        }



        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType().Equals(obj.GetType())) return false;
            return Equals((obj as Manga));
        }

        public override int GetHashCode()
        {
            var hashCode = -1862994041;
            hashCode = hashCode * -1521134295 + TitreOriginal.GetHashCode();
            hashCode = hashCode * -1521134295 + TitreAlternatif.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Manga other)
        {
            return TitreOriginal.CompareTo(other.TitreOriginal);
        }

        int IComparable.CompareTo(object obj)
        {
            if(!(obj is Manga))
            {
                throw new ArgumentException("Pas un manga");
            }
            Manga autreManga = obj as Manga;
            return this.CompareTo(autreManga);
        }
    }
}
