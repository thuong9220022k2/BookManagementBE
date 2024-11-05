using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACKEND.Core.Constants;
namespace BACKEND.Core.Models
{
    public class ServiceResult
    {
        #region Properties
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public object Data { get; set; }
        public string ErrorCode { get; set; }

        #endregion

        #region Constructor
        public ServiceResult()
        {
        }

        public ServiceResult(Exception ex)
        {
            this.IsSuccess = false;
            this.Message = ex.Message;
            this.Data = null;
            this.ErrorCode = Constants.ErrorCode.ExceptionErrorCode;
        }

        #endregion

    }
}