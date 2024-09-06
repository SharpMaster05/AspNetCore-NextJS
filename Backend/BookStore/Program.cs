using BookStore.BLL.Servises;
using BookStore.DAL.Context;
using BookStore.DAL.Repositories;
using BookStore.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BookConnection");

builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IBooksRepositories, BooksRepositories>();
builder.Services.AddScoped<IBooksService, BooksService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.Run();
