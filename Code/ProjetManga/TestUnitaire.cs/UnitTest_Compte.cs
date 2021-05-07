using System;
using Xunit;
using Modele;


namespace TestUnitaire.cs
{
    public class UnitTest_Compte
    {
     
            [Fact]
            public void TestAge()
            {
            Compte u1 = new Compte("xProGamer", "05/02/2015", new DateTime(2021, 12, 12), GenreDispo.Josei, "azerty123");
            Assert.Equal(6, u1.Age);

            }
        
    }
}
