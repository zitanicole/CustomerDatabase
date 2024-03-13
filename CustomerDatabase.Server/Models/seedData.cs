using CustomerDatabase.Server.Data;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace CustomerDatabase.Server.Models
{
    public class seedData
    {
        public static async Task EnsurePopulated(IServiceProvider services)
        {
            CustDataContext context = services.GetService<CustDataContext>();   

            if (context == null)
            {
                throw new NullReferenceException("No Context Available");
            }

            if (context.Customers.Any())
            {
                return;
            }
            else
            {
                //throw new Exception("No Data Available");
                // ^^ I couldn't find this in my output
                Customer customer = new Customer
                {
                    firstName = "Test",
                    lastName = "Data",
                    // not sure how to do the lists/foreign keys
                
                };

                context.Customers.Add(customer);    
                await context.SaveChangesAsync();  
             
            }


        }
    }
}
