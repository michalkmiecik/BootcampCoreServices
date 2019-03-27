using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BootcampCoreServices
{
    class InputFile
    {
        public string FullPath { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int NoOfBadRequestsInFile { get; set; }
        public string Content { get; set; }
        public List<request> AllRequests { get; set; }

        public InputFile(string path)
        {
            InitializeClass();

            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                this.FullPath = file.FullName;
                this.Name = file.Name;
                this.Extension = file.Extension;
                this.Content = File.ReadAllText(path, Encoding.UTF8);
                LoadFile();
            }
        }

        private void InitializeClass()
        {
            AllRequests = new List<request>();
            NoOfBadRequestsInFile = 0;
        }

        public void LoadFile()
        {
            switch (this.Extension)
            {
                case ".csv":
                    LoadCSVFromFileToDatabase(this.FullPath);
                    break;
                case ".json":
                    LoadJSONFromFileToDatabase(this.FullPath);
                    break;
                case ".xml":
                    LoadXMLFromFileToDatabase(this.FullPath);
                    break;
                default:
                    {
                        MessageBox.Show("Wybrano nieobsługiwane pliki.\nObsługiwane formaty to CSV, JSON, XML", "Wybrano złe pliki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void LoadXMLFromFileToDatabase(string filePath)
        {
            string xmlString = File.ReadAllText(filePath, Encoding.UTF8);
            using (StringReader sr = new StringReader(xmlString))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<request>), new XmlRootAttribute("requests"));
                List<request> requests = (List<request>)ser.Deserialize(sr);
                ValidateAndAddToDatabase(requests);
            }
        }

        private void LoadJSONFromFileToDatabase(string filePath)
        {
            string jsonString = File.ReadAllText(filePath, Encoding.UTF8);
            Root root = JsonConvert.DeserializeObject<Root>(jsonString);
            ValidateAndAddToDatabase(root.requests);
        }

        private void LoadCSVFromFileToDatabase(string filePath)
        {
            List<request> requests = new List<request>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string csvHeader = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] requestInfo = line.Split(',');
                    request r = new request(requestInfo);
                    requests.Add(r);
                }
            }
            ValidateAndAddToDatabase(requests);
        }

        private void ValidateAndAddToDatabase(List<request> data)
        {
            foreach (request r in data)
            {
                if (r.clientId == null || r.name == null || r.price == 0 || r.quantity == 0 || r.requestId == 0)
                {
                    NoOfBadRequestsInFile++;
                } else
                {
                    if (r.clientId.Length > 6 || r.clientId.Contains(" ") || r.name.Length > 255)
                        NoOfBadRequestsInFile++;
                    else
                        AllRequests.Add(r);
                }
            }
        }
    }
}
