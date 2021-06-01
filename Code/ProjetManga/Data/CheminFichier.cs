using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data
{
    public abstract class CheminFichier
    {
        protected string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");

        protected string FileName { get; set; } = "LMG.xml";

        protected string MyFile => Path.Combine(FilePath, FileName);
    }
}
