using System.Data;

namespace DataAccess.Connection
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
