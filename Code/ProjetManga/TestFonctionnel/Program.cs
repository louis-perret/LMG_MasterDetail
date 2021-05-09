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

            // l1.ListeCompte[0]; //pour recuperer un compte precis pour les test
            

            
            Console.WriteLine("<-- Affichage de l1, une instance de Listes -->\n");
            Console.WriteLine($"{l1}\n");

            Console.WriteLine("\n\n\tTest de la fonctionnalité Ajouter un Manga \n\n");

            Console.WriteLine("\n\n\tTest de la fonctionnalité Modifier un Manga \n\n");
            Manga m = Gestionnaire.RechercherMangaParNom(l1, "hxh"); //Recherche le manga à modifier
            Console.WriteLine("Voici le manga avant sa modification : \n {0}", m);
            Gestionnaire.ModifierManga(l1,l1.RecupererGenre(m.Genre), m.TitreOriginal, new DateTime(2012, 10, 26), 55, "nouvelleCouverture", "20 ans plus tard, l'équipage au chapeau de paille se retrouve démunis face aux 4 grandes empereurs des mers");
            Console.WriteLine("Voici le manga, après sa modification : \n {0}", m);

            //Console.WriteLine("Teste de la méthode AjouterAvis\n\n");
            // Gestionnaire.AjouterAvis(l1, c, "Ce manga est incroyable je recommande vivement !", 8, new Genre("Genre d'action", GenreDispo.Shonen), /* mettre un manga peut importe*/); 
            //Console.WriteLine("<-- Affichage de Liste -->");
            //Console.WriteLine(l1);

            Console.WriteLine("Test de la méthode ChercherMeilleurManga\n\n"); // fonctionnel avec STUB
            m = Gestionnaire.MangaDuMoment(l1);
            Console.Write(m);

            Console.WriteLine("Test de la fonctonnalité ModifierProfil"); //fonctionnel avec STUB
            Console.WriteLine($"Avant modifications :{l1.ListeCompte[0]}");
            Gestionnaire.ModifierProfil(l1, l1.ListeCompte[0].Pseudo, "NouveauPseudo", new GenreDispo[] { GenreDispo.Seinen });
            Console.WriteLine($"Apres modifications :{l1.ListeCompte[0]}");

           /* Console.WriteLine("Test de la fonctonnalité ChercherUtilisateur\n"); // ne fonctionne pas
            Compte cu = Gestionnaire.ChercherUtilisateur(l1, "xProGamer", "azerty123");
            Console.WriteLine(cu);
            if (l1.ListeCompte[0] != null)
            {
                Console.WriteLine("L'utilisateur recherché était :\n ");
                Console.WriteLine(cu);
            }
            else
            {
                Console.WriteLine("Ce compte n'existe pas");
            } */
            
            Console.WriteLine("\n\n\nTest de la fonctonnalité AjouterUtilisateur\n"); //fonctionnel
            Console.WriteLine($"Nb utilisateur avant l'ajout :{l1.ListeCompte.Count()}");
            Gestionnaire.AjouterUtilisateur(l1,"TerreTerre", "05/05/1999", "frigiel", new GenreDispo[] { GenreDispo.Seinen, GenreDispo.Josei });
            Console.WriteLine($"Nb utilisateur apres l'ajout :{l1.ListeCompte.Count()}");


            /*Console.WriteLine("Test de la fonctonnalité AjouterFavorisManga/SupprimerFavoriManga \n"); // fonctionnel apres avoir mis les manga gracex aux STUB (pas fait)
            Gestionnaire. AjouterFavoriManga(l1,m1, l1.ListeCompte[0]);
            Console.WriteLine(l1.ListeCompte[0]);
            Gestionnaire.SupprimerFavoriManga(l1,m1, l1.ListeCompte[0]);
            Console.WriteLine(l1.ListeCompte[0]);
            */




            Console.WriteLine("------------------------");
            Console.WriteLine("Tests de Gestionnaire : listeParGenre\n\n"); //Fonctionnel


            SortedSet<Manga> listeDeManga = Gestionnaire.ListeParGenre(l1, l1.RecupererGenre(GenreDispo.Shonen));
            foreach (var s in listeDeManga)
             {
                 Console.WriteLine(s);
             }
             
            /*Console.WriteLine("------------------------"); //fonctionnel (si y'a des bug c'est qu'on tombe sur une liste vide
            Console.WriteLine("Tests de Gestionnaire : genre au hasard\n\n");
            Dictionary<Genre,SortedSet<Manga>> listeDeManga = Gestionnaire.GenreAuHasard(l1);
            foreach (var s in listeDeManga)
            {
                Console.WriteLine(s.Key);
               foreach(Manga man in s.Value)
               {
                   Console.WriteLine(man);
               }
            }*/
                   
        }
    }
}
