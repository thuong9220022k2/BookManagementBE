using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Datetime OrderDate { get; set; }
        public Datetime DeliveryDate { get; set; }
        public OrderStatus Status { get; set; }

        #endregion
    }
}