using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto._2doParcial.DataAccess.Interfaces;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories;

public class CustomerAddressRepository : ICustomerAddressRepository
{
    private readonly IDbContext _dbContext;

    public CustomerAddressRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<CustomerAddress> SaveAsync(CustomerAddress customerAddress)
    {
        customerAddress.Id = await _dbContext.Connection.InsertAsync(customerAddress);
        return customerAddress;
    }
    
    public async Task<CustomerAddress> UpdateAsync(CustomerAddress customerAddress)
    {
        await _dbContext.Connection.UpdateAsync(customerAddress);
        return customerAddress;
    }

    public async Task<List<CustomerAddress>> GetAllAsync()
    {
        const string sql = "SELECT * FROM customeraddress WHERE IsDeleted = 0";
        
        var customerAddresss = await _dbContext.Connection.QueryAsync<CustomerAddress>(sql);
        return customerAddresss.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customerAddress =  await GetById(id);
        if (customerAddress == null)
            return false;
        customerAddress.IsDeleted = true;
        return await _dbContext.Connection.UpdateAsync(customerAddress);
    }

    public async Task<CustomerAddress> GetById(int id)
    {
        var customerAddress = await _dbContext.Connection.GetAsync<CustomerAddress>(id);
        if (customerAddress == null)
            return null;
        return customerAddress.IsDeleted == true ? null : customerAddress;
    }
    
}