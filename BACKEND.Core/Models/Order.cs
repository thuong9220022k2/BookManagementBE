using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND.Core.Enums;
namespace BACKEND.Core.Models
{
    public class Order : BaseEntity
    {
        #region Properties

        public Guid OrderId { get; set; } //PK
        public Guid UserId { get; set; } //FK
        public User User { get; set; }
        public Guid BookId { get; set; } //FK
        public Book Book { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatus? Status { get; set; }
        public string StatusName
        {
            get
            {
                switch (this.Status)
                {
                    case Enums.OrderStatus.Pending:
                        return "Chờ xác nhận";
                    case Enums.OrderStatus.Processing:
                        return "Đã xác nhận";
                    case Enums.OrderStatus.Completed:
                        return "Đã nhận hàng";
                    case Enums.OrderStatus.Cancelled:
                        return "Đã hủy";
                    default:
                        return "";
                }
            }
        }

        #endregion
    }
}