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
using BACKEND.Core.Interfaces.Infrastructure;

namespace BACKEND.Infra.Repos
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
    {
        #region Fields
        string _connection_string = string.Empty;
        protected string TableName = string.Empty;
        protected IDbConnection connection = null;

        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _connection_string = configuration.GetConnectionString("ConnectionString");
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
                var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id = @{TableName}Id";
                var parameters = new DynamicParameters();
                parameters.Add($"@{TableName}Id", entityId);
                var entity = await connection.QueryFirstOrDefaultAsync<Entity>(sql, parameters);
                return entity;
            }
        }

        public async Task<bool> AddEntity(Entity entity)
        {
            using (connection = new MySqlConnection(_connection_string))
            {

                var properties = typeof(Entity).GetProperties();
                var parameters = new DynamicParameters();
                var columnsName = string.Empty;
                foreach (var prop in properties)
                {
                    columnsName += $"@{prop.Name},";
                    parameters.Add($"@{prop.Name}", prop.GetValue(entity));
                    Console.WriteLine($"prop name {prop.Name}, prop value {prop.GetValue(entity)}, sqlvalue name {columnsName}");
                }
                columnsName = columnsName.Remove(columnsName.Length - 1);
                var sql = $"INSERT INTO {TableName} VALUES ({columnsName})";
                var result = await connection.ExecuteAsync(sql, parameters);
                return result > 0;

            }
        }
        public async Task<bool> UpdateEntity(Entity entity)
        {
            var entityId = entity.GetType().GetProperty($"{TableName}Id").GetValue(entity, null);
            var checkExistEntity = await CheckDuplicateBeforeUpdate((Guid)entityId, entity);
            if (checkExistEntity)
            {
                Console.WriteLine($"entityId {entityId} exist entity to update");
                var properties = typeof(Entity).GetProperties();
                var parameters = new DynamicParameters();
                var columnsName = string.Empty;
                foreach (var prop in properties)
                {
                    columnsName += $"{prop.Name} = @{prop.Name},";
                    parameters.Add($"@{prop.Name}", prop.GetValue(entity));
                    Console.WriteLine($"prop name {prop.Name}, prop value {prop.GetValue(entity)}, sqlvalue name {columnsName}");
                }
                columnsName = columnsName.Remove(columnsName.Length - 1);
                parameters.Add($"@{TableName}Id", entityId);
                var sql = $"UPDATE {TableName} SET {columnsName} WHERE {TableName}Id = @{TableName}Id";
                Console.WriteLine($"sql update {sql}");
                var result = await connection.ExecuteAsync(sql, parameters);
                return result > 0;
            }
            return false;
        }

        public async Task<bool> DeleteEntity(Guid entityId)
        {
            using (connection = new MySqlConnection(_connection_string))
            {
                var sql = $"DELETE FROM {TableName} WHERE {TableName}Id = @{TableName}Id";
                var parameters = new DynamicParameters();
                parameters.Add($"@{TableName}Id", entityId);
                var result = await connection.ExecuteAsync(sql, parameters);
                return result > 0;
            }
        }



        public async Task<bool> CheckDuplicate(string propName, object value)
        {
            using (var connection = new MySqlConnection(_connection_string))
            {
                var sql = $"SELECT * FROM {TableName} WHERE {propName} = @{propName}";
                var parameters = new DynamicParameters();
                parameters.Add($"@{propName}", value);
                var result = await connection.QueryFirstOrDefaultAsync<Entity>(sql, parameters);
                return result != null;
            }
        }
        public async Task<bool> CheckDuplicateBeforeUpdate(Guid entityId, Entity entity)
        {
            using (var connection = new MySqlConnection(_connection_string))
            {
                var properties = typeof(Entity).GetProperties();
                var parameters = new DynamicParameters();
                var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id = @{TableName}Id";
                parameters.Add($"@{TableName}Id", entityId);
                var result = await connection.QueryFirstOrDefaultAsync<Entity>(sql, parameters);
                return result != null;
            }
        }
        #endregion
    }

}
