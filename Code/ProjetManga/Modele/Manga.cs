using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Classe qui represente un manga
    /// </summary>
    public class Manga : IEquatable<Manga>, IComparable<Manga>, IComparable
    {           
        public string TitreOriginal { get; private set; }       

        public string TitreAlternatif { get; private set; }
        
        public string Auteur { get; private set; }
       

        public string Dessinateur { get; private set; }
        

        public string MaisonEditionJap { get; private set; }

        public string MaisonEditionFr { get; private set; } 


        public DateTime PremierTome { get; private set; }
        

        public DateTime? DernierTome { get; private set; }
         //Le ? permet de dire que cette variable peut-être nulle

        public int NombreTome { get; private set; }       

        public string Couverture { get; private set; }

        public string Synopsis { get; private set; }

        public GenreDispo Genre { get; private set; }

        public IList<Avis> LesAvis { get; private set; }

        public float MoyenneNote //Renvoie la moyenne des notes de tous ses avis
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
                if (nbNotes == 0)
                {
                    return 0;
                }
                else
                {
                    return sommeNotes / nbNotes;
                }
            }
        
        }

       

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="titreOriginal">Le titre originale de l'oeuvre (souvent en japonais)</param>
        /// <param name="titreAlternatif">Le titre alternatif de l'oeuvre (en anglais ou français)</param>
        /// <param name="auteur">Le nom de l'auteur </param>
        /// <param name="dessinateur">Le nom du dessinateur</param>
        /// <param name="maisonEditionJap">Le nom de la maison d'édition japonaise</param>
        /// <param name="maisonEditionFr">Le nom de la maison d'édition française </param>
        /// <param name="premierTome">La date de parution du premier</param>
        /// <param name="dernierTome">La date de parution du dernier tome (null si aucune)</param>
        /// <param name="nombreTome">Nombre de tome</param>
        /// <param name="couverture">Chemin du fichier de la couverture</param>
        /// <param name="synopsis">Synopsis de l'oeuvre</param>
        /// <param name="g">Genre du manga</param>
        public Manga(string titreOriginal, string titreAlternatif, string auteur, string dessinateur, string maisonEditionJap, string maisonEditionFr, DateTime premierTome, DateTime? dernierTome, int nombreTome, string couverture, string synopsis, GenreDispo g)
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
            Genre = g;
        }

        /// <summary>
        /// Permet de transformer une instance en chaîne de caractères
        /// </summary>
        public override string ToString() 
        {
            string r;
            r= $"[Manga] {TitreOriginal} / {TitreAlternatif} \n Auteur : {Auteur} / Dessinateur : {Dessinateur} \n Maison D'édition Jap/Fr : {MaisonEditionJap} / {MaisonEditionFr} \n Premier tome : {PremierTome} Dernier tome : {DernierTome} Nombre de tome : {NombreTome} \n\n Synopsis : {Synopsis} \n\n Note :{MoyenneNote} \n";           
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

        /// <summary>
        /// Modifie certaines des propriétés d'un manga
        /// </summary>
        /// <param name="dTome">Date du dernier tome</param>
        /// <param name="nbTome">Nombre de tome total</param>
        /// <param name="couv">"Noueau chemin de la couverture</param>
        /// <param name="synop">"Nouveau synopsis</param>
        public void Modifier(DateTime dTome, int nbTome, string couv, string synop)
        {
            if(PremierTome < dTome && DernierTome <= dTome)
            {
                DernierTome = dTome;
            }
            
            if(NombreTome <= nbTome)
            {
                NombreTome = nbTome;
            }           
            Couverture = couv;
            Synopsis = synop;
        }

        /// <summary>
        /// Compare deux instances de Manga
        /// </summary>
        /// <param name="other">Instance à comparer</param>
        /// <returns>Renvoie true si égaux</returns>
        public bool Equals(Manga other)
        {
            if (TitreOriginal == other.TitreOriginal && TitreAlternatif == other.TitreAlternatif)
                return true;
            return false;
        }


        /// <summary>
        /// Compare deux instances de Manga
        /// </summary>
        /// <param name="obj">Instance castée en object à comparer</param>
        /// <returns>Retourne un true si égaux</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType().Equals(obj.GetType())) return false;
            return Equals((obj as Manga));
        }

        /// <summary>
        /// Renvoie un entier identifiant une instance d'un manga
        /// </summary>
        /// <returns>Retourne un int</returns>
        public override int GetHashCode()
        {
            var hashCode = -1862994041;
            hashCode = hashCode * -1521134295 + TitreOriginal.GetHashCode();
            hashCode = hashCode * -1521134295 + TitreAlternatif.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Compare deux instances puis renvoie un int
        /// </summary>
        /// <param name="other">Instance à comparer</param>
        /// <returns>int</returns>
        public int CompareTo(Manga other)
        {
            return TitreOriginal.CompareTo(other.TitreOriginal);
        }

        /// <summary>
        /// Compare deux instances puis renvoie un int
        /// </summary>
        /// <param name="obj">Instance à comparer</param>
        /// <returns>int</returns>
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
