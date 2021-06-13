using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Modele   
{
    /// <summary>
    /// Classe qui va etre serialisée et qui va effectuer les méthodes sur nos classes
    /// </summary>

    [DataContract]
    public class Listes : INotifyPropertyChanged
{
        
        [DataMember]
        private IList<Compte> listeCompte { get; set; }

        public ReadOnlyCollection<Compte> ListeCompte { get; private set; } //Liste des Comptes 

        [DataMember]
        private IDictionary<Genre, SortedSet<Manga>> collectionManga { get; set; }
       
        public ReadOnlyDictionary<Genre,SortedSet<Manga>> CollectionManga { get; private set; } //Dictionnaire de tous les mangas
        
       
        [DataMember]
        public IList<Genre> ListeGenre { get; private set; } //Liste des genres existants de notre application

        private Compte compte;
        public Compte CompteCourant //Compte connecté sur l'application
        { 
            get => compte;  
            set
            {
                if (compte !=value)
                {
                    compte = value;
                    OnPropertyChanged(nameof(CompteCourant));
                }
            }
        }
        private Genre genreCourant { get; set; }
        public Genre GenreCourant  //Genre actuellement selectionné
        {
            get => genreCourant;
            set
            {
                if (genreCourant != value)
                {
                    genreCourant = value;
                    OnPropertyChanged(nameof(GenreCourant));
                }
            }
        }

        [DataMember]
        public ObservableCollection<Manga> ListeMangaCourant { get; set; } = new ObservableCollection<Manga>(); 
        
        private Manga mangaCourant;
        public Manga MangaCourant //Manga sélectionné 
        {
            get => mangaCourant;
            set
            {
                if (mangaCourant != value)
                {
                    mangaCourant = value;
                    OnPropertyChanged(nameof(MangaCourant));
                }
            }
        }
        void OnPropertyChanged(string nomProp)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomProp));

        private Manga meilleurManga;
        public Manga MeilleurManga //Le meilleur manga est celui qui possède la meilleure MoyenneNote
        {
            get => meilleurManga;
            set
            {
                if (meilleurManga != value)
                {
                    meilleurManga = value;
                    OnPropertyChanged(nameof(MeilleurManga));
                }
            }
        }

        [OnDeserialized]
        void InitReadOnlyCollection(StreamingContext sc = new StreamingContext()) //Méthode qui est appelée après notre sérialisation pour initiliaser nos ReadOnlyCollection
        {
            CollectionManga = new ReadOnlyDictionary<Genre, SortedSet<Manga>>(collectionManga);
            List<Compte> lCompte = new List<Compte>();
            foreach(Compte c in listeCompte) //Permet d'éviter d'avoir un tableau dans notre IList
            {
                lCompte.Add(c);
            }
            listeCompte = lCompte;
            ListeCompte = new ReadOnlyCollection<Compte>(listeCompte);
            ChercherMeilleurManga();
        }


        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="lCompte">Listes des comptes</param>
        /// <param name="cManga">Dictionnaire des manga, clé : genres, valeur : liste de manga</param>
        /// <param name="lGenre">Liste des genres</param>
        public Listes(List<Compte> lCompte, Dictionary<Genre, SortedSet<Manga>> cManga,List<Genre> lGenre)
        {
            
            listeCompte = lCompte;
            ListeCompte = new ReadOnlyCollection<Compte>(listeCompte);
            collectionManga = cManga;
            CollectionManga = new ReadOnlyDictionary<Genre, SortedSet<Manga>>(collectionManga);
            ListeGenre = lGenre;
            ChercherMeilleurManga();
        }


        public event PropertyChangedEventHandler PropertyChanged; //Evènement permettant de géré la notification de changement de nos propriétés

        /// <summary>
        /// Permet de recuperer le genre à partir de son nom de l'enum
        /// </summary>
        /// <param name="nomGenre">nom du genre dans l'enum</param>
        /// <returns>g de la classe Genre</returns>
        public Genre RecupererGenre(GenreDispo nomGenre)
       {
            var genres = CollectionManga.Keys;
            var g = from genre in genres
                      where genre.NomGenre.Equals(nomGenre)
                      select genre;
            return g.FirstOrDefault();
        }

        /// <summary>
        /// Permet d'actualiser la liste de manga du même genre
        /// </summary>
        /// <param name="g">Genre de manga voulu</param>
        
        public void ListeParGenre(Genre g) 
        {
            ListeMangaCourant.Clear();
            var temp = from k in CollectionManga

                       where k.Key.NomGenre.Equals(g.NomGenre)
                       select k.Value;

            foreach (var t in temp)
            {
                foreach (Manga m in t)
                {
                    ListeMangaCourant.Add(m);
                }
            }
           
        }

        /// <summary>
        /// Permet d'ajouter un manga 
        /// </summary>
        /// <param name="to">Titre original(japonais)</param>
        /// <param name="ta">Titre alternatif</param>
        /// <param name="au">Auteur du manga</param>
        /// <param name="dess">Dessinateur du manga</param>
        /// <param name="maisJ">Maison d'edition japonaise</param>
        /// <param name="maisFr">Maison d'edition francaise</param>
        /// <param name="pTome">Date du premier tome</param>
        /// <param name="dTome">Date du dernier tome(facultatif)</param>
        /// <param name="nbTome">Nombre de tomes du manga</param>
        /// <param name="couv">Couverture du manga</param>
        /// <param name="synop">Synopsis</param>
        /// <param name="g">Genre du manga</param>

        public void AjouterManga(string to, string ta, string au, string dess, string maisJ, string maisFr, string pTome, string dTome, int nbTome, string couv, string synop, Genre g)
        {

            Manga m = new Manga(to, ta, au, dess, maisJ, maisFr, pTome, dTome, nbTome, couv, synop,g.NomGenre);
            foreach(KeyValuePair<Genre,SortedSet<Manga>> kvp in CollectionManga)
            {
                if (kvp.Key.Equals(g))
                {
                    if (!kvp.Value.Contains(m))
                    {
                        kvp.Value.Add(m);
                    }
                }
                ListeParGenre(g);
            }
        }

        /// <summary>
        /// Permet supprimer un manga dans le dictionnaire
        /// </summary>
        /// <param name="m">Manga a supprimer</param>
        /// <param name="g">Genre du manga pour le supprimer au niveau de la bonne clé</param>
        public void SupprimerManga(Manga m, Genre g) 
        {
            foreach (Compte c in ListeCompte)
            {
                c.SupprimerFavori(MangaCourant);
            }
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                if (kvp.Key.Equals(g))
                {
                    if (kvp.Value.Contains(m))
                    {
                        kvp.Value.Remove(m);
                    }
                }
                ListeParGenre(g);
                ChercherMeilleurManga(); //reactualise le meilleur manga s'il est supprimé
            }
            
        }
        /// <summary>
        /// Permet de modifier les informations d'un manga : les elements en parametres peuvent etre modifié
        /// </summary>
        /// <param name="g">Genre du manga pour le retrouver dans la bonne clé</param>
        /// <param name="to">titre original</param>
        /// <param name="dTome">date du dernier tome</param>
        /// <param name="nbTome">nombre de tome</param>
        /// <param name="couv">lien vers l'image de couverture</param>
        /// <param name="synop">texte permetant de lancer l'intrigue du manga</param>
        public void ModifierManga(Genre g, string to, string dTome, int nbTome, string couv, string synop)
        {
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                if (kvp.Key.Equals(g))
                {
                    foreach(Manga manga in kvp.Value)
                    {
                        if (manga.TitreOriginal.Equals(to))
                        {
                            manga.Modifier(dTome, nbTome, couv, synop);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Permet d'ajouter un avis à un manga
        /// </summary>
        /// <param name="util">Utilisateur </param>
        /// <param name="comm">Commentaire (facultatif)</param>
        /// <param name="note">Note entre 0 et 10</param>
        /// <param name="g">Genre du manga noté</param>
        /// <param name="m">Manga noté</param>
        public void AjouterAvis(Compte util, string comm, int note, Genre g, Manga m)
        {
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                if (kvp.Key.Equals(g))
                {
                    foreach (Manga man in kvp.Value)
                    {
                        if (man.Equals(m))
                        {
                            Avis a = new Avis(comm, note, util);
                            man.AjouterAvis(a);
                        }
                    }
                }
            }
            ChercherMeilleurManga(); //Actualise le manga du moment s'il devient/ne devient plus le meilleur
        }

        /// <summary>
        /// Cherche le meilleur manga = meilleure note de tous et l'actualise
        /// </summary>
        public void ChercherMeilleurManga()
        {
            Manga leMeilleur = new Manga("test", "test", "test", "test", "test", "test", "01/01/2000", "01/01/2001", 1, "/test/", "testtest",GenreDispo.Shonen);

            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                foreach (Manga man in kvp.Value)
                {
                    if (man.MoyenneNote > leMeilleur.MoyenneNote)
                    {
                        leMeilleur = man;
                    }
                }
            }
            MeilleurManga = leMeilleur;

        }
        /// <summary>
        /// Permet de modifier le profil, appel la fonction du même nom dans Compte
        /// </summary>
        /// <param name="oldPseudo">ancien pseudo</param>
        /// <param name="newPseudo">nouveau pseudo qu'on souhaite</param>
        /// <param name="genrePref">genres preferes qu'on souhaite </param>
        /// <param name="imageName">Photo de profil modifiée</param>
        public void ModifierProfil(string oldPseudo, string newPseudo, GenreDispo[] genrePref, string imageName)
        {
            foreach(Compte compte in ListeCompte)
            {
                if (compte.Pseudo.Equals(oldPseudo))
                {
                    try
                    {
                        compte.ModifierProfil(newPseudo, genrePref, imageName);
                    }
                    catch(Exception e)
                    {
                        throw new ArgumentException(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Cherche un utilisateur à travers toute la collection de compte
        /// </summary>
        /// <param name="pseudo">pseudo du Compte à retrouver</param>
        /// <param name="motDePasse">mot de passe du Compte à retrouver</param>
        /// <returns>Resultat de la recherche</returns>
        public bool ChercherUtilisateur(string pseudo, string motDePasse)
        {
            foreach(Compte c in ListeCompte)
            {
                if(c.Pseudo.Equals(pseudo) && c.MotDePasse.Equals(motDePasse))
                {
                    CompteCourant = c;
                    return true;
                }
            }
            return false; 
        }
        /// <summary>
        /// Permet de rajouter un Compte à l'application
        /// </summary>
        /// <param name="pse">Pseudo</param>
        /// <param name="dateN">Date de naissance, qui sera transformée en age</param>
        /// <param name="mdp">Mot de passe</param>
        /// <param name="g">Genres preferés de 0 à 2</param>
        /// <param name="photo_profil">Photo de profil</param>
        public void AjouterUtilisateur(string pse, string dateN, string mdp, GenreDispo[] g, string photo_profil)
        {
            try
            {
                Compte c = new Compte(pse, dateN, DateTime.Today, mdp, g, photo_profil);
                if (!listeCompte.Contains(c))
                {
                    listeCompte.Add(c);
                  
                }
            }
            catch(Exception e)
            {
                throw new ArgumentException(e.Message);
            }          
        }

        /// <summary>
        /// Appel la méthode Compte pour ajouter un Manga favori à la liste de favori d'un Compte
        /// </summary>
        /// <param name="m">Manga à ajouter aux favoris</param>
        /// <param name="c">Compte qui reçoit le favori</param>
        public void AjouterFavoriManga(Manga m, Compte c)
        {
            c.AjouterFavori(m);
        }

        /// <summary>
        /// Appel la méthode Compte pour supprimer un Manga favori de la liste de favori d'un Compte
        /// </summary>
        /// <param name="m">Manga à supprimer des favoris</param>
        /// <param name="c">Compte qui veut supprimer le favori</param>
        public void SupprimerFavoriManga(Manga m, Compte c)
        {
            c.SupprimerFavori(m);
        }
        public void RecupererFavoris()
        {
            ListeMangaCourant.Clear(); 
            foreach(Manga m in CompteCourant.LesFavoris)
            {
                ListeMangaCourant.Add(m);
            }
        }

        /// <summary>
        /// Permet de choisir un genre au hasard 
        /// </summary>
        public void GenreAuHasard()
        {
            Array genreDispo = Enum.GetValues(typeof(GenreDispo));
            Random random = new Random(); 
            int index = random.Next(0, 4);
            GenreDispo gd = (GenreDispo)genreDispo.GetValue(index);
            GenreCourant = RecupererGenre(gd);
            ListeParGenre(GenreCourant); 
        }

        /// <summary>
        /// Renvoie un manga en le recherchant par nom
        /// </summary>
        /// <param name="nomManga">Nom du manga saisi, pas sensible à la casse</param>
        /// <returns></returns>
        public Manga RechercherMangaParNom(string nomManga)
        {
            Manga m = null;
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                var Manga = kvp.Value.Where(manga => manga.TitreOriginal.ToLower().Equals(nomManga.ToLower())); //Permet de retrouver le pseudo sans prendre en compte les majuscules
                if (Manga.Count<Manga>() != 0)
                {
                    m = Manga.FirstOrDefault();
                    return m;
                }
            }
            return m;
        }
        /// <summary>
        /// Permet de transformer une instance en chaîne de caractères
        /// </summary>
        public override string ToString()
        {
            string r= "Liste des comptes : \n\n ";
           
            foreach(Compte c in ListeCompte)
            {
                r += $"{c} \n";
            }
            r += " Collection de mangas : \n\n ";
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                r += $"{kvp.Key} : \n ";
                foreach (Manga m in kvp.Value)
                {
                    r += $"{m} \n";
                }
            }
            return r;
        }       

    }
}
