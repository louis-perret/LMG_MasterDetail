using System;
using Modele;

namespace TestFonctionnel
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilisateur u1 = new Utilisateur("xProGamer", 14, new DateTime(2021, 12, 12),new Genre("shonen"), "azerty123");
            Avis a = new Avis("Belle couverture", 9, new DateTime(2021), u1);
           

            GenreDispo g = GenreDispo.Josei;
            GenreDispo g2 = GenreDispo.Shojo;
            GenreDispo g3 = GenreDispo.Shonen;
            GenreDispo g4 = GenreDispo.Seinen;

            

            Manga m1 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois");
            Manga m2 = new Manga("HxH", "ezhz", "jesaispas", "nonplus", "genre", new DateTime(2009), new DateTime(2011), 999, "dossier/test/", "epreuve 1 ");
            Manga m3 = new Manga("Death Note", "Note Death", "toujourpas", "encoremoins", "horreur", new DateTime(2002), new DateTime(2005), 36, "dossier/test/", "shinigami ");
            m1.AjouterAvis(a);

            Genre genre1 = new Genre("Ceci est un genre tres cool");
            genre1.AjouterManga(m1);
            genre1.AjouterManga(m2);

            u1.AjouterFavori(m1);

            Administrateur admin1 = new Administrateur("xProAdmin", 27, new DateTime(2021, 12, 24), new Genre("test genre"), "motdepasse");
            admin1.AjouterManga(m3,genre1.lesMangas);

            Console.WriteLine(a);
            Console.WriteLine("\n\n");

            Console.WriteLine(g);
            Console.WriteLine(g2);
            Console.WriteLine(g3);
            Console.WriteLine(g4);
            Console.WriteLine("\n\n");

            Console.WriteLine(genre1);
            Console.WriteLine("\n\n");

            Console.WriteLine(u1);
            Console.WriteLine("\n\n");

            Console.WriteLine(admin1);
            Console.WriteLine("\n\n");
        }
    }
}
