using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Modele;
using Data;

namespace TestUnitaire.cs
{
    public class UnitTest_Manga // a faire avec stub
        
    {
        Stub stub = new Stub("");
        
        [Fact]
        public void TestEqualsManga()
        {
            Listes l1 = stub.Load();

            Manga m = l1.RechercherMangaParNom("one piece");
            Manga m2 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", "maisone2", "06/01/2020", "02/12/2021", 33, "dossier/test/", "il etait une fois",GenreDispo.Shonen);
            Manga m3 = new Manga("One Piece", "One Piece", "Eiichirõ Oda", "Eiichirõ Oda", "Shueisha", "Glénat", "1997, 06, 22", null, 98, "couvertureOnePiece.png", "Monkey D. Luffy rêve de retrouver ce trésor légendaire et de devenir le nouveau 'Roi des Pirates'. Après avoir mangé un fruit du démon, il possède un pouvoir lui permettant de réaliser son rêve. Il lui faut maintenant trouver un équipage pour partir à l'aventure !", GenreDispo.Shonen);
            
            //Notre equals compare le titre original et le titre alternatif de deux mangas
            Assert.True(m.Equals(m3)); 
            Assert.False(m.Equals(m2)); //Ne possède pas le même titre alternatif
        }

        [Fact]
        public void TestCalculNote()
        {
            Listes l1 = stub.Load();
            bool c = l1.ChercherUtilisateur("Nicolas", "azerty123");
            Avis a = new Avis("Belle couverture et belle oeuvre", 9, l1.CompteCourant);

            Manga m1 = l1.RechercherMangaParNom("one piece");
            m1.AjouterAvis(a);
            a = new Avis("Histoire intéressante avec un suspense insoutenable", 1, l1.CompteCourant);
            m1.AjouterAvis(a);
            float m = (9 + 1 + 9 + 5) / 4.0f; //Les autres notes viennent de notre stub
            Assert.Equal(m, m1.MoyenneNote);
           
        }
    }
}
