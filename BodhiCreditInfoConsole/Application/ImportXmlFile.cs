using BodhiCreditInfoConsole.Model;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace BodhiCreditInfoConsole.Application
{
    public class ImportXmlFile
    {
        private string _xsdPath;
        private string _xmlFolder;
        private string _targetNameSpace;
        public ImportXmlFile(string xsdPath, string xmlFolder, string targetNameSpace)
        {
            _xsdPath = xsdPath;
            _xmlFolder = xmlFolder;
            _targetNameSpace = targetNameSpace;
        }
        public List<XmlFile> Validate()
        {
            List<XmlFile> xmlFiles = new List<XmlFile>();
            try
            {
                var basePath = Directory.GetCurrentDirectory();
                XmlSchemaSet schema = new XmlSchemaSet();
                schema.Add(_targetNameSpace, basePath + _xsdPath);
                List<string> xmlList = Directory.GetFiles(basePath + _xmlFolder, "*.xml").ToList();
                foreach (string xmlFileName in xmlList)
                {
                    XmlReader rd = XmlReader.Create(xmlFileName);
                    XDocument doc = XDocument.Load(rd);
                    var xmlFile = new XmlFile
                    {
                        FileName = xmlFileName,
                        XmlRecords = doc,
                        IsValid = true
                    };
                    doc.Validate(schema, (o, e) =>
                    {
                        xmlFile.ErrorMessage = e.Message;
                        xmlFile.IsValid = false;
                    });
                    xmlFiles.Add(xmlFile);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error on ValidateXmlFile : " + e.Message);
            }
            return xmlFiles;
        }
    }
}
