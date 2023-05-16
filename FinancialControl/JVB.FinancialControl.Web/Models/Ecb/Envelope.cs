using System.Xml.Serialization;

namespace JVB.FinancialControl.Web.Models.Ecb
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
    public class Envelope
    {
        [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public CubeBase Cube { get; set; }
    }
}