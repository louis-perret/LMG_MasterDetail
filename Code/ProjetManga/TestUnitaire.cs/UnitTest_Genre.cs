using System;
using Xunit;
using Modele;

namespace TestUnitaire.cs
{
    public class UnitTest_Genre
    {
        [Fact]
        public void TestEqualsGenre()
        {
            // a faire avec stub ducoup
            GenreDispo g = GenreDispo.Josei;
            GenreDispo g3 = GenreDispo.Shonen;
            Genre genre1 = new Genre("Description Shonen", g);
            
            Genre genre12 = new Genre("Description Shonen", g);
            Genre genre3 = new Genre("Description Shojo", g3);

            Assert.True(genre12.Equals(genre1));
            Assert.False(genre1.Equals(genre3));
            
        }
    }

}
