using System.Xml.Serialization;

namespace JVB.FinancialControl.Web.Models.Ecb
{
    [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public class CubeBase
    {
        [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public List<CubeDate> Cube { get; set; }
    }
}