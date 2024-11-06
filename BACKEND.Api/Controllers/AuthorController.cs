using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;
using BACKEND.Core.Models;
using BACKEND.Core.Interfaces.Infrastructure;
using BACKEND.Core.Interfaces.Service;

namespace BACKEND.Api.Controllers
{
    public class AuthorController : BaseEntityController<Author>
    {

        #region Constructor
        public AuthorController(IBaseService<Author> baseService) : base(baseService)
        {
        }
        #endregion
    }


}