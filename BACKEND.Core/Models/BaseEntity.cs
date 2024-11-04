using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namsespace BACKEND.Core.Models
{
    public class BaseEntity
{
    #region Properties
    public Datetime CreatedAt { get; set; }
    public Datetime UpdatedAt { get; set; }
    #endregion
}
}