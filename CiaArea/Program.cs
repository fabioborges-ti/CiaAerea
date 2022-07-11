using CiaArea.Data.Contexts;
using CiaArea.Middlewares;
using CiaArea.Services;
using CiaArea.Services.Interfaces;
using CiaArea.Validators.Aeronave;
using CiaArea.Validators.Piloto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IAeronaveService, AeronaveService>();
builder.Services.AddScoped<IPilotoService, PilotoService>();

builder.Services.AddScoped<IncluirAeronaveValidator>();
builder.Services.AddScoped<EditarAeronaveValidator>();
builder.Services.AddScoped<ExcluirAeronaveValidator>();

builder.Services.AddScoped<IncluirPilotoValidator>();
builder.Services.AddScoped<EditarPilotoValidator>();
builder.Services.AddScoped<ExcluirPilotoValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ValidationExceptionHandler>();
app.Run();
