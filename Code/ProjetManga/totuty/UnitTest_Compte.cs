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
            
            Listes l1 = stub.Load();

            Assert.Equal(18, l1.ListeCompte[0].Age);

        }

        [Fact]
        public void TestFavori()
        {
            Listes l1 = stub.Load();

            bool c = l1.ChercherUtilisateur("Nicolas", "azerty123");
            Manga m = l1.RechercherMangaParNom("one piece");
            l1.CompteCourant.SupprimerFavori(m); //L'instance de u possède déjà le manga One Piece
            //On le supprime de sa liste
            Assert.False(l1.CompteCourant.LesFavoris.Contains(m));

            //Puis on le rajoute
            l1.CompteCourant.AjouterFavori(m); //L'instance de u ne possède plus le manga One Piece
            Assert.True(l1.CompteCourant.LesFavoris.Contains(m));
            
        }

    }
}
