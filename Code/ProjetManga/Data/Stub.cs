using System;
using System.Collections.Generic;
using System.Text;
using Modele;

namespace Data
{
    /// <summary>
    /// Cette classe simule un faux chargement de données
    /// </summary>
    public class Stub : Chargeur
    {
        public Stub(string chemin) :base(chemin)
        {

        }

        /// <summary>
        /// Charge des données fictives
        /// </summary>
        /// <returns>Renvoie un objet Listes : données fictive</returns>
        public override Listes Load()
        {
           
            
            GenreDispo g1 = GenreDispo.Shonen;
            GenreDispo g2 = GenreDispo.Seinen;           
            GenreDispo g3= GenreDispo.Shojo;
            GenreDispo g4 = GenreDispo.Josei;

            Genre genre1 = new Genre("Le mot « Shonen » signifie en japonais « garçon et adolescent ». Il ne désigne pas à proprement parler un type, mais plutôt une ligne éditoriale du manga qui cible un public jeune de sexe masculin.", g1);
            Genre genre2 = new Genre("Le mot « Seinen » signifie en japonais « jeune homme ». Il ne désigne pas à proprement parler un type, mais plutôt une ligne éditoriale du manga qui cible un public composé de jeunes hommes", g2);
            Genre genre3 = new Genre("Le mot « Shojo » signifie en japonais « jeune fille ». Il ne désigne pas à proprement parler un type, mais plutôt une ligne éditoriale du manga qui cible un public jeune de sexe feminin.", g3);
            Genre genre4 = new Genre("Le mot « Josei » signifie en japonais « jeune femme ». Il ne désigne pas à proprement parler un type, mais plutôt une ligne éditoriale du manga qui cible un public composé de jeunes femmes.", g4);
            List<Genre> lGenre = new List<Genre>();
            lGenre.Add(genre1);
            lGenre.Add(genre2);
            lGenre.Add(genre3);
            lGenre.Add(genre4);

            /*Manga m1 = new Manga("One Piece", "One Piece", "Eiichirõ Oda", "Eiichirõ Oda", "Shueisha", "Glénat", new DateTime(1997,06,22), null, 98, "/Image;Component/Image/couvertureOP.jpg", "Monkey D. Luffy rêve de retrouver ce trésor légendaire et de devenir le nouveau 'Roi des Pirates'. Après avoir mangé un fruit du démon, il possède un pouvoir lui permettant de réaliser son rêve. Il lui faut maintenant trouver un équipage pour partir à l'aventure !", g1); 
            Manga m2 = new Manga("Death Note", "Death Note", "Tsugumi Oba", "Takeshi Obata", "Shueisha", "Kana", new DateTime(2003,12,01), new DateTime(2006,05,15), 13, "/Image;Component/Image/couvertureDN.jpg", "Light Yagami est un lycéen surdoué qui juge le monde actuel criminel, pourri et corrompu. Sa vie change du tout au tout le jour où il ramasse par hasard un mystérieux cahier intitulé « Death Note ». Son mode d'emploi indique que « la personne dont le nom est écrit dans ce cahier meurt ».", g1);
            Manga m3 = new Manga("Tokyo Guru", "Tokyo Ghoul", "Sui Ishida", "Sui Ishida", "Shueisha", "Glénat", new DateTime(2011, 09, 08), new DateTime(2014, 09, 18), 14, "/Image;Component/ImagecouvertureTokyoGhoul.png", "Synopsis. Dans la ville de Tokyo, des créatures nommées goules sont apparues et se nourrissent de chair humaine pour survivre. Un jour, Ken Kaneki, jeune étudiant, se fait attaquer par l'une d'entre elles et subit une grave blessure.", g2);
            Manga m4 = new Manga("Tokyo Guru:Re", "Tokyo Ghoul:Re", "Sui Ishida", "Sui Ishida", "Shueisha", "Glénat", new DateTime(2014, 11, 16), new DateTime(2018, 07, 05), 16, "/Image;Component/couvertureTokyoGhoulRe.png", "Deux ans après les événements qui ont impliqué les goules du 20ème et le CCG, on suit Haise Sasaki, un inspecteur du CCG et son équipe, assignés pour traquer une goule sans scrupule qui se fait passer pour un chauffeur de taxi. Si on fait appel à eux pour ce cas, c'est parce qu'ils possèdent des caractéristiques bien précises...", g2);
            Manga m5 = new Manga("Nana", "Nana", "Ai Yazawa", "Ai Yazawa", "Shueisha", "Akata", new DateTime(2000, 05, 15), null, 21, "/Image;Component/Image/couvertureNana.png", "Dans le Japon contemporain, deux jeunes femmes se rencontrent dans le train les conduisant à Tokyo. ... Trouvant avantageux de partager les frais de loyer, elles décident de vivre en colocation dans l'appartement 707 (c'est une autre coïncidence car leur prénom, Nana, représente le chiffre 7 en japonais).", g3);
            Manga m6 = new Manga("Furūtsu Basuketto", "Fruits Basket", "NastukiTakaya", "NastukiTakaya", "Hakusensha", "Delcourt", new DateTime(1998, 07, 01), new DateTime(2006, 11, 01), 23, "/Image;Component/Image/couvertureFruitsBasket.png", " Tohru Honda est une lycéenne de 16 ans qui vit seule sous une tente après la mort de sa mère. ... Ayant appris qu'elle vivait sous une tente, ils lui proposent de loger chez eux en échange de tâches ménagères. Tohru accepte et commence alors à vivre avec Yuki, Kyô et Shigure.", g3);
            Manga m7 = new Manga("Paradaisu Kisu", "Paradise Kiss", "Ai Yazawa", "Ai Yazawa", "Shodensha", "Kana", new DateTime(200, 04, 01), new DateTime(2003, 09, 01), 5, "/Image;Component/Image/couvertureParadiseKiss.png", "Yukari est une jeune lycéenne modèle n'écoutant que ses parents. Elle veut rentrer dans une prestigieuse université afin d'avoir un avenir brillant jusqu'au jour où elle fait la rencontre d'un groupe d'étudiants travaillant dans la mode, et ayant leur propre marque de vêtement : 'Paradise Kiss'", g4);
            Manga m8 = new Manga("Nodame Cantabile", "Nodame Cantabile", "Tomoko Ninomiya", "Tomoko Ninomiya", "Kodansha", "Pika Edition", new DateTime(2001, 07, 10), new DateTime(2009, 10, 10), 23, "/Image;Component/Image/couvertureNodame.png", "C'est l'histoire de Shin'ichi Chiaki, étudiant en 3eme classe de piano à l'Académie de musique Momogaoka. Né dans une famille de musiciens, il est un excellent pianiste et violoniste. Son rêve est de devenir chef d'orchestre comme son mentor Sebastiano Viera. Il se sent prisonnier au Japon et perçoit son avenir musical en noir. C'est dans ce contexte qu'il rencontre Megumi Node (Nodame) qui ne sait pas lire une partition. Mais elle tombe amoureuse de Chiaki et ces deux personnages vont mutuellement se rapprocher...", g4);
            */

            Manga m1 = new Manga("One Piece", "One Piece", "Eiichirõ Oda", "Eiichirõ Oda", "Shueisha", "Glénat", "1997, 06, 22", null, 98, "/Image;Component/Image/couvertureOP.jpg", "Monkey D. Luffy rêve de retrouver ce trésor légendaire et de devenir le nouveau 'Roi des Pirates'. Après avoir mangé un fruit du démon, il possède un pouvoir lui permettant de réaliser son rêve. Il lui faut maintenant trouver un équipage pour partir à l'aventure !", g1);
            Manga m2 = new Manga("Death Note", "Death Note", "Tsugumi Oba", "Takeshi Obata", "Shueisha", "Kana", "2003, 12, 01", "2006, 05, 15", 13, "/Image;Component/Image/couvertureDN.jpg", "Light Yagami est un lycéen surdoué qui juge le monde actuel criminel, pourri et corrompu. Sa vie change du tout au tout le jour où il ramasse par hasard un mystérieux cahier intitulé « Death Note ». Son mode d'emploi indique que « la personne dont le nom est écrit dans ce cahier meurt ».", g1);
            Manga m3 = new Manga("Tokyo Guru", "Tokyo Ghoul", "Sui Ishida", "Sui Ishida", "Shueisha", "Glénat", "2011, 09, 08", "2014, 09, 18", 14, "/Image;Component/Image/couvertureTG.png", "Synopsis. Dans la ville de Tokyo, des créatures nommées goules sont apparues et se nourrissent de chair humaine pour survivre. Un jour, Ken Kaneki, jeune étudiant, se fait attaquer par l'une d'entre elles et subit une grave blessure.", g2);
            Manga m4 = new Manga("Tokyo Guru:Re", "Tokyo Ghoul:Re", "Sui Ishida", "Sui Ishida", "Shueisha", "Glénat","2014, 11, 16", "2018, 07, 05", 16, "/Image;Component/Image/couvertureTGRE.png", "Deux ans après les événements qui ont impliqué les goules du 20ème et le CCG, on suit Haise Sasaki, un inspecteur du CCG et son équipe, assignés pour traquer une goule sans scrupule qui se fait passer pour un chauffeur de taxi. Si on fait appel à eux pour ce cas, c'est parce qu'ils possèdent des caractéristiques bien précises...", g2);
            Manga m5 = new Manga("Nana", "Nana", "Ai Yazawa", "Ai Yazawa", "Shueisha", "Akata", "2000, 05, 15", null, 21, "/Image;Component/Image/couvertureN.jpg", "Dans le Japon contemporain, deux jeunes femmes se rencontrent dans le train les conduisant à Tokyo. ... Trouvant avantageux de partager les frais de loyer, elles décident de vivre en colocation dans l'appartement 707 (c'est une autre coïncidence car leur prénom, Nana, représente le chiffre 7 en japonais).", g3);
            Manga m6 = new Manga("Furūtsu Basuketto", "Fruits Basket", "NastukiTakaya", "NastukiTakaya", "Hakusensha", "Delcourt", "1998, 07, 01", "2006, 11, 01", 23, "/Image;Component/Image/couvertureFB.jpg", " Tohru Honda est une lycéenne de 16 ans qui vit seule sous une tente après la mort de sa mère. ... Ayant appris qu'elle vivait sous une tente, ils lui proposent de loger chez eux en échange de tâches ménagères. Tohru accepte et commence alors à vivre avec Yuki, Kyô et Shigure.", g3);
            Manga m7 = new Manga("Paradaisu Kisu", "Paradise Kiss", "Ai Yazawa", "Ai Yazawa", "Shodensha", "Kana", "200, 04, 01", "2003, 09, 01", 5, "/Image;Component/Image/couverturePK.jpg", "Yukari est une jeune lycéenne modèle n'écoutant que ses parents. Elle veut rentrer dans une prestigieuse université afin d'avoir un avenir brillant jusqu'au jour où elle fait la rencontre d'un groupe d'étudiants travaillant dans la mode, et ayant leur propre marque de vêtement : 'Paradise Kiss'", g4);
            Manga m8 = new Manga("Nodame Cantabile", "Nodame Cantabile", "Tomoko Ninomiya", "Tomoko Ninomiya", "Kodansha", "Pika Edition", "2001, 07, 10", "2009, 10, 10", 23, "/Image;Component/Image/couvertureNC.jpg", "C'est l'histoire de Shin'ichi Chiaki, étudiant en 3eme classe de piano à l'Académie de musique Momogaoka. Né dans une famille de musiciens, il est un excellent pianiste et violoniste. Son rêve est de devenir chef d'orchestre comme son mentor Sebastiano Viera. Il se sent prisonnier au Japon et perçoit son avenir musical en noir. C'est dans ce contexte qu'il rencontre Megumi Node (Nodame) qui ne sait pas lire une partition. Mais elle tombe amoureuse de Chiaki et ces deux personnages vont mutuellement se rapprocher...", g4);


            Compte u1 = new Compte("Nicolas", "05/05/2003", new DateTime(2021, 03, 03), "azerty123", new GenreDispo[] { g1, g2 }, "/Image;Component/Image/L.png");
            Compte u2 = new Compte("Frederic", "11/08/1972", new DateTime(2021, 04, 02), "test", null,null);
            Compte u3 = new Compte("Camille", "05/01/2004", new DateTime(2021, 03, 12), "frigiel", new GenreDispo[] { g2, g4 },null);

            Avis a = new Avis("Belle couverture", 9,u1);
            m1.AjouterAvis(a);
            a = new Avis("Histoire intéressante, mais je n'ai pas accroché", 5,u3);
            m1.AjouterAvis(a);
            a = new Avis("Histoire intéressante avec un suspense insoutenable", 10, u3);
            m2.AjouterAvis(a);

            List<Compte> ListeDesComptes = new List<Compte>();
            ListeDesComptes.Add(u1);
            ListeDesComptes.Add(u2);
            ListeDesComptes.Add(u3);

            Dictionary<Genre, SortedSet<Manga>> CollectionDesMangas = new Dictionary<Genre, SortedSet<Manga>>();
            SortedSet<Manga> lesJosei = new SortedSet<Manga>();
            SortedSet<Manga> lesShonen = new SortedSet<Manga>();
            SortedSet<Manga> lesSeinen = new SortedSet<Manga>();
            SortedSet<Manga> lesShojo = new SortedSet<Manga>();
            lesShonen.Add(m1);
            lesShonen.Add(m2);
            lesSeinen.Add(m3);
            lesSeinen.Add(m4);
            lesShojo.Add(m5);
            lesShojo.Add(m6);
            lesJosei.Add(m7);
            lesJosei.Add(m8);


            
            CollectionDesMangas.Add(genre1, lesShonen);
            CollectionDesMangas.Add(genre2, lesSeinen);
            CollectionDesMangas.Add(genre3, lesShojo);
            CollectionDesMangas.Add(genre4, lesJosei);
            Listes l1 = new Listes(ListeDesComptes, CollectionDesMangas,lGenre);

            u1.AjouterFavori(m1);
            u1.AjouterFavori(m2);
            u3.AjouterFavori(m2);
            
            return l1;
        }
    }
}
