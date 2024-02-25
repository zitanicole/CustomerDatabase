namespace CustomerDatabase.Server.Models
{
	public class Customer
	{
        public int CustomerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<custAddress> addresses { get; set; }
        public List<custZip> zips { get; set; }
        public List<Email> emails { get; set; }
        public List<custPhone> phoneNumbers { get; set; }
        public List<CallHistory> CallHistoryNotes { get; set; }

      
    }
}
