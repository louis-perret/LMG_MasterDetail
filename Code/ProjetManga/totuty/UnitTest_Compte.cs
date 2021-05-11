using System;
using Xunit;
using Modele;
using Data;

namespace TestUnitaire.cs
{
    public class UnitTest_Compte
    {
        Stub stub = new Stub("");

        [Fact]
        public void TestAge()
        {
            
            Listes l1 = stub.Load("");

            Assert.Equal(18, l1.ListeCompte[0].Age);

        }

        [Fact]
        public void TestFavori()
        {
            Listes l1 = stub.Load("");

            Compte u = Gestionnaire.ChercherUtilisateur(l1, "Nicolas", "azerty123");
            Manga m = Gestionnaire.RechercherMangaParNom(l1, "one piece");
            u.SupprimerFavori(m); //L'instance de u possède déjà le manga One Piece
            //On le supprime de sa liste
            Assert.False(u.LesFavoris.Contains(m));

            //Puis on le rajoute
            u.AjouterFavori(m); //L'instance de u ne possède plus le manga One Piece
            Assert.True(u.LesFavoris.Contains(m));

        }

    }
}
