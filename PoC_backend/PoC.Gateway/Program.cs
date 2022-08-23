using System.Runtime.CompilerServices;
using PoC.Gateway;
[assembly: InternalsVisibleTo("PoC.Gateway.Tests")]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProcessesDictionary,ProcessesDictionary>();
var app = builder.Build();
string targetPath = @$"C:\Users\csonkal\Desktop\PoC\PoC_backend\Versions";
System.IO.Directory.Delete(targetPath,true);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();