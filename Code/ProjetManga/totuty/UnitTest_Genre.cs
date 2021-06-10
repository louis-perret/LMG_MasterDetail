using System;
using Xunit;
using Modele;
using Data;
namespace TestUnitaire.cs
{
    public class UnitTest_Genre
    {
        
        [Fact]          
        public void TestEqualsGenre()
        {
            
            Stub stub = new Stub("");
            Listes l1 = stub.Load();


            Genre genreTest = new Genre("Le mot « Shonen » signifie en japonais « garçon et adolescent ». Il ne désigne pas à proprement parler un type, mais plutôt une ligne éditoriale du manga qui cible un public jeune de sexe masculin.", GenreDispo.Shonen);

            Assert.True(genreTest.Equals(l1.RecupererGenre(GenreDispo.Shonen)));
            Assert.False(genreTest.Equals(l1.RecupererGenre(GenreDispo.Seinen))); 

        }
    }

}
