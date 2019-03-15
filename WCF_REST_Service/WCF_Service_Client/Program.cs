using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Service_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxyServer = new WebClient();
            var serviceUrl = String.Format("http://localhost:50525/Services/PatientService.svc/AllPatients");
            var _data = proxyServer.DownloadData(serviceUrl);
            var _memoryStream = new MemoryStream(_data);
            var reader = new StreamReader(_memoryStream);
            var result = reader.ReadToEnd();



            Console.WriteLine(result.ToString());
        }
    }
}
