namespace CustomerDatabase.Server.Models
{
	public class address
	{
        public int AddressID { get; set; }
        public addressType Type { get; set; }
        public string adressLineOne { get; set; }
        public string adressLineTwo { get; set; }   
        public int CustomerID { get; set; }

        public List<custAddress> CustAddresses { get; set; }
        public List<Zipcode> Zipcodes { get; set; }

    }
}
