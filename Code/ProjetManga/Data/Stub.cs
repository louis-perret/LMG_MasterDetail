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
            GenreDispo g = GenreDispo.Josei;
            GenreDispo g2 = GenreDispo.Shojo;
            GenreDispo g3 = GenreDispo.Shonen;

            HashSet<Compte> ListeDesComptes = new HashSet<Compte>();
            
            Dictionary<Genre, SortedSet<Manga>> CollectionDesMangas = new Dictionary<Genre, SortedSet<Manga>>();
           
            Listes l = new Listes(ListeDesComptes, CollectionDesMangas);
            l.AjouterUtilisateur(new Compte("xProGamer", "05/05/2015", new DateTime(2021, 12, 12), "azerty123", new GenreDispo[] { g, g2 }));
            l.AjouterUtilisateur(new Compte("xgmm", "05/05/2012", new DateTime(2021, 11, 12), "test", new GenreDispo[] { g, g2 }));
            l.AjouterUtilisateur(new Compte("siphano", "05/05/1999", new DateTime(2021, 11, 11), "frigiel", new GenreDispo[] { g, g2 }));

            l.AjouterManga(new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", "maisone2", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois"),new Genre("Description Shonen", g3));
            l.AjouterManga(new Manga("Death Note", "Note Death", "toujourpas", "encoremoins", "horreur", "maisone2", new DateTime(2002), new DateTime(2005), 36, "dossier/test/", "shinigami "), new Genre("Description Shonen", g3));
            return l;
        }
    }
}
