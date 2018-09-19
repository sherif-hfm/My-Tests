using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerialization
{
    [Serializable]
    [XmlRoot("RequestDocuments")]
    [XmlType(TypeName = "Document")]
    
    public class DocumentFile
    {
        public string DocumentSerial { get; set; }

         [XmlElement(ElementName = "ImageSerial")]
        public string FileId { get; set; }

        [XmlElement(ElementName = "ImagePath")]
        public string FileName { get; set; }

        [XmlIgnore]
        public long FileSize { get; set; }

        [XmlIgnore]
        public byte[] FileDate { get; set; }
    }
}
