using Microsoft.EntityFrameworkCore;
using PatikaOdev1.DBOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreDBContext>(options=>options.UseInMemoryDatabase(databaseName: "BookStoreDB"));  ///

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

using(var scope = app.Services.CreateScope()){  //
    var Services = scope.ServiceProvider;      //
    DataGenerator.Initialize(Services);        //
}                                               //

app.Run();
