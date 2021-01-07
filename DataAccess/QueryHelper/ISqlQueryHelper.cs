using SqlKata;
using System.Data;

namespace DataAccess.QueryHelper
{
    public interface ISqlQueryHelper
    {
        IDbConnection Connection { get; }

        string Compile(Query query);
    }
}
