using DAL.Data;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Setup services
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddBusinessServices();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCorsPolicy();

builder.Services.AddControllers();

var app = builder.Build();

// Apply pending migrations
app.ApplyMigrations<BookHubDbContext>();

// Configure middleware pipeline
app.UseSwaggerDocumentation();
app.UseCorsPolicy();
app.UseAppMiddlewares();

app.MapControllers();
app.Run();
