using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerialization
{
    [Serializable]
    [XmlRoot("RRRGeo")]
    public class GeoInfo
    {
        [XmlArray("Markers")]
        [XmlArrayItem("Marker", typeof(MarkerInfo), IsNullable = false)]
        public List<MarkerInfo> Markers { get; set; }
    }

    [Serializable]
    [XmlRoot("Marker")]
    public class MarkerInfo
    {
        [XmlElement("Long")]
        public string Long { get; set; }

        [XmlElement("Lat")]
        public string Lat { get; set; }
    }
}
