using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Core.Kernel.Bootstrap;
using Core.Kernel.DataAccess.Context;
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
//builder.Services.AddDbContext<Context>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterDependencies());


var app = builder.Build();

//builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterDependencies(app.Services.GetAutofacRoot()));
app.Services.GetAutofacRoot().SetServiceLocator();
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
