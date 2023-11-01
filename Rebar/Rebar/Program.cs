using Rebar.Models;
using Rebar.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("MyDatabase")
    );

//resolving the ShakeService dependency here
builder.Services.AddTransient<IShakeService, ShakeService>();
//resolving the OrderService dependency here
builder.Services.AddTransient<IOrderService, OrderService>();
//resolving the ShakeToOrderService dependency here
builder.Services.AddTransient<IShakeToOrderService, ShakeToOrderService>();

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
