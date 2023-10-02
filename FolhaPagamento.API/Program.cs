using Controllers.Contracts;
using Models;
using Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<FolhaPagamentoContext>(
    options => options
    .UseMySQL("Server=127.0.0.1;Database=folha_pagamento;Uid=root;Pwd=root;")
);

builder.Services.AddControllers();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
