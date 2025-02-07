using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Kernel.Bootstrap;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Model;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
{
    var certPath = Environment.GetEnvironmentVariable("ASPNETCORE_Kestrel__Certificates__Default__Path");
    var certPassword = Environment.GetEnvironmentVariable("ASPNETCORE_Kestrel__Certificates__Default__Password");

    Console.WriteLine($"Using certificate at {certPath} with password: {certPassword}");

    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(8080); // HTTP inside Docker
        options.ListenAnyIP(8443, listenOptions =>
        {
            listenOptions.UseHttps(certPath!, certPassword); // Load SSL cert
        });
    });

    builder.WebHost.UseUrls("http://*:8080", "https://*:8443");
}

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
                                               .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSerilog();

builder.Services.AddDbContext<RPSContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RockPaperScissors")));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterDependencies());

var app = builder.Build();

app.Services.GetAutofacRoot().SetServiceLocator();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RPSContext>();
    dbContext.Database.Migrate();
}

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
