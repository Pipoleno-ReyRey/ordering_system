using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? credentials = builder.Configuration.GetConnectionString("connectionCredentials");
builder.Services.AddControllers();
builder.Services.AddScoped<HttpConsume>();

builder.Services.AddDbContext<CartDb>(db => db.UseMySql(credentials, new MySqlServerVersion(ServerVersion.AutoDetect(credentials))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

