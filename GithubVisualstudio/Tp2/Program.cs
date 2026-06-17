<<<<<<< HEAD
=======

using Tp2.Service;

>>>>>>> origin/Miguel
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
<<<<<<< HEAD
=======
builder.Services.AddSingleton<JuegoService>();
>>>>>>> origin/Miguel
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
<<<<<<< HEAD

app.UseAuthorization();

app.MapControllers();

=======
app.UseAuthorization();
app.MapControllers();

JuegoService juegoService = new JuegoService();

>>>>>>> origin/Miguel
app.Run();
