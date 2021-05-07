using System;
using System.Collections.Generic;
using Modele;

namespace TestFonctionnel
{
    class Program
    {
        static void Main(string[] args)
        {
            GenreDispo g = GenreDispo.Josei;
            GenreDispo g2 = GenreDispo.Shojo;
            GenreDispo g3 = GenreDispo.Shonen;
            GenreDispo g4 = GenreDispo.Seinen;
            

            Genre genre1 = new Genre("Description Shonen", g3);
            Genre genre2 = new Genre("Description Seinen", g4);
            Genre genre12 = new Genre("Description Shonen", g3);
            Genre genre3 = new Genre("Description Shojo", g2);
            Genre genre4 = new Genre("Description Josei", g);

            Manga m1 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", "maisone2", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois");
            Manga m12 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", "maisonfr", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois");
            Manga m2 = new Manga("HxH", "ezhz", "jesaispas", "nonplus", "genre", "maisone2", new DateTime(2009), new DateTime(2011), 999, "dossier/test/", "epreuve 1 ");
            Manga m3 = new Manga("Death Note", "Note Death", "toujourpas", "encoremoins", "horreur", "maisone2", new DateTime(2002), new DateTime(2005), 36, "dossier/test/", "shinigami ");

            Compte u1 = new Compte("xProGamer", "05/05/2015", new DateTime(2021, 12, 12), "azerty123", new GenreDispo[] { g, g2 });
            Compte u2 = new Compte("xgmm", "05/05/2012", new DateTime(2021, 11, 12),"test", new GenreDispo[] { g, g2 });
            Compte u3 = new Compte("sihano", "05/05/1999", new DateTime(2021, 11, 11),"frigiel", new GenreDispo[] { g, g2 });
            Avis a = new Avis("Belle couverture", 9, new DateTime(2021), u1);
            m1.AjouterAvis(a);
            a = new Avis("Histoire intéressante avec un suspense insoutenable", 1, new DateTime(2021), u1);            
            m1.AjouterAvis(a);

            a = new Avis("Histoire intéressante avec un suspense insoutenable", 10, new DateTime(2021), u1);
            m3.AjouterAvis(a);

            HashSet<Compte> ListeDesComptes = new HashSet<Compte>();
            ListeDesComptes.Add(u1);
            ListeDesComptes.Add(u2);
            ListeDesComptes.Add(u3);

            Dictionary<Genre, SortedSet<Manga>> CollectionDesMangas = new Dictionary<Genre, SortedSet<Manga>>();
            SortedSet<Manga> lesJosei = new SortedSet<Manga>();
            SortedSet<Manga> lesShonen = new SortedSet<Manga>();
            lesShonen.Add(m1);
            lesShonen.Add(m3);
            lesJosei.Add(m2);


            CollectionDesMangas.Add(genre4, lesJosei);
            CollectionDesMangas.Add(genre1, lesShonen);
            Listes l1 = new Listes(ListeDesComptes, CollectionDesMangas);



       

            u1.AjouterFavori(m1);
            u1.AjouterFavori(m2);
            u1.AjouterFavori(m3);



            Console.WriteLine("------------------------");
            Console.WriteLine("Affichage des utilisateurs");

            Console.WriteLine(u1);
            Console.WriteLine("\n\n");

            

            Console.WriteLine("----------------------");
            Console.WriteLine("Affichage des mangas");

            Console.WriteLine(m1);
            Console.WriteLine(m2);
            Console.WriteLine(m3);

            
           

            Console.WriteLine("------------------------");
            Console.WriteLine("Testes de Listes \n\n");

            Console.WriteLine("<-- Affichage de Liste -->\n");
            Console.WriteLine(l1);

            //Console.WriteLine("<-- Teste sur ajouter/suppression/modification de manga -->\n\n");
            /*l1.AjouterManga(m1, genre4); //Ajoute m1
            Console.WriteLine("<-- Affichage de Liste -->\n");
            Console.WriteLine(l1);
            
            l1.AjouterManga(m2, genre4); //N'ajoute pas m2
            Console.WriteLine("<-- Affichage de Liste -->\n");
            Console.WriteLine(l1);*/

            /*l1.SupprimerManga(m1, genre4); //Supprime m1
            Console.WriteLine("<-- Affichage de Liste -->\n");
            Console.WriteLine(l1);

            l1.SupprimerManga(m3, genre4); //Supprime rien
            Console.WriteLine("<-- Affichage de Liste -->\n");
            Console.WriteLine(l1);*/

            /*Manga mModif = new Manga("Death Note", "Note Death", "auteurBidon", "dessinateurBidon", "horreur", "maisone2", new DateTime(2002), new DateTime(2005), 36, "dossier/test/", "shinigami qui aime les pommes ");
            l1.ModifierManga(mModif, genre1);
            Console.WriteLine("<-- Affichage de Liste -->\n");
            Console.WriteLine(l1);*/

            /*Console.WriteLine("Teste de la méthode AjouterAvis\n\n");
            l1.AjouterAvis(a, genre1, m1);
            Console.WriteLine("<-- Affichage de Liste -->");
            Console.WriteLine(l1);*/

            /*Console.WriteLine("Teste de la méthode ChercherMeilleurManga\n\n");
            Manga m = l1.ChercherMeilleurManga();
            Console.Write(m);*/

            /*Console.WriteLine("Teste de la fonctonnalité ModifierProfil");
            l1.ModifierProfil("xProGamer","Toto", new GenreDispo[] { g, g2 });
            Console.Write(l1);*/

            Console.WriteLine("Teste de la fonctonnalité RechercherUtilisateur");
            
            Compte c = l1.ChercherUtilisateur("xProGamer", "azerty123");
            //Compte c = l1.ChercherUtilisateur("test", "test");
            if (c != null)
            {
                Console.WriteLine("L'utilsateur recherché était : ");
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine("Ce compte n'existe pas");
            }

            Console.WriteLine("Teste de la fonctonnalité AjouterUtilisateur");
            Compte u4 = new Compte("TerreTerre", "05/05/1999", new DateTime(2021, 11, 11), "frigiel", new GenreDispo[] { g, g2 });
            l1.AjouterUtilisateur(u4);
            Console.WriteLine(l1);

            Console.WriteLine("Teste de la fonctonnalité AjouterFavorisManga/SupprimerFavoriManga");
            l1.AjouterFavorisManga(m1, u1);
            Console.WriteLine(u1);
            l1.SupprimerFavorisManga(m1, u1);
            Console.WriteLine(u1);
        }
    }
}
