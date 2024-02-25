using System.ComponentModel.DataAnnotations;

namespace CustomerDatabase.Server.Models
{
	public class Zipcode
	{
		[Key]public int ZipId { get; set; }
		public int AddressID { get; set; }	
		public int CustomerID { get; set; }	
		public string CityAndState { get; set; }
		public string Zip { get; set; }	
	
		public List<custZip> Zips { get; set; }	

	}
}
