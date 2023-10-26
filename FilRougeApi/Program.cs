using FilRougeApi.Data;
using FilRougeApi.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.InjectDependancies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(option =>
{
    option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});


app.UseAuthorization();

app.MapControllers();

app.Run();
