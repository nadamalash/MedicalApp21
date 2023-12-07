using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp21.Model
{
	public class Drug
	{
		// Specify the foreign key
		[ForeignKey(typeof(Patient))]
		public int PatientID { get; set; }

		[MaxLength(30)]
		public string Name { get; set; }

        // Specify composite primary key
        [PrimaryKey]
        public string ToBeKey { get; set; }


        // Many to one relationship with Patient

        [ManyToOne]
		public Patient Patient { get; set; }

	}
}
