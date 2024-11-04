using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.Core.Models
{
    public class Category : BaseEntity
    {
        #region Properties

        public Guid CategoryId { get; set; } //PK
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion
    }
}