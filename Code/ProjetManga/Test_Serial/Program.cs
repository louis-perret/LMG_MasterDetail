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
            Listes l1 = stub.Load("");

            SauveurXML s = new SauveurXML("");
            s.Save(l1);
        }
    }
}
