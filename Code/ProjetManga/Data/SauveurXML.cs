using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Modele;

namespace Data
{
    public class SauveurXML : Sauveur
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

            var param = new XmlWriterSettings() { Indent = true };
            
            using(TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            {
                using (XmlWriter w = XmlWriter.Create(tw, param)) ;
            }

            using (Stream s = File.Create(Path.Combine(FilePath, FileName)))
            {
                serializer.WriteObject(s, l);
            }

            
        }
    }
}
