using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using BACKEND.Core.Enums;

namespace BACKEND.Infra.Repos
{
    public class BaseRepository<Entity> where Entity : class
    {
        #region Fields
        string _connection_string = string.Empty;
        protected string TableName = string.Empty;

        protected IDbConnection connection = null;

        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _connection_string = "Server=b738iwjjktqxwu1dlp1p-mysql.services.clever-cloud.com;User ID=uckw5o6komfx5m4u;Password=54k62OBhiR1XVCJGZFZl;Database=b738iwjjktqxwu1dlp1p"; ;
            TableName = typeof(Entity).Name;
        }

        #endregion

        #region Methods
        public async Task<IEnumerable<Entity>> GetAllEntity()
        {
            using (connection = new MySqlConnection(_connection_string))
            {
                var sql = $"SELECT * FROM {TableName}";
                var entities = await connection.QueryAsync<Entity>(sql);
                return entities;
            }
        }

        public async Task<Entity> GetEntityById(Guid entityId)
        {
            using (connection = new MySqlConnection(_connection_string))
            {
                var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id = @{entityId}Id";
                var parameters = new DynamicParameters();
                parameters.Add($"@{entity}Id", entityId);
                var entity = await connection.QueryFirstOrDefaultAsync<Entity>(sql);
                return entity;
            }
        }

        // public async Task<int> UpdateEntity(Entity entity)
        // {
        //     using (connection = new MysqlConnection(_connection_string))
        //     {
        //         //
        //         var Properties = typeof(Entity).GetProperties();


        //     }
        // }

        // public async Task<int> DeleteEntity(Guid entityId)
        // {
        //     using (connection = new MysqlConnection(_connection_string))
        //     {

        //     }
        // }
    }

}
