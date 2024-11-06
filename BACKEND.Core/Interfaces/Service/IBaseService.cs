using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND.Core.Models;

namespace BACKEND.Core.Interfaces.Service
{
    public interface IBaseService<Entity> where Entity : class
    {
        Task<ServiceResult> GetAllEntity();
        Task<ServiceResult> GetEntityById(Guid entityId);
        Task<ServiceResult> AddEntity(Entity entity);
        Task<ServiceResult> UpdateEntity(Entity entity);
        Task<ServiceResult> DeleteEntity(Guid entityId);
    }
}