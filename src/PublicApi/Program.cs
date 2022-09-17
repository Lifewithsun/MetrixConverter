using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using PublicApi;
using PublicApi.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinimalApi.Endpoint.Configurations.Extensions;
using MinimalApi.Endpoint.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints();

// Use to force loading of appsettings.json of test project
builder.Configuration.AddConfigurationFile("appsettings.test.json");
Microsoft.eShopWeb.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

builder.Services.AddMemoryCache();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
    c.SchemaFilter<CustomSchemaFilters>();

   
});

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var matrixContext = scopedProvider.GetRequiredService<MatrixDataContext>();
        await MatrixDataContextSeed.SeedAsync(matrixContext, app.Logger);    
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapEndpoints();
app.Run();

public partial class Program { }
