using System;
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

            Genre genre1 = new Genre("Description Shonen", g);
            Genre genre2 = new Genre("Description Seinen", g2);
            Genre genre3 = new Genre("Description Shojo", g3);
            Genre genre4 = new Genre("Description Josei", g4);

            Manga m1 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", "maisone2", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois");
            //Manga m12 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois");
            Manga m2 = new Manga("HxH", "ezhz", "jesaispas", "nonplus", "genre", "maisone2", new DateTime(2009), new DateTime(2011), 999, "dossier/test/", "epreuve 1 ");
            Manga m3 = new Manga("Death Note", "Note Death", "toujourpas", "encoremoins", "horreur", "maisone2", new DateTime(2002), new DateTime(2005), 36, "dossier/test/", "shinigami ");

            Utilisateur u1 = new Utilisateur("xProGamer", 14, new DateTime(2021, 12, 12),g, "azerty123");
            Avis a = new Avis("Belle couverture", 7, new DateTime(2021), u1);
            m1.AjouterAvis(a);
            a = new Avis("Histoire intéressante avec un suspense insoutenable", 5, new DateTime(2021), u1);            
            m1.AjouterAvis(a);

            Utilisateur admin1 = new Administrateur("xProAdmin", 27, new DateTime(2021, 12, 24), g3, "motdepasse");
            a = new Avis("Que des retournements de situations", 10, new DateTime(2021), admin1);
            m1.AjouterAvis(a);


            //genre1.AjouterManga(m1);
            //genre1.AjouterManga(m2);

            u1.AjouterFavori(m1);
            u1.AjouterFavori(m2);
            u1.AjouterFavori(m3);


            //admin1.AjouterManga(m3,genre1.lesMangas);

            /*Console.WriteLine(a);
            Console.WriteLine("\n\n");
            */
            /*Console.WriteLine(g);
            Console.WriteLine(g2);
            Console.WriteLine(g3);
            Console.WriteLine(g4);
            Console.WriteLine("\n\n");

            Console.WriteLine(genre1);
            Console.WriteLine(genre2);
            Console.WriteLine(genre3);
            Console.WriteLine(genre4);
            Console.WriteLine("\n\n");
            */

            Console.WriteLine("------------------------");
            Console.WriteLine("Affichage des utilisateurs");

            Console.WriteLine(u1);
            Console.WriteLine("\n\n");

            Console.WriteLine(admin1);
            Console.WriteLine("\n\n");

            Console.WriteLine("----------------------");
            Console.WriteLine("Affichage des mangas");

            Console.WriteLine(m1);
            Console.WriteLine(m2);
            Console.WriteLine(m3);

            m1.CalculerMoyenne();
            Console.WriteLine(m1.MoyenneNote);

            /*Console.WriteLine("------------------------");
            Console.WriteLine("Test des equals");
            
            if (m12.Equals(m1))
            {
                Console.WriteLine("Le manga m12 et m1 sont similaires");
            }
            if (!m12.Equals(m2))
            {
                Console.WriteLine("Le manga m12 et m2 sont différents");
            }*/
        }
    }
}
