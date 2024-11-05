using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BACKEND.Core.Models;
using BACKEND.Core.Constants;
using BACKEND.Core.Enums;
using BACKEND.Core.Interfaces.Infrastructure;
using BACKEND.Core.Interfaces.Service;

namespace BACKEND.Core.Services
{
    public class BaseService<Entity> : IBaseService<Entity> where Entity : class
    {
        #region Fields
        IBaseRepository<Entity> _baseRepository;
        protected ServiceResult ServiceResult;

        #endregion

        #region Constructor
        public BaseService(IBaseRepository<Entity> baseRepository)
        {
            _baseRepository = baseRepository;
            ServiceResult = new ServiceResult();
        }
        #endregion

        public async Task<ServiceResult> GetAllEntity()
        {
            var entities = await _baseRepository.GetAllEntity();
            //print entities
            Console.WriteLine($"entities core {entities}");
            if (entities != null)
            {
                ServiceResult.Data = entities;
                ServiceResult.IsSuccess = true;

            }
            else
            {
                ServiceResult.IsSuccess = false;
                ServiceResult.Message = Constants.ErrorCode.EntityNotFound;
            }
            return ServiceResult;
        }

        public async Task<ServiceResult> GetEntityById(Guid entityId)
        {
            var entity = await _baseRepository.GetEntityById(entityId);
            if (entity != null)
            {
                ServiceResult.Data = entity;
                ServiceResult.IsSuccess = true;

            }
            else
            {
                ServiceResult.IsSuccess = false;
                ServiceResult.Message = Constants.ErrorCode.EntityNotFound;
            }
            return ServiceResult;
        }

    }
}