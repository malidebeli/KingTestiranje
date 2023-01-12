using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TicketOffice.Api.Mapping;
using TicketOffice.Api.Resources;
using TicketOffice.Api.Validators;
using TicketOffice.Core.Models.Identity;
using TicketOffice.Data;
using TicketOffice.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Data
builder.Services.ConfigureDataRegistration(configuration);
//Services
builder.Services.ConfigureServicesRegistration(configuration);

//validators
builder.Services.AddTransient<IValidator<SaveOrderResource>, SaveOrderResourceValidator>();
builder.Services.AddTransient<IValidator<UserCredentialResource>, UserCredentialResourceValidator>();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TicketOffice.Api"
    });

});

//maper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new DomainToResource());
    cfg.AddProfile(new ResourceToDomain());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);



var app = builder.Build();

//sees
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;    
    TicketOfficeDbContextSeed.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
