using System;
using Modele;

namespace TestFonctionnel
{
    class Program
    {
        static void Main(string[] args)
        {
            Avis a = new Avis("Belle couverture");
            Genre g = Genre.Josei;
            Genre g2 = Genre.Shojo;
            Genre g3 = Genre.Shonen;
            Genre g4 = Genre.Seinen;

            Console.WriteLine(a);
            Console.WriteLine(g);
            Console.WriteLine(g2);
            Console.WriteLine(g3);
            Console.WriteLine(g4);
        }
    }
}
