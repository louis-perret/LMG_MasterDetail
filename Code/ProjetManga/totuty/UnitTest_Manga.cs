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
            Manga m2 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", "maisone2", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois",GenreDispo.Shonen);
            Manga m3 = new Manga("One Piece", "One Piece", "Eiichirõ Oda", "Eiichirõ Oda", "Shueisha", "Glénat", new DateTime(1997, 06, 22), null, 98, "couvertureOnePiece.png", "Monkey D. Luffy rêve de retrouver ce trésor légendaire et de devenir le nouveau 'Roi des Pirates'. Après avoir mangé un fruit du démon, il possède un pouvoir lui permettant de réaliser son rêve. Il lui faut maintenant trouver un équipage pour partir à l'aventure !", GenreDispo.Shonen);
            
            //Notre equals compare le titre original et le titre alternatif de deux mangas
            Assert.True(m.Equals(m3)); 
            Assert.False(m.Equals(m2)); //Ne possède pas le même titre alternatif
        }

        [Fact]
        public void TestCalculNote()
        {
            /*Listes l1 = stub.Load("");
            Compte u1 = Gestionnaire.ChercherUtilisateur(l1, "Nicolas", "azerty123");
            Avis a = new Avis("Belle couverture et belle oeuvre", 9, u1);

            Manga m1 = Gestionnaire.RechercherMangaParNom(l1, "one piece");
            m1.AjouterAvis(a);
            a = new Avis("Histoire intéressante avec un suspense insoutenable", 1, u1);
            m1.AjouterAvis(a);
            float m = (9 + 1 + 9 + 5) / 4.0f; //Les autres notes viennent de notre stub
            Assert.Equal(m, m1.MoyenneNote);*/
           
        }
    }
}
