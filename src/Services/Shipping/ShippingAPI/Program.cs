using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infra.Data;
using Infra.Implementation.Repositories;
using Infra.Implementation.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
builder.Services.AddScoped<IShipperService, ShipperService>();

builder.Services.AddDbContext<ShippingDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDb"));
});


// Adding Authentication
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
// });


// Swagger authentication
builder.Services.AddSwaggerGen(c =>
{ 
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shipping API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    { 
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
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
});


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
// app.UseAuthorization();
app.MapControllers();

app.Run();