using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.Core.Models
{
    public class OrderItem : BaseEntity
    {
        #region Properties

        public Guid OrderItemId { get; set; } //PK
        public Guid OrderId { get; set; } //FK
        public Order Order { get; set; }
        public Guid BookId { get; set; } //FK
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        #endregion
    }
}