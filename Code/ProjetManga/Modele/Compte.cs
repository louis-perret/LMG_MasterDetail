using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;



namespace Modele
{
    /// <summary>
    /// Classe qui définit un Compte d'utilisateur
    /// </summary>
    public class Compte : IEquatable<Compte>
    {
        public ReadOnlyCollection<Manga> LesFavoris { get; private set; }
        
        IList<Manga> lesFavoris;

        public string Pseudo { get; private set; }

        public int Age 
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

        private DateTime dateNaissance;

        public DateTime DateInscription { get; private set; }

        public string MotDePasse { get; private set; }

        public GenreDispo[] GenresPreferes { get; private set; }

        public string ImageProfil { get; private set; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="pseudo">pseudo du compte</param>
        /// <param name="dateDeNaissance">Va permettre de donner l'age de l'utilisateur</param>
        /// <param name="dateInscription">Cette date est définit au jour de la création du compte</param>
        /// <param name="motDePasse">permet de se connecter</param>
        /// <param name="genrepref">un utilisateur peut afficher sur son profil 0 à 2 genres qu'il affectionne</param>
        public Compte(string pseudo, string dateDeNaissance, DateTime dateInscription, string motDePasse, GenreDispo[] genrepref, string image)
        {
            Pseudo = pseudo ?? throw new ArgumentNullException(nameof(pseudo));
            dateNaissance = Convert.ToDateTime(dateDeNaissance);
            
            DateInscription = dateInscription;
            MotDePasse = motDePasse ?? throw new ArgumentNullException(nameof(motDePasse));
            GenresPreferes = genrepref;

            lesFavoris = new List<Manga>();
            LesFavoris = new ReadOnlyCollection<Manga>(lesFavoris);
            ImageProfil = image;

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
        /// Modifie le profil : pseudo et genrepref uniquement
        /// </summary>
        /// <param name="newPseudo">le nouveau pseudo à mettre</param>
        /// <param name="genrePref">les nouveaux genres preferes à mettre</param>
        public void ModifierProfil(string newPseudo, GenreDispo[] genrePref)
        {
            Pseudo = newPseudo;
            GenresPreferes = genrePref;
        }

        /// <summary>
        /// Ajoute un favori à la liste des favoris du Compte
        /// </summary>
        /// <param name="m">Manga qui va etre rajouté à la liste</param>
        public void AjouterFavori(Manga m)
        {
            /*if (LesFavoris == null)
            {
                LesFavoris = new List<Manga>();                
            }*/
            if (!LesFavoris.Contains(m))
            {
                lesFavoris.Add(m);
            }

        }
        /// <summary>
        /// Supprime un favori de la liste de favoris du Compte
        /// </summary>
        /// <param name="m">Manga a supprimer de la liste des favoris</param>
        public void SupprimerFavori(Manga m)
        {
            if (LesFavoris.Contains(m))
            {
                lesFavoris.Remove(m);
            }

        }
        /// <summary>
        /// Compare deux instances de Manga
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
        /// Compare deux instances de Manga
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
        /// Renvoie un entier identifiant une instance d'un manga
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
