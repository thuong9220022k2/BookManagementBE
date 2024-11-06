using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.Core.Interfaces.Infrastructure
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GetAllEntity();
        Task<Entity> GetEntityById(Guid entityId);
        Task<bool> AddEntity(Entity entity);
        Task<bool> UpdateEntity(Entity entity);
        Task<bool> DeleteEntity(Guid entityId);
        Task<bool> CheckDuplicate(string propName, object value);
        Task<bool> CheckDuplicateBeforeUpdate(Guid entityId, Entity entity);


    }
}