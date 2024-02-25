using System.ComponentModel.DataAnnotations;

namespace CustomerDatabase.Server.Models
{
	public class CallHistory
	{
		[Key]
		public int HistoryID { get; set; }
		public int CustomerID { get; set; }
		public int PhoneID { get; set; }
		public DateTime DateTime { get; set; }
		public string Notes { get; set; }

	}
}
