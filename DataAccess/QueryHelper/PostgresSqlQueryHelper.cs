using DataAccess.Connection;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.QueryHelper
{
    public class PostgresSqlQueryHelper : ISqlQueryHelper
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly Compiler _compiler;

        public PostgresSqlQueryHelper(ISqlConnectionFactory sqlConnectionFactory, Compiler compiler)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _compiler = compiler;
        }

        public IDbConnection Connection
        {
            get
            {
                return _sqlConnectionFactory.GetOpenConnection();
            }
        }

        public string Compile(Query query)
        {
            return _compiler.Compile(query).ToString();
        }
    }
}
