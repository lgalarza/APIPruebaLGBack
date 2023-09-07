using APIPruebaLG.Contexto;
using Microsoft.EntityFrameworkCore;
using APIPruebaLG.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PruebaLGDBContext>(options =>options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddScoped<CrudData>();

builder.Services.AddCors(
    options => {
        options.AddPolicy(name: "API",
        builder =>
        {
            builder.WithHeaders("*");
            builder.WithOrigins("*");
            builder.WithMethods("*");
        });
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("API");

app.MapControllers();

app.Run();
