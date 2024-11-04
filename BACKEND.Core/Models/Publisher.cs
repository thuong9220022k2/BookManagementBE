using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.Core.Models
{
    public class Publisher : BaseEntity
    {
        #region Properties

        public Guid PublisherId { get; set; } //PK
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        #endregion
    }
}