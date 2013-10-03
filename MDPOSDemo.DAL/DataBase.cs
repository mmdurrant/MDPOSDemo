using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using MDPOSDemo.CC;

namespace MDPOSDemo.DAL
{
    public abstract class DataBase
    {

        //TODO: Put these in app.config settings
        private const bool IsBufferedDefault = true;
        private const int CommandTimeoutDefault = 30000;

        private Func<string, IDbConnection> _dbConnectionFactory;
        private bool _isBuffered = IsBufferedDefault;
        private string _connectionString;
        private int _commandTimeout = CommandTimeoutDefault;

        protected int CommandTimeout
        {
            get { return _commandTimeout; }
            set { _commandTimeout = value; }
        }

        protected string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        protected Func<string, IDbConnection> DbConnectionFactory
        {
            get { return _dbConnectionFactory ?? (_dbConnectionFactory = Factories.DbConnectionFactory.GetDbConnection); }
            set { _dbConnectionFactory = value; }
        }

        protected bool IsBuffered
        {
            get { return _isBuffered; }
            set { _isBuffered = value; }
        }

        public Result<IEnumerable<T>> Query<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            var result = new Result<IEnumerable<T>>();

            using (var conn = DbConnectionFactory(ConnectionString))
            {
                try
                {
                    conn.Open();
                    var dbResult = conn.Query<T>(sql, param, transaction, IsBuffered, CommandTimeout, commandType.HasValue ? commandType.Value : CommandType.Text);
                    result.Value = dbResult;
                }
                catch (SqlException sqlException)
                {
                    result.AddError("Error executing database statement {0}", sql);
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return result;
        }
    }
}