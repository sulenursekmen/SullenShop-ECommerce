using Microsoft.EntityFrameworkCore;
using Serilog;
using SullensShop.Application.Features.CQRS.Handlers.CategoryDetailHandlers;
using SullensShop.Application.Features.CQRS.Handlers.CategoryHandlers;
using SullensShop.Application.Features.CQRS.Handlers.ProductHandlers;
using SullensShop.Application.Interfaces;
using SullensShop.Persistence.Context;
using SullensShop.Persistence.Repositories;
using SullensShop.WebApi.Services.LoggerService;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SullensShopContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Host.UseSerilog((context, conf) =>
{
    conf.ReadFrom.Configuration(context.Configuration);
});

//Product
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();
builder.Services.AddScoped<GetProductQueryHandler>();
builder.Services.AddScoped<RemoveProductCommandHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();
builder.Services.AddScoped<GetProductListWithCategoryQueryHandler>();


//Category
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

//CategoryDetail
builder.Services.AddScoped<CreateCategoryDetailCommandHandler>();
builder.Services.AddScoped<GetCategoryDetailByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryDetailQueryHandler>();
builder.Services.AddScoped<RemoveCategoryDetailCommandHandler>();
builder.Services.AddScoped<UpdateCategoryDetailCommandHandler>();

builder.Services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
