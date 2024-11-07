using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND.Core.Models;
namespace BACKEND.Core.Interfaces.Infrastructure
{
    public interface IOrderRepository
    {
        //Task<IEnumerable<Order>> GetAllOrders();
        Task<bool> AddOrder(Order order);
        // Task<bool> UpdateOrderItem(Order order);
        // Task<bool> UpdateOrderStatus(int orderId, int status);
        // Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId);
        // Task<IEnumerable<Order>> GetOrdersByStatus(int status);
    }
}