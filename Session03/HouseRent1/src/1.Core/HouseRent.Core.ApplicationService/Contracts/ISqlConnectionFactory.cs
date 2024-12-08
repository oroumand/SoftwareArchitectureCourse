using System.Data;

namespace HouseRent.Core.ApplicationService.Contracts;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}