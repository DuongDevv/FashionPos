using FashionPos.Api.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.NameTranslation;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure CORS to allow Next.js Frontend (localhost:3001) to call API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();

// Configure Npgsql DataSource with NullNameTranslator to preserve uppercase ENUM values
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
dataSourceBuilder.MapEnum<MembershipTierEnum>("membership_tier", new NpgsqlNullNameTranslator());
dataSourceBuilder.MapEnum<EmployeeRoleEnum>("employee_role", new NpgsqlNullNameTranslator());
dataSourceBuilder.MapEnum<EmployeeStatusEnum>("employee_status", new NpgsqlNullNameTranslator());
dataSourceBuilder.MapEnum<PaymentMethodEnum>("payment_method", new NpgsqlNullNameTranslator());
dataSourceBuilder.MapEnum<DiscountTypeEnum>("discount_type", new NpgsqlNullNameTranslator());
dataSourceBuilder.MapEnum<OrderStatusEnum>("order_status", new NpgsqlNullNameTranslator());
var dataSource = dataSourceBuilder.Build();

// Configure EF Core with PostgreSQL
builder.Services.AddDbContext<FashionPosDbContext>(options =>
    options.UseNpgsql(dataSource));

// Dependency Injection
builder.Services.AddScoped<FashionPos.Api.Services.IOrderService, FashionPos.Api.Services.OrderService>();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Enable CORS Middleware
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
