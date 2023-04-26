using Dapper.Contrib.Extensions;
using Proyecto._2doParcial.Core.Entities;
using Proyecto._2doParcial.DataAccess;
using Proyecto._2doParcial.DataAccess.Interfaces;
using Proyecto._2doParcial.Repositories;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services;
using Proyecto._2doParcial.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IProductCategoryRepository, ProductCategoryRepository>();

builder.Services.AddScoped<IApparatusRepository, ApparatusRepository>();
builder.Services.AddScoped<IApparatusService, ApparatusService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
builder.Services.AddScoped<ICustomerAddressService, CustomerAddressService>();

builder.Services.AddScoped<IWarrantyRepository, WarrantyRepository>();
builder.Services.AddScoped<IWarrantyService, WarrantyService>();

builder.Services.AddScoped<IReparationRepository, ReparationRepository>();
builder.Services.AddScoped<IReparationService, ReparationService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IDbContext, DbContext>();

SqlMapperExtensions.TableNameMapper = entityType =>
{
    var name = entityType.ToString();
    if (name.Contains("Proyecto._2doParcial.Core.Entities."))
        name = name.Replace("Proyecto._2doParcial.Core.Entities.", "");
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};

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

