var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var reactApp = "reactAppPolicy";

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
