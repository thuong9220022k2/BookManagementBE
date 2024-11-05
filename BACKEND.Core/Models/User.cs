using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND.Core.Enums;

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
        public Gender? Gender { get; set; }
        public string GenderName
        {
            get
            {
                switch (this.Gender)
                {
                    case Enums.Gender.Male:
                        return "Nam";
                    case Enums.Gender.Female:
                        return "Nữ";
                    case Enums.Gender.Other:
                        return "Khác";
                    default:
                        return null;
                }
            }
            set { }
        }
        public string Phone { get; set; }
        public DateTime DateJoined { get; set; }
        public Role? Role { get; set; }
        public string RoleName
        {
            get
            {
                switch (this.Role)
                {
                    case Enums.Role.Admin:
                        return "Admin";
                    case Enums.Role.User:
                        return "User";
                    default:
                        return null;
                }
            }
            set { }
        }
        public bool IsActive { get; set; }

        #endregion
    }
}