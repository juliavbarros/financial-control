using System.Xml.Serialization;

namespace JVB.FinancialControl.Web.Models.Ecb
{
    [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public class CubeDate
    {
        [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public List<CubeCurrency> Cube { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
    }
}