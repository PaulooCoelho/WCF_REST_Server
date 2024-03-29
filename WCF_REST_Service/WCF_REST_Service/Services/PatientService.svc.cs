﻿using DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_REST_Service.Services.Interfaces;

namespace WCF_REST_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PatientService : IPatientService
    {
        public List<Patient> GetAllPatients()
        {
            using (var db = new PatientsDBEntities())
            {
                return db.Patients.ToList();
            }
        }

        public Patient GetPatient(string id)
        {
            using (var db = new PatientsDBEntities())
            {
                var patientID = Int32.Parse(id);
                return db.Patients.Where(x => x.Id == patientID).SingleOrDefault();
            }
        }

        public int AddPatient(Patient patient)
        {
            using (var db = new PatientsDBEntities())
            {
                db.Patients.Add(patient);
                db.SaveChanges();

                return patient.Id;
            }
        }

        public bool UpdatePatient(Patient _patient)
        {
            using (var db = new PatientsDBEntities())
            {
                var patient = db.Patients.Where(x => x.Id == _patient.Id).SingleOrDefault();

                patient.Name = _patient.Name;
                patient.Location = _patient.Location;
                patient.EntryDate = _patient.EntryDate;

                db.SaveChanges();

                return true;
            }
        }
    }
}
