using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto._2doParcial.DataAccess.Interfaces;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Core.Entities;


namespace Proyecto._2doParcial.Repositories.Interfaces;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDbContext _dbContext;

    public CustomerRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Customer> SaveAsync(Customer customer)
    {
        customer.Id = await _dbContext.Connection.InsertAsync(customer);
        return customer;
    }
    
    public async Task<Customer> UpdateAsync(Customer customer)
    {
        await _dbContext.Connection.UpdateAsync(customer);
        return customer;
    }
    
    //Nos quedamos aquí. Cambiamos el nombre de la base de datos para arreglar el error de que se buscaban
    //las tablas incorrectas.

    public async Task<List<Customer>> GetAllAsync()
    {
        const string sql = "SELECT * FROM customer WHERE IsDeleted = 0";
        
        var customers = await _dbContext.Connection.QueryAsync<Customer>(sql);
        return customers.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer =  await GetById(id);
        if (customer == null)
            return false;
        customer.IsDeleted = true;
        return await _dbContext.Connection.UpdateAsync(customer);
    }

    public async Task<Customer> GetById(int id)
    {
        var customer = await _dbContext.Connection.GetAsync<Customer>(id);
        if (customer == null)
            return null;
        return customer.IsDeleted == true ? null : customer;
    }
    
}