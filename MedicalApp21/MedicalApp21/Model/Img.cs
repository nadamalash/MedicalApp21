using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp21.Model
{
	public class Img
	{
		[PrimaryKey, AutoIncrement, NotNull, Unique]
		public int ID { get; set; }

		// Specify the foreign key
		[ForeignKey(typeof(Patient))]
		public int PatientID { get; set; }

		public string Description { get; set; }

		[MaxLength(30)]
		public string Result { get; set; }
		public byte[] Name { get; set; }
		public DateTime Date { get; set; }

		// Many to one relationship with Patient

		[ManyToOne]
		public Patient Patient { get; set; }
	}
}
