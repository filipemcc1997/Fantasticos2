using StayCationCoPilot.Core.Interfaces.Repositories;
using StayCationCoPilot.Core.Settings;
using StayCationCoPilot.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
string hackathonRepository = "HackathonRepository";

// Add services to the container.

builder.Services.AddSingleton<IHackathonRepository, HackathonRepository>();
builder.Services.Configure<RepositorySettings>(builder.Configuration.GetSection(hackathonRepository));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
