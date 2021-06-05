using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Modele   
{
    [DataContract]
    public class Listes : INotifyPropertyChanged
{
        /// <summary>
        /// Classe qui va etre serializée et qui va effectuer les méthodes sur nos classes
        /// </summary>

        [DataMember]
        private IList<Compte> listeCompte { get; set; }

        public ReadOnlyCollection<Compte> ListeCompte { get; private set; }

        [DataMember]
        private IDictionary<Genre, SortedSet<Manga>> collectionManga { get; set; }

        
       
        public ReadOnlyDictionary<Genre,SortedSet<Manga>> CollectionManga { get; private set; }
        
        [OnDeserialized]
        void InitReadOnlyDictionary(StreamingContext sc = new StreamingContext()) //Méthode qui est appelée après notre sérialisation pour initiliaser nos ReadOnlyCollection
        {
            CollectionManga = new ReadOnlyDictionary<Genre, SortedSet<Manga>>(collectionManga);
            ListeCompte = new ReadOnlyCollection<Compte>(listeCompte);
        }

        [DataMember]
        public IList<Genre> ListeGenre { get; private set; }

        private Compte compte;
        public Compte CompteCourant 
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
        public Genre GenreCourant
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


        //private SortedSet<Manga> listeMangaCourant = new SortedSet<Manga>();
        [DataMember]
        public ObservableCollection<Manga> ListeMangaCourant { get; set; } = new ObservableCollection<Manga>();
        
        private Manga mangaCourant;
        public Manga MangaCourant
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
        public Manga MeilleurManga
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

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="lCompte">Listes des comptes</param>
        /// <param name="cManga">Dictionnaire des manga, clé : genres, valeur : liste de manga</param>
        public Listes(List<Compte> lCompte, Dictionary<Genre, SortedSet<Manga>> cManga,List<Genre> lGenre)
        {
            /*InitReadOnlyDictionary();
            InitReadOnlyCollection();*/
            listeCompte = lCompte;
            ListeCompte = new ReadOnlyCollection<Compte>(listeCompte);
            collectionManga = cManga;
            CollectionManga = new ReadOnlyDictionary<Genre, SortedSet<Manga>>(collectionManga);
            ListeGenre = lGenre;
            
        }

        public Listes()
        {
            //InitReadOnlyCollection();
            InitReadOnlyDictionary();
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
        /// Permet de renvoyer une liste de manga du même genre
        /// </summary>
        /// <param name="g">Genre de manga voulu</param>
        /// <returns>Liste de manga du genre passé en parametre</returns>
        public void ListeParGenre(Genre g) 
        {
            //SortedSet<Manga> listeDuGenre = new SortedSet<Manga>();
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
            //return listeDuGenre;


        }



        /// <summary>
        /// Permet d'ajouter un manga dans le dictionnaire
        /// </summary>
        /// <param name="m">Manga a ajouter</param>
        /// <param name="g">Genre du manga pour le placer dans la bonne clé</param>
        
        public void AjouterManga(string to, string ta, string au, string dess, string maisJ, string maisFr, DateTime pTome, DateTime? dTome, int nbTome, string couv, string synop, Genre g)
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
/*
        public static void AjouterManga(Listes l, string to, string ta, string au, string dess, string maisJ, string maisFr, DateTime pTome, DateTime? dTome, int nbTome, string couv, string synop, GenreDispo g)
        {
            Manga m = new Manga(to, ta, au, dess, maisJ, maisFr, pTome, dTome, nbTome, couv, synop, g);
            l.AjouterManga(m, l.RecupererGenre(g));
        }

        */


        /// <summary>
        /// Permet supprimer un manga dans le dictionnaire
        /// </summary>
        /// <param name="m">Manga a supprimer</param>
        /// <param name="g">Genre du manga pour le supprimer au niveau de la bonne clé</param>
        public void SupprimerManga(Manga m, Genre g) /// a modifier a terme
        {
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
            }
        }

        /// <summary>
        /// permet de modifier les informations d'un manga : les elements en parametres peuvent etre modifié
        /// </summary>
        /// <param name="g">Genre du manga pour le retrouver dans la bonne clé</param>
        /// <param name="to">titre original</param>
        /// <param name="dTome">date du dernier tome</param>
        /// <param name="nbTome">nombre de tome</param>
        /// <param name="couv">lien vers l'image de couverture</param>
        /// <param name="synop">texte permetant de lancer l'intrigue du manga</param>
        public void ModifierManga(Genre g, string to, DateTime? dTome, int nbTome, string couv, string synop)
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
        /// Permet d'ajouter un avis a un manga
        /// </summary>
        /// <param name="a">Avis </param>
        /// <param name="g">Genre du manga pour le retrouver dans le dictionnaire</param>
        /// <param name="m">Manga qui va recevoir l'avis</param>
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
        }


        /// <summary>
        /// Cherche le meilleur manga = meilleure note de tous
        /// </summary>
        /// <returns>Manga le plus apprecié</returns>
        public Manga ChercherMeilleurManga()
        {
            Manga leMeilleur = new Manga("test", "test", "test", "test", "test", "test", new DateTime(2000), new DateTime(2001), 1, "/test/", "testtest",GenreDispo.Shonen);

            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                //var m = kvp.Value.Max(man => man.MoyenneNote);
                foreach (Manga man in kvp.Value)
                {
                    if (man.MoyenneNote > leMeilleur.MoyenneNote)
                    {
                        leMeilleur = man;
                    }
                }
            }
            return leMeilleur;

        }

        /// <summary>
        /// Permet de modifier le profil, appel la fonction du même nom dans Compte
        /// </summary>
        /// <param name="oldPseudo">ancien pseudo</param>
        /// <param name="newPseudo">nouveau pseudo qu'on souhaite</param>
        /// <param name="genrePref">genres preferes qu'on souhaite </param>
        public void ModifierProfil(string oldPseudo, string newPseudo, GenreDispo[] genrePref)
        {
            foreach(Compte compte in ListeCompte)
            {
                if (compte.Pseudo.Equals(oldPseudo))
                {
                    compte.ModifierProfil(newPseudo, genrePref);
                }
            }
        }

        /// <summary>
        /// Cherche un utilisateur à travers toute la collection de compte
        /// </summary>
        /// <param name="pseudo">pseudo du Compte à retrouver</param>
        /// <param name="motDePasse">mot de passe du Compte à retrouver</param>
        /// <returns>Le compte cherché</returns>
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
        /// Permet d'ajouter un utilisateur
        /// </summary>
        /// <param name="c">Compte à ajouter</param>
        public void AjouterUtilisateur(string pse, string dateN, string mdp, GenreDispo[] g, string photo_profil)
        {
            Compte c = new Compte(pse, dateN, DateTime.Today, mdp, g, photo_profil);
            if(!listeCompte.Contains(c))
            {
                listeCompte.Add(c);
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

        public void GenreAuHasard(Listes l, out Genre g)
        {
            Dictionary<Genre, SortedSet<Manga>> genreHasard = new Dictionary<Genre, SortedSet<Manga>>();

            Array genreDispo = Enum.GetValues(typeof(GenreDispo));
            Random random = new Random();
            int index = random.Next(1, 4);
            GenreDispo gd = (GenreDispo)genreDispo.GetValue(index);
            g = l.RecupererGenre(gd);
            l.ListeParGenre(g);
        }

        public Manga MangaDuMoment(Listes l)
        {
            Manga m = l.ChercherMeilleurManga();
            return m;
        }

        public Manga RechercherMangaParNom(string nomManga)
        {
            Manga m = null;
            foreach (KeyValuePair<Genre, SortedSet<Manga>> kvp in CollectionManga)
            {
                var Manga = kvp.Value.Where(manga => manga.TitreOriginal.ToLower().Equals(nomManga.ToLower()));
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
