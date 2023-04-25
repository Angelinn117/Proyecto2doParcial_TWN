using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto._2doParcial.DataAccess.Interfaces;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories;

public class ReparationRepository : IReparationRepository
{
    
    private readonly IDbContext _dbContext;

    public ReparationRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Reparation> SaveAsync(Reparation reparation)
    {
        reparation.Id = await _dbContext.Connection.InsertAsync(reparation);
        return reparation;
    }
    
    public async Task<Reparation> UpdateAsync(Reparation reparation)
    {
        await _dbContext.Connection.UpdateAsync(reparation);
        return reparation;
    }

    public async Task<List<Reparation>> GetAllAsync()
    {
        const string sql = "SELECT * FROM reparation WHERE IsDeleted = 0";
        
        var reparations = await _dbContext.Connection.QueryAsync<Reparation>(sql);
        return reparations.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var reparation =  await GetById(id);
        if (reparation == null)
            return false;
        reparation.IsDeleted = true;
        return await _dbContext.Connection.UpdateAsync(reparation);
    }

    public async Task<Reparation> GetById(int id)
    {
        var reparation = await _dbContext.Connection.GetAsync<Reparation>(id);
        if (reparation == null)
            return null;
        return reparation.IsDeleted == true ? null : reparation;
    }
    
}