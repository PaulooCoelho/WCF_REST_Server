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
        [WebGet]
        List<Patient> GetAllPatients();

        [OperationContract]
        [WebGet]
        Patient GetPatient(int id);
    }
}
