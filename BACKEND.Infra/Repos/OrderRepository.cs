using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using BACKEND.Core.Models;
using BACKEND.Core.Enums;
using BACKEND.Core.Interfaces.Infrastructure;

namespace BACKEND.Infra.Repos
{
    public class OrderRepository : IOrderRepository
    {
        #region Fields
        protected string TableName = "Order";
        string _connection_string = string.Empty;
        protected IDbConnection connection = null;

        #endregion

        #region Constructor
        public OrderRepository(IConfiguration configuration)
        {
            _connection_string = configuration.GetConnectionString("ConnectionString");
        }
        #endregion

        #region Methods
        public async Task<bool> AddOrder(Order order)
        {
            using (connection = new MySqlConnection(_connection_string))
            {
                // var addOrderSql = @"INSERT INTO Order VALUES(@OrderId,@UserId,@TotalAmount,@OrderDate, @DeliveryDate,@Status,@CreateDate,@UpdateDate);";
                var addOrderSql = @"INSERT INTO `Order` (OrderId, UserId, TotalAmount, OrderDate, DeliveryDate, Status , CreateAt, UpdateAt  ) VALUES (@OrderId, @UserId, @TotalAmount, @OrderDate, @DeliveryDate, @Status, @CreateAt, @UpdateAt);";
                var orderId = Guid.NewGuid();
                Console.WriteLine($"orderId {orderId}");
                var orderParameters = new DynamicParameters();
                orderParameters.Add("@OrderId", orderId);
                orderParameters.Add("@UserId", order.UserId);
                orderParameters.Add("@TotalAmount", order.TotalAmount);
                orderParameters.Add("@OrderDate", order.OrderDate);
                orderParameters.Add("@DeliveryDate", order.DeliveryDate);
                orderParameters.Add("@CreateAt", DateTime.Now);
                orderParameters.Add("@UpdateAt", DateTime.Now);
                orderParameters.Add("@Status", order.Status);
                Console.WriteLine($"orderParameters {addOrderSql}");
                var result = await connection.ExecuteAsync(addOrderSql, orderParameters);
                Console.WriteLine($"result {result}");
                if (result > 0)
                {
                    var addOrderItemSql = @"INSERT INTO `OrderItem` (OrderItemId,OrderId, BookId, Quantity, TotalPrice,CreateAt, UpdateAt)
                                            VALUES (@OderItemId,@OrderId, @BookId, @Quantity, @TotalPrice, @CreateAt, @UpdateAt);";
                    var iventorySql = @"UPDATE Iventory SET  Stock= Stock - @Quantity,TotalSold = TotalSold + @Quantity WHERE BookId = @BookId;";
                    foreach (var item in order.OrderItem)
                    {
                        var orderItemParameters = new DynamicParameters();
                        orderItemParameters.Add("@OrderId", orderId);
                        orderItemParameters.Add("@OderItemId", Guid.NewGuid());
                        orderItemParameters.Add("@BookId", item.BookId);
                        orderItemParameters.Add("@Quantity", item.Quantity);
                        orderItemParameters.Add("@TotalPrice", item.TotalPrice);
                        orderItemParameters.Add("@CreateAt", DateTime.Now);
                        orderItemParameters.Add("@UpdateAt", DateTime.Now);
                        var resultItem = await connection.ExecuteAsync(addOrderItemSql, orderItemParameters);
                        if (resultItem > 0)
                        {
                            var iventoryParameters = new DynamicParameters();
                            iventoryParameters.Add("@BookId", item.BookId);
                            iventoryParameters.Add("@Quantity", item.Quantity);
                            await connection.ExecuteAsync(iventorySql, iventoryParameters);
                        }
                    }
                    return true;

                    //Write shipping info to add data to database . in here have to wait for the shipping service to be completed
                }
                return false;

            }
        }
        // public async Task<bool> UpdateOrderItem(Order order)
        // {
        //     using (connection = new MySqlConnection(_connection_string))
        //     {
        //         //
        //     }
        // }

        // public async Task<bool> UpdateOrderStatus(int orderId, int status)
        // {
        //     using (connection = new MySqlConnection(_connection_string))
        //     {
        //         //
        //     }
        // }
        // public async Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId)
        // {
        //     using (connection = new MySqlConnection(_connection_string))
        //     {
        //         //
        //     }
        // }
        // public async Task<IEnumerable<Order>> GetOrdersByStatus(int status)
        // {
        //     using (connection = new MySqlConnection(_connection_string))
        //     {
        //         //
        //     }
        // }


        #endregion
    }
}