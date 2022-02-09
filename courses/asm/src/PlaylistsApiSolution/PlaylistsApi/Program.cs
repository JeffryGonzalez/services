using Microsoft.EntityFrameworkCore;
using PlaylistsApi.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlaylistsDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("playlists"));
});
var app = builder.Build();

var scope = app.Services.CreateScope();
using(var db = scope.ServiceProvider.GetRequiredService<PlaylistsDataContext>())
{
    db.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
