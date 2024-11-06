using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BACKEND.Core.Models;
using BACKEND.Core.Interfaces.Infrastructure;
using BACKEND.Core.Interfaces.Service;

namespace BACKEND.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<Entity> : ControllerBase where Entity : class
    {
        #region Fields
        IBaseService<Entity> _baseService;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<Entity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetAllEntity()
        {
            try
            {
                var result = await _baseService.GetAllEntity();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResult(ex));
            }

        }

        [HttpGet("{entityId}")]
        public async Task<IActionResult> GetEntityById(Guid entityId)
        {
            try
            {
                var result = await _baseService.GetEntityById(entityId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResult(ex)); ;
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddEntity(Entity entity)
        {
            try
            {
                var result = await _baseService.AddEntity(entity);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResult(ex)); ;
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntity(Entity entity)
        {
            try
            {
                var result = await _baseService.UpdateEntity(entity);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResult(ex)); ;
            }

        }

        [HttpDelete("{entityId}")]
        public async Task<IActionResult> DeleteEntity(Guid entityId)
        {
            try
            {
                var result = await _baseService.DeleteEntity(entityId);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResult(ex)); ;
            }

        }
        #endregion

    }
}
