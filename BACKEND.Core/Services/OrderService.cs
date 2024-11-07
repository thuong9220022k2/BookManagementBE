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
    public class OrderService : IOrderService
    {
        #region Fields
        IOrderRepository _orderRepository;
        ServiceResult ServiceResult;
        #endregion

        #region Constructor
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion

        #region Methods
        public async Task<ServiceResult> AddOrder(Order order)
        {
            var result = await _orderRepository.AddOrder(order);
            if (result)
            {
                ServiceResult.IsSuccess = true;
            }
            else
            {
                ServiceResult.IsSuccess = false;
                ServiceResult.Message = Constants.ErrorCode.AddEntityError;
            }
            return ServiceResult;
        }

        // public async Task<ServiceResult> UpdateOrderItem(Order order)
        // {
        //     //
        // }

        // public async Task<ServiceResult> UpdateOrderStatus(int orderId, int status)
        // {
        //     //
        // }

        // public async Task<ServiceResult> GetOrdersByUserId(Guid userId)
        // {
        //     //
        // }

        // public async Task<ServiceResult> GetOrdersByStatus(int status)
        // {
        //     //
        // }

        #endregion

    }
}