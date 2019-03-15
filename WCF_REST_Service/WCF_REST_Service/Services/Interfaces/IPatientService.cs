using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_REST_Service.DataAccess.EF;

namespace WCF_REST_Service.Services.Interfaces
{
    [ServiceContract]
    public interface IPatientService
    {
        [OperationContract]
        [WebGet(UriTemplate="AllPatients", ResponseFormat=WebMessageFormat.Json)]
        List<Patient> GetAllPatients();

        [OperationContract]
        [WebGet(UriTemplate="Patient/{id}", ResponseFormat=WebMessageFormat.Xml)]
        Patient GetPatient(string id);

        [OperationContract]
        [WebInvoke(UriTemplate="Patient/Add", Method="POST")]
        int AddPatient(Patient patient);

        [OperationContract]
        [WebInvoke(UriTemplate="Patient/Update", Method = "PUT")]
        bool UpdatePatient(Patient _patient);
    }
}
