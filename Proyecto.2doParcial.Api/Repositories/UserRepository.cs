using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto._2doParcial.DataAccess.Interfaces;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories;

public class UserRepository : IUserRepository
{
    
    private readonly IDbContext _dbContext;

    public UserRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<User> SaveAsync(User user)
    {
        user.Id = await _dbContext.Connection.InsertAsync(user);
        return user;
    }
    
    public async Task<User> UpdateAsync(User user)
    {
        await _dbContext.Connection.UpdateAsync(user);
        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        const string sql = "SELECT * FROM user WHERE IsDeleted = 0";
        
        var users = await _dbContext.Connection.QueryAsync<User>(sql);
        return users.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user =  await GetById(id);
        if (user == null)
            return false;
        user.IsDeleted = true;
        return await _dbContext.Connection.UpdateAsync(user);
    }

    public async Task<User> GetById(int id)
    {
        var user = await _dbContext.Connection.GetAsync<User>(id);
        if (user == null)
            return null;
        return user.IsDeleted == true ? null : user;
    }
    
}