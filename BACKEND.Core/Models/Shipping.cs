using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.Core.Models
{
    public class Shipping : BaseEntity
    {
        #region Properties

        public Guid ShippingId { get; set; } //PK
        public Guid OrderId { get; set; } //FK
        public Order Order { get; set; }
        public string ShippingMethod { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public DateTime ShippingDate { get; set; }
        public string TrackingNumber { get; set; }

        #endregion
    }
}