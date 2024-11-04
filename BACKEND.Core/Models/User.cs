using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.Core.Models
{
    public class User : BaseEntity
    {
        #region Properties

        public Guid UserId { get; set; } //PK
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public Datetime DateJoined { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}