using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess:ISqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<IEnumerable<T>> LoadData<T, U>(string storedprocedure,U parameters, string connectionId = "Default")
        {
            using IDbConnection connection =  new SqlConnection(_configuration.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedprocedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(
            
            string storedProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure,parameters,commandType: CommandType.StoredProcedure);


        }
        
    }
}
