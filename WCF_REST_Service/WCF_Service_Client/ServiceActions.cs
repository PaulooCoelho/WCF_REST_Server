using DataAccess.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Service_Client
{
    public class ServiceActions
    {
        public void ReadWCFData()
        {
            var endpoint = "http://localhost:50525/Services/PatientService.svc/AllPatients";
            var request = HttpWebRequest.Create(endpoint);

            request.Method = "GET";

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    // throw error
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var streamReader = new StreamReader(responseStream))
                        {
                            var streamResponseValue = streamReader.ReadToEnd();
                            var patientsList = JsonConvert.DeserializeObject<List<Patient>>(streamResponseValue);

                            foreach (var patient in patientsList)
                            {
                                Console.WriteLine(patient.Id);
                                Console.WriteLine(patient.Name);
                                Console.WriteLine(patient.Location);
                                Console.WriteLine(patient.EntryDate);
                            }
                        }
                    }
                }
            }
        }

        public void UpdateWCFData(Patient patient)
        {

        }
    }
}
