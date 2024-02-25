namespace CustomerDatabase.Server.Models
{
	public class custPhone
	{
		public int custPhoneID { get; set; }
		public int CustomerID { get; set; }
		public int PhoneID { get; set; }
		public bool IsActive { get; set; }	
	}
}
