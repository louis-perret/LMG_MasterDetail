using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Modele;

namespace Data
{
    public class ChargeurXML : Chargeur
    {
        protected string FilePath => Path.Combine(Directory.GetCurrentDirectory(), chemin);

        protected string FileName { get; set; } = "LMG.xml";

        protected string MyFile => Path.Combine(FilePath, FileName);

        public ChargeurXML(string chemin) : base(chemin)
        {
        }

        public override Listes Load()
        {
            if (File.Exists(FileName))
            {
                throw new FileNotFoundException("Le fichier de persistance est manquant");
            }

            Listes l;

            var serializer = new DataContractSerializer(typeof(Listes));
            using(Stream s = File.OpenRead(MyFile))
            {
                l = serializer.ReadObject(s) as Listes;
            }
            return l;
        }
    }
}
