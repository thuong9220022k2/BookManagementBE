using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACKEND.Core.Models;
using BACKEND.Core.Constants;
using BACKEND.Core.Enums;
using BACKEND.Core.Interfaces.Infrastructure;
using BACKEND.Core.Interfaces.Service;

namespace BACKEND.Core.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        #region Fields
        ICategoryRepository _categoryRepository;
        #endregion

        #region Constructor
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion
    }
}