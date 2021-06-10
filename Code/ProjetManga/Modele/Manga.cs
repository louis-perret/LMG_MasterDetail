using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract]
    /// <summary>
    /// Classe qui represente un manga
    /// </summary>
    public class Manga : IEquatable<Manga>, IComparable<Manga>, IComparable, INotifyPropertyChanged
    {
        void OnPropertyChanged(string nomProp)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomProp));
        [DataMember]
        public string TitreOriginal { get; private set; }
        [DataMember]
        public string TitreAlternatif { get; private set; }
        [DataMember]
        public string Auteur { get; private set; }

        [DataMember]
        public string Dessinateur { get; private set; }

        [DataMember]
        public string MaisonEditionJap { get; private set; }
        [DataMember]
        public string MaisonEditionFr { get; private set; }

        [DataMember]
        public DateTime PremierTome { get; private set; }
        public string DatePremierTome
        {
            get => PremierTome.ToString("d");
        }

        [DataMember]
        public DateTime DernierTome { get; private set; }
        public string DateDernierTome
        {
            get
            {
                if(DernierTome == null)
                {
                    return "En cours de parutions";
                }
                return DernierTome.ToString("d");
            }
        }

        [DataMember]
        private int nombreTome;
        public int NombreTome
        {
            get => nombreTome;
            set
            {
                if (nombreTome != value)
                {
                    nombreTome = value;
                    OnPropertyChanged(nameof(NombreTome));
                }

            }
        }
        [DataMember]
        private string couverture;
        public string Couverture
        {
            get => couverture;
            set
            {
                if (couverture != value) 
                {
                    couverture = value;
                    OnPropertyChanged(nameof(Couverture));
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        private string synopsis;
        public string Synopsis
        {
            get => synopsis;
            set
            {
                if (synopsis != value)
                {
                    synopsis = value;
                    OnPropertyChanged(nameof(Synopsis));
                }

            }
        }
        [DataMember]
        public GenreDispo Genre { get; private set; }

        [DataMember]
        public ObservableCollection<Avis> LesAvis { get; private set; } = new ObservableCollection<Avis>();
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
        public Manga(string titreOriginal, string titreAlternatif, string auteur, string dessinateur, string maisonEditionJap, string maisonEditionFr, string premierTome, string dernierTome, int nombreTome, string couverture, string synopsis, GenreDispo g)
        {
            if(String.IsNullOrEmpty(titreOriginal) || String.IsNullOrEmpty(titreAlternatif) || String.IsNullOrEmpty(auteur) || String.IsNullOrEmpty(dessinateur) || String.IsNullOrEmpty(maisonEditionJap) || String.IsNullOrEmpty(maisonEditionFr)
                || String.IsNullOrEmpty(synopsis))
            {
                throw new ArgumentException("Veuillez rentrer toutes les informations");
            }
            TitreOriginal = titreOriginal;
            TitreAlternatif = titreAlternatif;
            Auteur = auteur;
            Dessinateur = dessinateur;
            MaisonEditionJap = maisonEditionJap;
            MaisonEditionFr = maisonEditionFr;
            try
            {
                PremierTome = Convert.ToDateTime(premierTome);
                if (!String.IsNullOrEmpty(dernierTome))
                {
                    DernierTome = Convert.ToDateTime(dernierTome);
                }
            }
            catch(Exception e)
            {
                throw new ArgumentException("Problème dans le format des dates");
            }
            NombreTome = nombreTome;
            Couverture = couverture;
            Synopsis = synopsis;
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
    
            LesAvis.Add(a);
            OnPropertyChanged(nameof(MoyenneNote));
        }

        /// <summary>
        /// Modifie certaines des propriétés d'un manga
        /// </summary>
        /// <param name="dTome">Date du dernier tome</param>
        /// <param name="nbTome">Nombre de tome total</param>
        /// <param name="couv">"Noueau chemin de la couverture</param>
        /// <param name="synop">"Nouveau synopsis</param>
        public void Modifier(string dTome, int nbTome, string couv, string synop)
        {
            if (String.IsNullOrEmpty(synop) || String.IsNullOrEmpty(couv))
            {
                throw new ArgumentException("Veuillez renseigner tous les champs");
            }

            if (!String.IsNullOrEmpty(dTome))
            {
                try
                {
                    DateTime dernierTome = Convert.ToDateTime(dTome);
                    if (PremierTome < dernierTome && DernierTome <= dernierTome)
                    {
                        DernierTome = dernierTome;
                        OnPropertyChanged(nameof(DateDernierTome));
                    }
                    else
                    {
                        throw new ArgumentException("La date de parution du dernier tome n'est pas bonne");
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("La date de parution du dernier tome n'est pas bonne");
                }
            }
           

            if (NombreTome > nbTome)
            {
                throw new ArgumentException("Nombre de tome incorrecte");
            }

            Couverture = couv;
            Synopsis = synop;
            NombreTome = nbTome;
        }

        /// <summary>
        /// Compare deux instances de Manga
        /// </summary>
        /// <param name="other">Instance à comparer</param>
        /// <returns>Renvoie true si égaux</returns>
        public bool Equals(Manga other)
        {
            if (other == null) return false;
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
