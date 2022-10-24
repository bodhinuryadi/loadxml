using BodhiCreditInfoConsole.Application;

namespace BodhiCreditInfoConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var importXml = new ImportXmlFile("\\XSD\\Data.xsd", "\\XML", "http://creditinfo.com/schemas/Sample/Data");
            var xmlList = importXml.Validate();
            var process = new ProcessXmlFile(xmlList);
            _ = process.LogProcess();
        }
    }
}