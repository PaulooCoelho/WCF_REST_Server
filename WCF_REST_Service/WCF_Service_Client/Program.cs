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
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceActions = new ServiceActions();

            serviceActions.ReadWCFData();


            var patient = new Patient();

            patient.Id = 1;
            patient.Name = "Updated";
            patient.Location = "Loures";
            patient.EntryDate = DateTime.Now;

            serviceActions.UpdateWCFData(patient);

            Console.ReadKey();
        }
    }
}
