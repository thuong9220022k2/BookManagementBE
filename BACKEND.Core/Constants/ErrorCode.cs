using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Core.Constants
{

    public static class ErrorCode
    {
        public const string ExceptionErrorCode = "ERROR_001";
        public const string ValidateRequiredErrorCode = "ERROR_002";
        public const string ValidateUniqueErrorCode = "ERROR_003";
        public const string ValidateFormatErrorCode = "ERROR_004";
        public const string ValidateMaxLengthErrorCode = "ERROR_005";
        public const string QueryStringError = "ERROR_006";
        public const string RouteError = "ERROR_007";
    }
}
