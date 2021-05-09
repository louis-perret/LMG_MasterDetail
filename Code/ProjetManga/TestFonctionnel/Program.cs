using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Modele;

namespace TestFonctionnel
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Stub stub = new Stub("");
            Listes l1 = stub.Load("");

           
            Console.WriteLine("<-- Affichage de l1, une instance de Listes -->\n");
            Console.WriteLine($"{l1}\n");

            Console.WriteLine("\n\n\tTest de la fonctionnalité Ajouter un Manga \n\n");
            Gestionnaire.AjouterManga(l1, "Shingeki no Kyogin", "Attaque des titans", "Hajime Isayama", "Hajime Isayama", "Kodasha", "Pika Edition", new DateTime(2009, 09, 09), new DateTime(2021, 04, 09), 34, 
                "couvertureSNK.png", "Eren est un petit garçon rêvant de voyager dans le monde extérieur. Mais cela est impossible car il vit dans une ville fortifiée aux murailles dépassant les cinquante mètres de haut. Ces remparts sont nécessaires à la sécurité des habitants car ils sont les derniers représentants de l'humanité, obligés de se cacher pour échapper aux titans qui ont massacré la majeure partie du genre humain un siècle plus tôt.", GenreDispo.Shonen);
            Manga m = Gestionnaire.RechercherMangaParNom(l1, "shingeki no kyogin");
            Console.WriteLine($"Le manga qui a été ajouté est : \n{m}"); //On voit bien que ça affiche le manga ajouté précédemment

            Console.WriteLine("\n\n\tTest de la fonctionnalité Modifier un Manga \n\n");
            m = Gestionnaire.RechercherMangaParNom(l1, "one piece"); //Recherche le manga à modifier
            Console.WriteLine("Voici le manga avant sa modification : \n{0}", m);
            Gestionnaire.ModifierManga(l1,m.Genre, m.TitreOriginal, new DateTime(2012, 10, 26), 55, "nouvelleCouverture.png", "20 ans plus tard, l'équipage au chapeau de paille se retrouve démunis face aux 4 grandes empereurs des mers");
            Console.WriteLine("Voici le manga, après sa modification : \n{0}", m);

            Console.WriteLine("\n\n\tTest de la fonctionnalité Suppprimer un Manga \n");
            m = Gestionnaire.RechercherMangaParNom(l1, "shingeki no kyogin"); //Recherche le manga à supprimer 
            Gestionnaire.SupprimerManga(l1, m, m.Genre);
            m = Gestionnaire.RechercherMangaParNom(l1, "shingeki no kyogin"); //On recherche de nouveau le manga qu'on voulait supprimer
            if(m == null) //m est null donc le manga a bien été supprimé
            {
                Console.Write("Le manga a bien été supprimé");
            }

            Console.WriteLine("\n\n\n\tTeste de la fonctionnalité Ajouter un avis\n\n");
            m = Gestionnaire.RechercherMangaParNom(l1,"death note");
            Console.WriteLine($"On affiche le manga avant son nouvel avis : \n{m}"); //Sa moyenne avant l'avis est de 10
            Gestionnaire.AjouterAvis(l1, l1.ListeCompte[0], "Ce manga est incroyable je recommande vivement !", 8, m.Genre, m);
            Console.WriteLine($"Affichage du manga avec son nouvel avis posté par l'utilisateur {l1.ListeCompte[0].Pseudo}: \n{m}");
            //On remarque bien que la moyenne de ses notes a bien été recalculée puisqu'elle est à 9 maintenant

            Console.WriteLine("\n\n\tTest de la fonctionnalité Chercher le meilleur manga\n\n"); 
            m = Gestionnaire.MangaDuMoment(l1);
            Console.Write(m); //La console affiche bien le manga avec le meilleur avis (dans nos testes c'est le manga Death Note)

            Console.WriteLine("\n\n\tTest de la fonctonnalité ModifierProfil\n\n");
            Console.WriteLine($"Avant modifications :{l1.ListeCompte[0]}");
            Gestionnaire.ModifierProfil(l1, l1.ListeCompte[0].Pseudo, "NouveauPseudo", new GenreDispo[] { GenreDispo.Seinen });
            Console.WriteLine($"Après modifications :{l1.ListeCompte[0]}"); 
            //On voit bien que son pseudo ainsi que ses genres préférés ont été modifiés

            Console.WriteLine("\n\n\tTest de la fonctonnalité ChercherUtilisateur\n");
            Compte cu = Gestionnaire.ChercherUtilisateur(l1, "Camille", "frigiel"); //On recherche un compte qui existe 
            if (cu != null)
            {
                Console.WriteLine("L'utilisateur recherché était :\n ");
                Console.WriteLine(cu); //Et il s'affiche 
            }
            else
            {
                Console.WriteLine("Ce compte n'existe pas");
            }
            
            Console.WriteLine("\n\n\tTest de la fonctonnalité AjouterUtilisateur\n");
            Console.WriteLine($"Nb utilisateur avant l'ajout :{l1.ListeCompte.Count()}");
            Gestionnaire.AjouterUtilisateur(l1,"TerreTerre", "05/05/1999", "frigiel", new GenreDispo[] { GenreDispo.Seinen, GenreDispo.Josei });
            Console.WriteLine($"Nb utilisateur apres l'ajout :{l1.ListeCompte.Count()}");


            Console.WriteLine("\n\n\tTest de la fonctonnalité AjouterFavorisManga/SupprimerFavoriManga\n\n"); 
            Gestionnaire.AjouterFavoriManga(l1, Gestionnaire.RechercherMangaParNom(l1,"one piece"), cu); //Pour ce test, on reprend le compte chercher précédemment et qui possède aucun favoris
            Console.WriteLine($"Voici l'utilisateur après l'ajout d'un manga à ses favoris : \n {cu}"); 
            //On remarque que sa liste de favoris possède maintenant un manga
            
            Gestionnaire.SupprimerFavoriManga(l1, Gestionnaire.RechercherMangaParNom(l1, "one piece"), cu);
            Console.WriteLine($"\nVoici l'utilisateur après la suppression du manga ajouter précédemment à ses favoris : \n {cu}");
            //On remarque que sa liste de favoris est maintenant vide

            Console.WriteLine("\n\n\tTeste de la fonctionnalité Liste par genre\n\n"); 
            SortedSet<Manga> listeDeManga = Gestionnaire.ListeParGenre(l1, l1.RecupererGenre(GenreDispo.Shonen)); //On souhaite afficher la collection de mangas de genre Shonen
            Console.WriteLine("Affichage des mangas de type Shonen :\n");
            foreach (var s in listeDeManga)
             {
                 Console.WriteLine(s);
             }
                         
            Console.WriteLine("\n\n\t Teste de la fonctionnalité Genre au hasard\n\n");
            Genre g;
            listeDeManga = Gestionnaire.GenreAuHasard(l1, out g);
            Console.WriteLine($"Le genre pioché au hasard est : \n{g} \nVoici la liste des mangas de ce genre : \n\n");
            foreach (var s in listeDeManga)
            {
                Console.WriteLine(s);             
            }
                   
        }
    }
}
