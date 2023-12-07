using MedicalApp21.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MedicalApp21.Services
{
 public class ImgService
    {
        private static SQLiteConnection conn = DataAccess.conn;

        //Insert One Img
        public static int AddImg(Img img) => conn.Insert(img);

        //Insert List Of Imgs
        public static int AddAllImgs(ObservableCollection<Img> imgs) => conn.InsertAll(imgs);

        //Update One Img
        public static int UpdateImg(Img img) => conn.Update(img);

        //Update List Of Imgs
        public static int UpdateAllImgs(ObservableCollection<Img> imgs) => conn.UpdateAll(imgs);

        //Delete One Img
        public static int DeleteImg(Img img) => conn.Delete(img);

        //Delete All Imgs (all data in Img table)
        public static int DeleteAllImgs() => conn.DeleteAll<Img>();

        //Get One Img
        public static Img GetImg(int id) => conn.Get<Img>(id);

        //Get All Imgs
        public static ObservableCollection<Img> GetAllImgs() => new ObservableCollection<Img>(conn.Table<Img>().ToList());

        //Get Imgs That BelongsTo Patient
        public static ObservableCollection<Img> GetPatientImgs(int Pa_id) => new ObservableCollection<Img>(conn.Table<Img>().Where(c => c.PatientID.Equals(Pa_id)).ToList() );

        ////Delete Imgs That BelongsTo Patient
        //public static int DeletePatientImgs(int Pa_id) => Convert.ToInt32(conn.Query<Img>($"Delete From Img Where PatientID = {Pa_id}"));

    }
}
