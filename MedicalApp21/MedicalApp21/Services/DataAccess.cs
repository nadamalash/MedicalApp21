using MedicalApp21.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp21.Services
{
    public  class DataAccess
    {
        public static SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
        public static void CreateLocaldbTables()
        {
            conn.CreateTable<Patient>();
            conn.CreateTable<Drug>();
            conn.CreateTable<Img>();
        }

    }
}
