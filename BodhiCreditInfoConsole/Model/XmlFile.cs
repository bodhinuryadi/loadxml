using System.Xml.Linq;

namespace BodhiCreditInfoConsole.Model
{
    public class XmlFile
    {
        public string FileName { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public XDocument? XmlRecords { get; set; }
        public bool IsProcessed { get; set; }
    }
}
