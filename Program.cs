
using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddOpenAIService(settings => 
settings.ApiKey = "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");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
