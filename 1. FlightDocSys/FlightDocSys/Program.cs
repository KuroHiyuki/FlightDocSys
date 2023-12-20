
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
using FlightDocSys.Authorize;
using FlightDocSys.FileHandler;
using Newtonsoft.Json;

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
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<FlightDocSysContext>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<FlightDocSysContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new { Error = "Bạn chưa đăng nhập" });
            return context.Response.WriteAsync(result);
        }
    };
});

#region IService Scope
builder.Services.AddScoped<IDocumentService, FlightDocSys.Services.CMS.Service.DocumentService>();
builder.Services.AddScoped<IFlightService, FlightDocSys.Services.CMS.Service.FlightService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ISettingService, FlightDocSys.Services.CMS.Service.SettingService>();
builder.Services.AddScoped<IGroupPermissionService,FlightDocSys.Services.CMS.Service.GroupPermissionService>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IPermissionService,PermissionService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
