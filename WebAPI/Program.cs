using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Setup services
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddBusinessServices();
builder.Services.AddFacades();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCorsPolicy();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json", "application/xml"));
});

var app = builder.Build();

// Apply pending migrations
app.ApplyMigrations<BookHubDbContext>();

// Configure middleware pipeline
app.UseSwaggerDocumentation();
app.UseCorsPolicy();
app.UseAppMiddlewares();

app.MapControllers();
app.Run();
