using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;



namespace Modele
{

    /// <summary>
    /// Classe qui définit un Compte d'utilisateur
    /// </summary>
    [DataContract]
    public class Compte : IEquatable<Compte>, INotifyPropertyChanged
    {
        [DataMember]
        public ObservableCollection<Manga> LesFavoris { get; private set; } //Liste des manga préférés de l'utilisateur

        [DataMember]
        private string pseudo;
       
        public string Pseudo //Propriété Pseudo qui encapsule l'attribut pseudo
        {
            get => pseudo;
            set
            {
                    pseudo = value;
                    OnPropertyChanged(nameof(Pseudo));
            }
        }
        void OnPropertyChanged(string nomProp)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomProp));
        public int Age //Calcul l'âge à partir de la date de naissance
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - dateNaissance.Year;               
                if (dateNaissance > now.AddYears(-age))
                    age--;
                return age;
            }

        }
        [DataMember]
        public DateTime dateNaissance; //Date de naissance du compte

        public event PropertyChangedEventHandler PropertyChanged; //Evènement permettant de géré la notification de changement de nos propriétés
        [DataMember]
        public DateTime DateInscription { get; private set; }

        [DataMember]
        public string MotDePasse { get; private set; } //Mot de passe du compte


        [DataMember]
        private GenreDispo[] genresPreferes;
        public GenreDispo[] GenresPreferes //Tableau contenant entre 1 et 2 valeurs des genres préférés de l'tilisateur
        {
            get => genresPreferes;
            set
            {
                if (genresPreferes != value)
                {
                    genresPreferes = value;
                    OnPropertyChanged(nameof(GenresPreferes));
                }

            }
        }
        [DataMember]
        private string imageProfil;
        public string ImageProfil //Chemin de la photo de profil
        {
            get => imageProfil;
            set
            {
                imageProfil = value;
                OnPropertyChanged(nameof(ImageProfil));
            }
        }

        [OnDeserialized]
        void InitObservableCollection(StreamingContext sc = new StreamingContext()) //Méthode appelée après la sérialisation afin d'initialiser notre ReadOnlyCollection
        {
            LesFavoris = new ObservableCollection<Manga>();
        }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="pseudo">pseudo du compte</param>
        /// <param name="dateDeNaissance">Va permettre de donner l'age de l'utilisateur</param>
        /// <param name="dateInscription">Cette date est définie au jour de la création du compte</param>
        /// <param name="motDePasse">permet de se connecter</param>
        /// <param name="genrepref">un utilisateur peut afficher sur son profil 0 à 2 genres qu'il affectionne</param>
        /// <param name="image"> Photo de profil : "?" par defaut</param>
        public Compte(string pseudo, string dateDeNaissance, DateTime dateInscription, string motDePasse, GenreDispo[] genrepref, string image)
        {
            if (String.IsNullOrEmpty(pseudo) || String.IsNullOrEmpty(motDePasse))
            {
                throw new ArgumentException("Veuillez renseigner tous les champs");
            }
            Pseudo = pseudo;
            try
            {
                dateNaissance = Convert.ToDateTime(dateDeNaissance);
            }
            catch(Exception e)
            {
                throw new ArgumentException("Veuillez entrer le bon format de date");
            }
            DateInscription = dateInscription;
            MotDePasse = motDePasse;
            GenresPreferes = genrepref;

            LesFavoris = new ObservableCollection<Manga>();
            if (image == null)
            {
                ImageProfil = "/Image;Component/Image/question.png";
            }
            else
            {
                ImageProfil = image;
            }
        }

        /// <summary>
        /// Permet de transformer une instance en chaîne de caractères
        /// </summary>
        /// <returns>une chaine de caractere</returns>
        public override string ToString()
        {
            string r;
            r = $" {Pseudo} a {Age} ans et s'est inscrit(e) le {DateInscription}.";
            if(GenresPreferes != null)
            {
                r += "Ses genres préféres sont : \n";
                foreach (GenreDispo g in GenresPreferes)
                {
                    r += $"/{g}";
                }
            }
                
            if (LesFavoris != null)
            {
                r += "\nListe des favoris : \n";
                foreach (Manga m in LesFavoris)
                {
                    r += $"\t\t{m.TitreOriginal},";
                }
            }
            return r;
        }
        /// <summary>
        /// Modifie le profil : pseudo,genrepref et la photo de profil
        /// </summary>
        /// <param name="newPseudo">le nouveau pseudo à mettre</param>
        /// <param name="genrePref">les nouveaux genres preferes à mettre</param>
        /// <param name="imageName">photo de profil modifiée</param>
        public void ModifierProfil(string newPseudo, GenreDispo[] genrePref, string imageName)
        {
            if (String.IsNullOrEmpty(newPseudo))
            {
                throw new ArgumentException("Pseudo vide");
            }
            if (imageName == null)
            {
                imageName = "/Image;Component/Image/question.png";
            }
            Pseudo = newPseudo;
            GenresPreferes = genrePref;
            ImageProfil = imageName;
        }

        /// <summary>
        /// Ajoute un favori à la liste des favoris du Compte
        /// </summary>
        /// <param name="m">Manga qui va être rajouté à la liste</param>
        public void AjouterFavori(Manga m)
        {
            
            if (!LesFavoris.Contains(m))
            {
                LesFavoris.Add(m);
            }

        }
        /// <summary>
        /// Supprime un favori de la liste de favoris du Compte
        /// </summary>
        /// <param name="m">Manga à supprimer de la liste des favoris</param>
        public void SupprimerFavori(Manga m)
        {
            if (LesFavoris.Contains(m))
            {
                LesFavoris.Remove(m);
            }

        }
        /// <summary>
        /// Compare deux instances de Compte
        /// </summary>
        /// <param name="other">Instance à comparer</param>
        /// <returns>Renvoie true si égaux</returns>
        public bool Equals(Compte other) 
        {
            if (Pseudo == other.Pseudo && MotDePasse == other.MotDePasse)
                return true;
            return false;
        }
        /// <summary>
        /// Compare deux instances de Compte
        /// </summary>
        /// <param name="obj">Instance à comparer</param>
        /// <returns>Renvoie true si égaux</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType().Equals(obj.GetType())) return false;
            return Equals((obj as Compte));
        }

        /// <summary>
        /// Renvoie un entier identifiant une instance de compte
        /// </summary>
        /// <returns>Retourne un int</returns>
        public override int GetHashCode()
        {
            var hashCode = -1968196876;
            
            hashCode = hashCode * -1521134295 + Pseudo.GetHashCode();
           
            hashCode = hashCode * -1521134295 + MotDePasse.GetHashCode();
           
            return hashCode;
        }
    }
}
