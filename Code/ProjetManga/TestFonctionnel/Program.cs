using System;
using System.Collections.Generic;
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

            Console.WriteLine("<-- Affichage de Liste -->\n");
            Console.WriteLine(l1);

            Console.WriteLine("Teste de la méthode ModiferManga \n\n");

            Manga mModif = new Manga("Death Note", "Note Death", "auteurBidon", "dessinateurBidon", "horreur", "maisone2", new DateTime(2002), new DateTime(2005), 36, "dossier/test/", "shinigami qui aime les pommes ");
            l1.ModifierManga(mModif, new Genre("Genre d'action", GenreDispo.Shonen));

            Console.WriteLine("<-- Affichage de Liste -->\n");
            Console.WriteLine(l1);

            Console.WriteLine("Teste de la méthode AjouterAvis\n\n");

            Gestionnaire.AjouterAvis(l1, l1.ListeCompte., "Ce manga est incroyable je recommande vivement !", 8, new Genre("Genre d'action", GenreDispo.Shonen), l1.CollectionManga.Values.g); 
            ///pour nos test il faut absolument proceder comme le truc juste au dessus mais j'arrive pas a acceder à l'element precis de nos sortedSet
           
            Console.WriteLine("<-- Affichage de Liste -->");
            Console.WriteLine(l1);

            Console.WriteLine("Teste de la méthode ChercherMeilleurManga\n\n");
            Manga m = Gestionnaire.MangaDuMoment(l1);
            Console.Write(m);

            Console.WriteLine("Teste de la fonctonnalité ModifierProfil");
            Gestionnaire.ModifierProfil(l1,"xProGamer","Toto", new GenreDispo[] { g, g2 });
            Console.Write(l1);

            Console.WriteLine("Test de la fonctonnalité RechercherUtilisateur\n");
            
            Compte c = Gestionnaire.ChercherUtilisateur(l1,"xProGamer", "azerty123");
            Compte c = Gestionnaire.ChercherUtilisateur(l1,"Toto", "azerty123");
            if (c != null)
            {
                Console.WriteLine("L'utilsateur recherché était :\n ");
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine("Ce compte n'existe pas");
            }
            */
            /*Console.WriteLine("\n\n\nTest de la fonctonnalité AjouterUtilisateur\n");
            Compte u4 = new Compte("TerreTerre", "05/05/1999", new DateTime(2021, 11, 11), "frigiel", new GenreDispo[] { g, g2 });
            Gestionnaire.AjouterUtilisateur(l1,"TerreTerre", "05/05/1999", "frigiel", new GenreDispo[] { g, g2 });
            //Console.WriteLine(l1);

            Console.WriteLine("Test de la fonctonnalité AjouterFavorisManga/SupprimerFavoriManga \n");
            Gestionnaire. AjouterFavoriManga(l1,m1, u1);
            Console.WriteLine(u1);
            Gestionnaire.SupprimerFavoriManga(l1,m1, u1);
            Console.WriteLine(u1);*/


            

            
            Console.WriteLine("------------------------");
            Console.WriteLine("Tests de Gestionnaire : listeParGenre\n\n");

            SortedSet<Manga> listeDeManga = new SortedSet<Manga>();

            listeDeManga = Gestionnaire.ListeParGenre(l1, genre4);
            foreach (var s in listeDeManga)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("Tests de Gestionnaire : genre au hasard\n\n");
            listeDeManga = Gestionnaire.GenreAuHasard(l1);
            foreach (var s in listeDeManga)
            {
                Console.WriteLine(s);
            }

        }
}
}
