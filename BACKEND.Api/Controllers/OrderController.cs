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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Fields
        IOrderService _orderService;
        #endregion

        #region Constructor
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion

        #region Methods
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            var result = await _orderService.AddOrder(order);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // [HttpPut]
        // [Route("UpdateOrderItem")]
        // public async Task<IActionResult> UpdateOrderItem(Order order)
        // {
        //     //
        // }

        // [HttpPut]
        // [Route("UpdateOrderStatus")]
        // public async Task<IActionResult> UpdateOrderStatus(int orderId, int status)
        // {
        //     //
        // }

        // [HttpGet]
        // [Route("GetOrdersByUserId")]
        // public async Task<IActionResult> GetOrdersByUserId(Guid userId)
        // {
        //     //
        // }

        // [HttpGet]
        // [Route("GetOrdersByStatus")]
        // public async Task<IActionResult> GetOrdersByStatus(int status)
        // {
        //     //
        // }
        #endregion
    }
}