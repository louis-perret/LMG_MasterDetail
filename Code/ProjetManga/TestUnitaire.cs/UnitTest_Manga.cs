using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Modele;

namespace TestUnitaire.cs
{
    public class UnitTest_Manga
        
    {
        Manga m1 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", "maisone2", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois");
        Manga m12 = new Manga("onePiece", "altertest", "eichiro", "dessinateur", "maisone", "maisonfr", new DateTime(2020), new DateTime(2021), 33, "dossier/test/", "il etait une fois");
        Manga m2 = new Manga("HxH", "ezhz", "jesaispas", "nonplus", "genre", "maisone2", new DateTime(2009), new DateTime(2011), 999, "dossier/test/", "epreuve 1 ");

        [Fact]
        public void TestEqualsManga()
        {
        Assert.True(m1.Equals(m12));
        Assert.False(m1.Equals(m2));
       
        }


        
        [Fact]
        public void TestCalculNote()
        {
            Compte u1 = new Compte("xProGamer", "05/02/2015", new DateTime(2021, 12, 12), GenreDispo.Josei, "azerty123");
            Avis a = new Avis("Belle couverture", 9, new DateTime(2021), u1.Pseudo);
            m1.AjouterAvis(a);
            a = new Avis("Histoire intéressante avec un suspense insoutenable", 1, new DateTime(2021), u1.Pseudo);
            m1.AjouterAvis(a);



            Assert.Equal(5, m1.MoyenneNote);
            

        }
    }
}
