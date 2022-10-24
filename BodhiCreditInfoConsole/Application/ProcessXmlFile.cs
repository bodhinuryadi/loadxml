using BodhiCreditInfoConsole.Model;

namespace BodhiCreditInfoConsole.Application
{
    public class ProcessXmlFile
    {
        private List<XmlFile> _xmlFiles;
        public ProcessXmlFile(List<XmlFile> xmlFiles)
        {
            _xmlFiles = xmlFiles;
        }
        public async Task LogProcess()
        {
            try
            {
                foreach (XmlFile xmlFile in _xmlFiles.Where(p => p.IsValid))
                {
                    Console.WriteLine("Processing : " + xmlFile.FileName);
                    xmlFile.IsProcessed = true;
                }
                foreach (XmlFile xmlFile in _xmlFiles.Where(p => !p.IsValid))
                {
                    Console.WriteLine($"Invalid XML : {xmlFile.FileName} , Error Message : {xmlFile.ErrorMessage} " );
                    xmlFile.IsProcessed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on ProcessXmlFile : " + e.Message);
            }
        }
    }
}
