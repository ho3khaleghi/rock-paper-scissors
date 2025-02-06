using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Kernel.Bootstrap;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Model;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

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
