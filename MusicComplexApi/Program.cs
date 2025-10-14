using Microsoft.EntityFrameworkCore;
using MusicComplexRepositories;
using MusicComplexRepositories.Interfaces;
using MusicComplexRepositories.Implementations;
using MusicComplexServices.Interfaces;
using MusicComplexServices.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MusicDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music API V1");
    c.RoutePrefix = string.Empty; // Доступ за адресою http://localhost:5002/
});

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MusicDbContext>();
    db.Database.Migrate();
    await MusicComplexRepositories.DataSeeder.SeedAsync(db);
}

app.Run();