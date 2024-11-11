using GlobalExceptionHandler.DI;
using SystemManagementFactory.Extensions.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler.GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddServices();
builder.AddDbContext();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler("/error");

app.MapControllers();

app.Run();
