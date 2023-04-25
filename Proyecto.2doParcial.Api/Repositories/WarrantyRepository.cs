using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto._2doParcial.DataAccess.Interfaces;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories;

public class WarrantyRepository : IWarrantyRepository
{
    
    private readonly IDbContext _dbContext;

    public WarrantyRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Warranty> SaveAsync(Warranty warranty)
    {
        warranty.Id = await _dbContext.Connection.InsertAsync(warranty);
        return warranty;
    }
    
    public async Task<Warranty> UpdateAsync(Warranty warranty)
    {
        await _dbContext.Connection.UpdateAsync(warranty);
        return warranty;
    }

    public async Task<List<Warranty>> GetAllAsync()
    {
        const string sql = "SELECT * FROM warranty WHERE IsDeleted = 0";
        
        var warrantys = await _dbContext.Connection.QueryAsync<Warranty>(sql);
        return warrantys.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var warranty =  await GetById(id);
        if (warranty == null)
            return false;
        warranty.IsDeleted = true;
        return await _dbContext.Connection.UpdateAsync(warranty);
    }

    public async Task<Warranty> GetById(int id)
    {
        var warranty = await _dbContext.Connection.GetAsync<Warranty>(id);
        if (warranty == null)
            return null;
        return warranty.IsDeleted == true ? null : warranty;
    }
    
}