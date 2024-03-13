using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CustomerDatabase.Server.Data;
using CustomerDatabase.Server.Areas.Identity.Data;
using CustomerDatabase.Server.Models;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CustDataContextConnection") ?? throw new InvalidOperationException("Connection string 'CustDataContextConnection' not found.");

builder.Services.AddDbContext<CustDataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<CustDataUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CustDataContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//seedData
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	try
	{
		seedData.EnsurePopulated(services).Wait();
	}catch (Exception ex)
	{
		//print error message to console
		var logger = services.GetRequiredService<ILogger<Program>>();

		logger.LogError(ex, "Error occurred seeding database");
	}
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.MapFallbackToFile("/index.html");

app.Run();
