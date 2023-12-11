
using FlightDocSys.Models.Context;
using FlightDocSys.Controllers;
using FlightDocSys.Services.CMS.IService;
using FlightDocSys.Services.CMS.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FlightDocSysContext>();
builder.Services.AddAutoMapper(typeof(Program));


#region IService Scope
builder.Services.AddScoped<IDocument, Document>();
builder.Services.AddScoped<IFlight,Flight>();
builder.Services.AddScoped<IDocumentType,DocumentType>();
builder.Services.AddScoped<ISetting,Setting>();
builder.Services.AddScoped<IGroupPermission,GroupPermission>();
builder.Services.AddScoped<IDocumentDetail, DocumentDetail>();
builder.Services.AddScoped<IFlightDetail, FlightDetail>();
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
