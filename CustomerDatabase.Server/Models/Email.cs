namespace CustomerDatabase.Server.Models
{
	public class Email
	{
		public int EmailId { get; set; }	
		public int CustomerID { get; set; }	
		public string email { get; set; }	
		public EmailType type { get; set; }
		public bool isActive { get; set; }

	}
}
