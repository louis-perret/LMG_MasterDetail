using System;
using Modele;

namespace TestFonctionnel
{
    class Program
    {
        static void Main(string[] args)
        {
            Avis a = new Avis("Belle couverture", 9, new DateTime(2021));

            GenreDispo g = GenreDispo.Josei;
            GenreDispo g2 = GenreDispo.Shojo;
            GenreDispo g3 = GenreDispo.Shonen;
            GenreDispo g4 = GenreDispo.Seinen;

            Manga m1 = new Manga("test", "altertest", "eichiro", "dessinateur", "maisone", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois");
            m1.AjouterAvis(a);

            Utilisateur u1 = new Utilisateur("xProGamer", 14, new DateTime(2021, 12, 12), "azerty123");

            Console.WriteLine(a);
            Console.WriteLine(g);
            Console.WriteLine(g2);
            Console.WriteLine(g3);
            Console.WriteLine(g4);
            Console.WriteLine(m1);
            Console.WriteLine(u1);
        }
    }
}
