using Dapper;
using JWT.Model.Config;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Data
{
    public class BaseRepository
    {
        #region Fields

        public readonly IConfiguration _configuration;

        public readonly IOptions<DataBaseConfig> _connectionString;

        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration, IOptions<DataBaseConfig> connection)
        {
            _configuration = configuration;
            _connectionString = connection;
        }

        #endregion

        #region SQL Methods
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? CommandTimeout = null, CommandType? commandType = null)
        {
            string connString = ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection");
            using (SqlConnection con = new SqlConnection(connString))
            {
                await con.OpenAsync();
                return await con.QueryFirstOrDefaultAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? CommandTimeout = null, CommandType? commandType = null)
        {
            string connString = ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection");
            using (SqlConnection con = new SqlConnection(connString))
            {
                await con.OpenAsync();
                return await con.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
            #endregion
        }

        public async Task<int> ExecuteAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? CommandTimeout = null, CommandType? commandType = null)
        {
            string connString = ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection");
            using (SqlConnection con = new SqlConnection(connString))
            {
                await con.OpenAsync();
                return await con.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
