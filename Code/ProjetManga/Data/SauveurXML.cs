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

        protected string FilePath => Path.Combine(Directory.GetCurrentDirectory(), chemin);

        protected string FileName { get; set; } = "LMG.xml";

        protected string MyFile => Path.Combine(FilePath, FileName);

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
            
            using(TextWriter tw = File.CreateText(MyFile)) //Permet d'indenter automatiquement le fichier xml
            {
                using (XmlWriter w = XmlWriter.Create(tw, param))
                {
                    serializer.WriteObject(w, l);
                }
            }

            

            
        }
    }
}
