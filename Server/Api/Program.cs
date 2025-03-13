using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Kernel.Bootstrap;
using JWTService.Extensions;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Api.Extensions;
using RockPaperScissors.Model;
using RockPaperScissors.Service.BackgroundJobs;
using RockPaperScissors.Service.Hubs;
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

builder.Configuration.ReadJwtConfiguration();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSerilog();

builder.Services.AddDbContext<RPSContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RockPaperScissors")));

builder.Services.AddJwtToServices();
builder.Services.AddSignalR();

builder.Services.AddHostedService<MatchmakingBackgroundJob>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterKernelDependencies()
                                                                                      .RegisterJWTServiceDependencies()
                                                                                      .RegisterRPSDependencies());

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
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowFrontendOrigin");

app.MapControllers();
app.MapHub<RpsHub>("/rpshub");
app.MapDefaultControllerRoute();

app.Run();
