using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto._2doParcial.DataAccess.Interfaces;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories;

public class ApparatusRepository : IApparatusRepository
{
    
    private readonly IDbContext _dbContext;

    public ApparatusRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Apparatus> SaveAsync(Apparatus apparatus)
    {
        apparatus.Id = await _dbContext.Connection.InsertAsync(apparatus);
        return apparatus;
    }
    
    public async Task<Apparatus> UpdateAsync(Apparatus apparatus)
    {
        await _dbContext.Connection.UpdateAsync(apparatus);
        return apparatus;
    }

    public async Task<List<Apparatus>> GetAllAsync()
    {
        const string sql = "SELECT * FROM apparatus WHERE IsDeleted = 0";
        
        var apparatuss = await _dbContext.Connection.QueryAsync<Apparatus>(sql);
        return apparatuss.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var apparatus =  await GetById(id);
        if (apparatus == null)
            return false;
        apparatus.IsDeleted = true;
        return await _dbContext.Connection.UpdateAsync(apparatus);
    }

    public async Task<Apparatus> GetById(int id)
    {
        var apparatus = await _dbContext.Connection.GetAsync<Apparatus>(id);
        if (apparatus == null)
            return null;
        return apparatus.IsDeleted == true ? null : apparatus;
    }
    
}