using System.Xml.Serialization;

namespace JVB.FinancialControl.Web.Models.Ecb
{
    [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public class CubeCurrency
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlAttribute(AttributeName = "rate")]
        public string Rate { get; set; }
    }
}
