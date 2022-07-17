using System;

namespace Projekt_ProgramowanieO.Database.Tables
{
	public class ZamowieniaSamochodow
	{
		public int ID { get; set; }
		public int SamochodID { get; set; }
		public DateTime DataZamowienia { get; set; }
		public int StatusID { get; set; }
	}
}
