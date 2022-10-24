using BodhiCreditInfoConsole.Application;

namespace BodhiCreditInfoConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var importXml = new ImportXmlFile("\\XSD\\Data.xsd", "\\XML");
            var xmlList = importXml.Validate();
            var process = new ProcessXmlFile(xmlList);
            process.LogProcess();
        }
    }
}