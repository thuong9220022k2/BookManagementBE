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
        Task<int> UpdateEntity(Entity entity);
        Task<int> DeleteEntity(Guid entityId);
        bool CheckDuplicate(string propName, object value);
        bool checkDuplicateBeforeUpdate(Guid id, string propName, Entity entity);


    }
}