
using FlightDocSys.Models.Context;
using FlightDocSys.Controllers;
using FlightDocSys.Services.CMS.IService;
using FlightDocSys.Services.CMS.Service;
using FlightDocSys.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Book API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddDbContext<FlightDocSysContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<FlightDocSysContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.RequireHttpsMetadata = false;
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT: ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration["JWT: Secret"]))
    };

});

#region IService Scope
builder.Services.AddScoped<IDocument, FlightDocSys.Services.CMS.Service.Document>();
builder.Services.AddScoped<IFlight, FlightDocSys.Services.CMS.Service.Flight>();
builder.Services.AddScoped<IDocumentType,DocumentType>();
builder.Services.AddScoped<ISetting, FlightDocSys.Services.CMS.Service.Setting>();
builder.Services.AddScoped<IGroupPermission,FlightDocSys.Services.CMS.Service.GroupPermission>();
builder.Services.AddScoped<IDocumentDetail, FlightDocSys.Services.CMS.Service.DocumentDetail>();
builder.Services.AddScoped<IFlightDetail, FlightDocSys.Services.CMS.Service.FlightDetail>();
#endregion

var app = builder.Build();

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
