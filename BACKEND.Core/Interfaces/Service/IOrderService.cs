using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND.Core.Models;
namespace BACKEND.Core.Interfaces.Service
{
    public interface IOrderService
    {
        Task<ServiceResult> AddOrder(Order order);
        //     Task<ServiceResult> UpdateOrderItem(Order order);
        //     Task<ServiceResult> UpdateOrderStatus(int orderId, int status);
        //     Task<ServiceResult> GetOrdersByUserId(Guid userId);
        //     Task<ServiceResult> GetOrdersByStatus(int status);
        // }
    }
}