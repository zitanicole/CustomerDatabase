using System.ComponentModel.DataAnnotations;

namespace CustomerDatabase.Server.Models
{
	public class PhoneNumber
	{
		[Key]
		public int PhoneID { get; set; }	
		public int CustomerID { get; set; }	
		public PhoneType Type { get; set; }	
		public string phoneNumber { get; set; }	
		
		public List<CallHistory> CallHistory { get; set; }  
	}
}
