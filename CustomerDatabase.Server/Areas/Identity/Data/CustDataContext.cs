using CustomerDatabase.Server.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CustomerDatabase.Server.Models;

namespace CustomerDatabase.Server.Data;

public class CustDataContext : IdentityDbContext<CustDataUser>
{
    public DbSet<Customer> Customers { get; set; }
    public CustDataContext(DbContextOptions<CustDataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<CustomerDatabase.Server.Models.address> address { get; set; } = default!;

public DbSet<CustomerDatabase.Server.Models.CallHistory> CallHistory { get; set; } = default!;

public DbSet<CustomerDatabase.Server.Models.custAddress> custAddress { get; set; } = default!;

public DbSet<CustomerDatabase.Server.Models.custPhone> custPhone { get; set; } = default!;

public DbSet<CustomerDatabase.Server.Models.custZip> custZip { get; set; } = default!;

public DbSet<CustomerDatabase.Server.Models.Email> Email { get; set; } = default!;

public DbSet<CustomerDatabase.Server.Models.PhoneNumber> PhoneNumber { get; set; } = default!;
}
