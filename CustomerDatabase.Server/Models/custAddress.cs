namespace CustomerDatabase.Server.Models
{
	public class custAddress
	{
		public int CustAddressID { get; set; }
		public int CustomerID { get; set; }
		public int AddressID { get; set; }
		public bool IsActive { get; set; }

	}
}
