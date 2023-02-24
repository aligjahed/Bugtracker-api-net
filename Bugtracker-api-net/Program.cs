using Bugtracker_api_net;
using Bugtracker_api_net.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// All services are inside ~/ConfigureServices.cs
builder.Services.AddServices();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// apply migrations at runtime
using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetService<DataContext>().Database.MigrateAsync();
}

app.Run();