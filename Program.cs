using Microsoft.EntityFrameworkCore;
using movieflix_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var reactApp = "reactAppPolicy";

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors( options =>{
    options.AddPolicy(name: reactApp, builder =>{
        builder.WithOrigins("*");
    });
});


var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var constext = services.GetRequiredService<DataContext>();
await LoadData.LoadMovies(constext);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(reactApp);

app.UseAuthorization();

app.MapControllers();

app.Run();
