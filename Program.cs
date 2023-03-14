using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models;
using ZooManagement;
using ZooManagement.Repositories;
using ZooManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IAnimalRepo, AnimalRepo>();

builder.Services.AddDbContext<ZooManagementDbContext>(options =>
{
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    options.UseSqlite("Data Source=ZooManagement.db");
});


builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "zoo", Version = "v1" });
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "zoo v1"));
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

CreateDbIfNotExists(app);
app.Run();

static void CreateDbIfNotExists(IHost host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ZooManagementDbContext>();
    context.Database.EnsureCreated();

        if (!context.Animal.Any())
        {
            var animal = SampleAnimals.GetAnimals();
            context.Animal.AddRange(animal);
            context.SaveChanges();

    //         var posts = SamplePosts.GetPosts();
    //         context.Posts.AddRange(posts);
    //         context.SaveChanges();

    //         var interactions = SampleInteractions.GetInteractions();
    //         context.Interactions.AddRange(interactions);
    //         context.SaveChanges();
        }
}
