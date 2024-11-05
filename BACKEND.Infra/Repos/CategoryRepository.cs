using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using BACKEND.Core.Models;
using BACKEND.Core.Interfaces.Infrastructure;

namespace BACKEND.Infra.Repos
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        //

    }
}