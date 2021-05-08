using System;
using System.Collections.Generic;
using System.Text;
using Modele;

namespace Data
{
    /// a rajouter dans le diagramme evidemment
    public class Stub : Chargeur
    {
        public Stub(string chemin) :base(chemin)
        {

        }

        public override Listes Load(string chemin)
        {
            ///faire une belle Liste avec des beaux exemples :)
            GenreDispo g = GenreDispo.Josei;
            GenreDispo g2= GenreDispo.Shojo;
            GenreDispo g3 = GenreDispo.Shonen;
            GenreDispo g4 = GenreDispo.Seinen;

            Genre genre1 = new Genre("Description Shonen", g3);
            Genre genre2 = new Genre("Description Seinen", g4);
            Genre genre3 = new Genre("Description Shojo", g2);
            Genre genre4 = new Genre("Description Josei", g);

            Manga m1 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", "maisone2", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois"); 
            Manga m2 = new Manga("HxH", "ezhz", "jesaispas", "nonplus", "genre", "maisone2", new DateTime(2009), new DateTime(2011), 999, "dossier/test/", "epreuve 1 ");
            Manga m3 = new Manga("Death Note", "Note Death", "toujourpas", "encoremoins", "horreur", "maisone2", new DateTime(2002), new DateTime(2005), 36, "dossier/test/", "shinigami ");

            Compte u1 = new Compte("xProGamer", "05/05/2015", new DateTime(2015, 12, 12), "azerty123", new GenreDispo[] { g, g2 });
            Compte u2 = new Compte("xgmm", "05/05/2012", new DateTime(2021, 11, 12), "test", new GenreDispo[] { g, g2 });
            Compte u3 = new Compte("sihano", "05/05/1999", new DateTime(2021, 11, 11), "frigiel", new GenreDispo[] { g, g2 });

            Avis a = new Avis("Belle couverture", 9, new DateTime(2021), u1);
            m1.AjouterAvis(a);
            a = new Avis("Histoire intéressante avec un suspense insoutenable", 1, new DateTime(2021), u1);
            m1.AjouterAvis(a);
            a = new Avis("Histoire intéressante avec un suspense insoutenable", 10, new DateTime(2021), u1);
            m3.AjouterAvis(a);

            List<Compte> ListeDesComptes = new List<Compte>();
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
           
            return l1;
        }
    }
}
