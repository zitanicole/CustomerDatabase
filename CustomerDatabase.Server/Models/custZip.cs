namespace CustomerDatabase.Server.Models
{
	public class custZip
	{
		public int CustZipID { get; set; }	
		public int CustomerID { get; set; }
		public int ZipID { get; set; }	
		public bool IsActive { get; set; }

	}
}
