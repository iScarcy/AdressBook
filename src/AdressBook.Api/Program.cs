using AdressBook.Api.Services;
using AdressBook.Api.Settings;

var builder = WebApplication.CreateBuilder(args);

string Service_URL = builder.Configuration["AppSettings:Service_URL"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddAdressBookDatabaseService(builder.Configuration.GetSection("AdressBookDatabase"));
builder.Services.AddRecurringEventsService(builder.Configuration.GetSection("RecurringEvent"));


var app = builder.Build();

// Configure the HTTP request pipeline.
 
app.UseSwagger();
app.UseSwaggerUI();
 

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run(Service_URL);
