using System.Data;

namespace HouseRent.Core.ApplicationServices.Contracts;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}