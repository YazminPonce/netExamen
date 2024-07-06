using Microsoft.EntityFrameworkCore;
using piyama.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//traemos la cadena de conecion del appsettings
var connecionString = builder.Configuration.GetConnectionString("cadenaSQL");
//agregamos la configuracion para SQL 
builder.Services.AddDbContext<PiyamaenContext>(options => options.UseSqlServer(connecionString));

builder.Services.AddCors(options =>

{
    options.AddPolicy("NuevaPolitica",
    app => {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//activar la nueva politica
app.UseCors("NuevaPolitica");
app.UseAuthorization();

app.MapControllers();

app.Run();
