using Aspose.Words;
using Aspose.Words.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocxConvertUsingAspose
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document(@"d:\DocFlow2.doc");
            SaveOptions option = SaveOptions.CreateSaveOptions(SaveFormat.Png);
            doc.Save(@"d:\test2.png", option);
        }
    }
}
