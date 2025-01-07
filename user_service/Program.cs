using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? credentials = builder.Configuration.GetConnectionString("connectionCredentials");

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UsersDb>(db => db.UseMySql(credentials, 
new MySqlServerVersion(ServerVersion.AutoDetect(credentials))));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

