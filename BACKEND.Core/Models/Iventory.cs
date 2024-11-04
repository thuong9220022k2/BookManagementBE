using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.Core.Models
{
    public class Inventory : BaseEntity
    {
        #region Properties

        public Guid InventoryId { get; set; } //PK
        public Guid BookId { get; set; } //FK
        public Book Book { get; set; }
        public int Stock { get; set; }
        public int TotalSold { get; set; }

        #endregion
    }
}