using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using pontosys.Data.Context;
using pontosys.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddFluentValidation(options =>
                {
                    // Validate child properties and root collection elements
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;

                    // Automatic registration of validators in assembly
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PontosysContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("PontoSysDB"));
    });

builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
