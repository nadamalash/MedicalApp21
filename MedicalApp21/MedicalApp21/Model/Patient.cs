using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MedicalApp21.Model
{
	public class Patient
	{
		[PrimaryKey, AutoIncrement, NotNull, Unique]
		public int ID { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(11)]
		public string Phone { get; set; }

		public string Address { get; set; }

		[MaxLength(20)]
		public int Age { get; set; }

		[MaxLength(20)]
		public string Gender { get; set; }

		[OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
		public ObservableCollection<Drug> Drugs { get; set; }

		[OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
		public ObservableCollection<Img> Images { get; set; }

	}
}
