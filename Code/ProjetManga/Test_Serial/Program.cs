using Data;
using Modele;
using System;

namespace Test_Serial
{
    class Program
    {
        static void Main(string[] args)
        {
            Stub stub = new Stub("");
            Listes l1 = stub.Load();

            SauveurXML s = new SauveurXML("../../..//XML");
            s.Save(l1);

            Listes l;
            Chargeur chargeur = new ChargeurXML("../../..//XML");
            l = chargeur.Load();
            Console.WriteLine(l);
        }
    }
}
