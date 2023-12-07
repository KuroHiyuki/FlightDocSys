
using FlightDocSys.Models.Context;

using FlightDocSys.Services.CMS;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FlightDocSysContext>();
builder.Services.AddAutoMapper(typeof(Program));                                                                                                                                                               
#region IService Scope
builder.Services.AddScoped<IDocumentList, DocumentList>();
builder.Services.AddScoped<IFlightList,FlightList>();
builder.Services.AddScoped<IDocumentTypeList,DocumentTypeList>();
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
