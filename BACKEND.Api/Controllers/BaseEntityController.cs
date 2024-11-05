using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BACKEND.Core.Models;
using BACKEND.Core.Interface.Infrastructure;
using BACKEND.Core.Interface.Service;

namespace BACKEND.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<Entity> : ControllerBase where Entity : class
    {
        //
    }
}
