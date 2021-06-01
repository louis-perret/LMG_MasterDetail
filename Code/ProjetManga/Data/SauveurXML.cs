using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Modele;

namespace Data
{
    class SauveurXML : Sauveur
    {
        public SauveurXML(string chemin) : base(chemin)
        {
        }

        public override void Save(Listes l)
        {

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            var serializer = new DataContractSerializer(typeof(Listes), 
                new DataContractSerializerSettings() { PreserveObjectReferences = true });

            //using(Stream s = new File

            
        }
    }
}
