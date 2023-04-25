using System.Data.Common;

namespace Proyecto._2doParcial.DataAccess.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }
}