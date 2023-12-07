using MedicalApp21.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MedicalApp21.Services
{
    public static class DrugService
    {

        private static SQLiteConnection conn = DataAccess.conn;

        //Insert One Drug
        public static int AddDrug(Drug drug) => conn.Insert(drug);

        //Insert List Of Drugs
        public static int AddAllDrugs(ObservableCollection<Drug> drugs) => conn.InsertAll(drugs);

        //Update One Drug
        public static int UpdateDrug(Drug drug) => conn.Update(drug);

        //Update List Of Drugs
        public static int UpdateAllDrugs(ObservableCollection<Drug> drugs) => conn.UpdateAll(drugs);

        //Delete One Drug
        public static int DeleteDrug(Drug drug) => conn.Delete(drug);

        //Delete All Drugs (all data in Drug table)
        public static int DeleteAllDrugs() => conn.DeleteAll<Drug>();

        //Get One Drug
        public static Drug GetDrug(string Comp_Key) => conn.Get<Drug>(Comp_Key);

        //Get All Drugs
        public static ObservableCollection<Drug> GetAllDrugs() => new ObservableCollection<Drug>(conn.Table<Drug>().ToList());

        //Get Drugs That BelongsTo Patient
        public static ObservableCollection<Drug> GetPatientDrugs(int id) => new ObservableCollection<Drug>(conn.Table<Drug>().Where(c => c.PatientID.Equals(id)).ToList());







    }
}
