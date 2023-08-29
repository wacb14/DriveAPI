using AutoMapper;
using DriveAPI.BussinesServices;
using DriveAPI.DataServices;
using DriveAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// DB parameters
var dbName = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("UserDB")["DBName"];
var user = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("UserDB")["user"];
var password = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("UserDB")["password"];
var connectionString = "server=localhost; port=3306; database=" + dbName + "; user=" + user + "; password=" + password;

// Add services to the container.
builder.Services.AddTransient<IFileDS, FileDS>();
builder.Services.AddTransient<IFileBS, FileBS>();
builder.Services.AddTransient<IFileStorageDS, FileStorageDS>();
builder.Services.AddTransient<IFileStorageBS, FileStorageBS>();
builder.Services.AddHttpContextAccessor();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<GeneralContext>(
            dbContextOptions => dbContextOptions
                .UseMySQL(connectionString)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Automapper
var mapperConfig = new MapperConfiguration(
                mc =>
                {
                    mc.AddProfile(new MappingProfile());
                }
            );
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
