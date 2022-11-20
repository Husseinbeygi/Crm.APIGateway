using Ocelot.DependencyInjection;
using Ocelot.Middleware;


new WebHostBuilder()
.UseKestrel()
.UseContentRoot(Directory.GetCurrentDirectory())
.ConfigureAppConfiguration((hostingContext, config) =>
{
	config
		.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
		.AddJsonFile("appsettings.json", true, true)
		.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json"
																					, true, true)
		.AddJsonFile("ocelot.json")
		.AddEnvironmentVariables();
})
.ConfigureServices(s => {
	s.AddOcelot();
})
.ConfigureLogging((hostingContext, logging) =>
{
	//add your logging
	
})
.UseIISIntegration()
.Configure(app =>
{
	app.UseOcelot().Wait();
})
.Build()
.Run();


//var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
//					.AddJsonFile("appsettings.json", true, true)
//					.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
//					.AddJsonFile("ocelot.json")
//					.AddEnvironmentVariables();


//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddOcelot();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseOcelot();

//app.UseAuthorization();

//app.MapControllers();


//app.Run();
