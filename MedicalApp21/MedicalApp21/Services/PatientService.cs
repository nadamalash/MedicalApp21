using MedicalApp21.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MedicalApp21.Services
{
    public class PatientService 
    {
        private static SQLiteConnection conn = DataAccess.conn;

        //Insert One Patient
        public static int AddPatient(Patient patient) => conn.Insert(patient);

        //Insert List Of Patients
        public static int AddAllPatients(ObservableCollection<Patient> patients) => conn.InsertAll(patients);

        //Update One Patient
        public static int UpdatePatient(Patient patient) => conn.Update(patient);

        //Update List Of Patients
        public static int UpdateAllPatients(ObservableCollection<Patient> patients) => conn.UpdateAll(patients);

        //Delete One Patient
        public static int DeletePatient(Patient patient) => conn.Delete(patient);

        //Delete All Patients (all data in patient table)
        public static int DeleteAllPatients() => conn.DeleteAll<Patient>();

        //Get One Patient
        public static Patient GetPatient(int id) => conn.Get<Patient>(id);

        //Get All Patients
        public static ObservableCollection<Patient> GetAllPatients() => new ObservableCollection<Patient>(conn.Table<Patient>().ToList());

        //Get Patients With Name (For SearchBar)
        public static ObservableCollection<Patient> GetPatientsWithName(string name) => new ObservableCollection<Patient>(conn.Table<Patient>().Where(c=>c.Name.Contains(name)).ToList());



    }
}
