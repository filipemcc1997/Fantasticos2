using Hackathon2.Core.Interfaces.Repositories;
using Hackathon2.Core.Settings;
using Hackathon2.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

string hackathonRepository = "HackathonRepository";

// Add services to the container.
// Add configurations
var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? throw new Exception("ASPNETCORE_ENVIRONMENT variable not set");
ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.SetBasePath(Environment.CurrentDirectory)
 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
 .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
 .AddEnvironmentVariables()
 .AddUserSecrets(Assembly.GetExecutingAssembly(), true);
var config = configurationBuilder.Build();

builder.Configuration.AddConfiguration(config);

builder.Services.Configure<RepositorySettings>(builder.Configuration.GetSection(hackathonRepository));

builder.Services.AddSingleton<IHackathonRepository, HackathonRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
