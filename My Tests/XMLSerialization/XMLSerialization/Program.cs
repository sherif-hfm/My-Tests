using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
namespace XMLSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //SerDocFiles();
            SerGeoInfo();
        }

        private static void SerGeoInfo()
        {
            GeoInfo geoInfo = new GeoInfo();
            geoInfo.Markers = new List<MarkerInfo>();
            geoInfo.Markers.Add(new MarkerInfo() { Lat = "1", Long = "11" });
            geoInfo.Markers.Add(new MarkerInfo() { Lat = "2", Long = "22" });

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;
            writerSettings.Indent = true;
            writerSettings.Encoding = Encoding.Unicode;


            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //ns.Add("perfic", "ns");
            ns.Add("", "");

            XmlSerializer ser = new XmlSerializer(typeof(GeoInfo));
            XmlWriter xmlWriter = XmlWriter.Create(@"d:\result.xml", writerSettings);
            StringWriter textWriter = new StringWriter();
            ser.Serialize(textWriter, geoInfo, ns);
            ser.Serialize(xmlWriter, geoInfo, ns);
            //ser.Serialize(xmlWriter, geoInfo);
            
            xmlWriter.Close();
        }

        private static void SerDocFiles()
        {
            List<DocumentFile> files = new List<DocumentFile>();
            DocumentFile file1 = new DocumentFile();
            file1.DocumentSerial = "1";
            file1.FileId = "10";
            file1.FileName = "file1";
            files.Add(file1);

            DocumentFile file2 = new DocumentFile();
            file2.DocumentSerial = "1";
            file2.FileId = "20";
            file2.FileName = "file2";
            files.Add(file2);

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            //writerSettings.OmitXmlDeclaration = true;
            writerSettings.Indent = true;
            writerSettings.Encoding = Encoding.Unicode;


            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //ns.Add("perfic", "ns");
            ns.Add("", "");

            XmlSerializer ser = new XmlSerializer(typeof(List<DocumentFile>), new XmlRootAttribute("RequestDocuments"));
            //XmlSerializer ser = new XmlSerializer(typeof(List<DocumentFile>));

            XmlWriter xmlWriter = XmlWriter.Create(@"d:\result.xml", writerSettings);
            StringWriter textWriter = new StringWriter();
            ser.Serialize(textWriter, files, ns);
            ser.Serialize(xmlWriter, files, ns);
            //ser.Serialize(xmlWriter, files);
            xmlWriter.Close();

        }

        private void SerFamily()
        {
            Person sherif = new Person() { Id = 1, Name = "شريف", Gender = 'M' };
            Wife soha = new Wife() { Id = 2, Name = "Soha", Gender = 'F' };
            Son mohamed = new Son() { Id = 3, Name = "Mohamed", Gender = 'M', SchoolName = "School1" };
            Son moaz = new Son() { Id = 4, Name = "Moaz", Gender = 'M', SchoolName = "School2" };

            sherif.FamilyMembers = new List<Person>();
            sherif.FamilyMembers.Add(soha);
            sherif.FamilyMembers.Add(mohamed);
            sherif.FamilyMembers.Add(moaz);

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            //writerSettings.OmitXmlDeclaration = true;
            writerSettings.Indent = true;
            writerSettings.Encoding = Encoding.Unicode;


            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("perfic", "ns");
            //ns.Add("", "");
            XmlSerializer ser = new XmlSerializer(typeof(Person), "SherifFamily");

            XmlWriter xmlWriter = XmlWriter.Create(@"d:\result.xml", writerSettings);
            ser.Serialize(xmlWriter, sherif, ns);
            xmlWriter.Close();
        }
    }


    [XmlRoot("Family")]
    [XmlType("NewTypeName")]
    public class Person
    {
        [XmlElement(ElementName = "PersonId")]
        public int Id { get; set; }

        [XmlAttribute("PersonName")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Gender", Type = typeof(char))]
        public char Gender { get; set; }

        [XmlArray("FamilyMembers")]
        [XmlArrayItem("FamilyMember") , XmlArrayItem(Type = typeof(Wife)), XmlArrayItem(Type = typeof(Son))]
        public List<Person> FamilyMembers { get; set; }

        
        public string DataType
        {
            get
            {
                return typeof(Person).GetProperty("DataType").GetGetMethod().ReturnType.ToString();
            }
        }
    }

    public class Father : Person
    {

    }

    public class Wife : Person
    {

    }

    public class Son : Person
    {
        public string SchoolName { get; set; }
    }
}
