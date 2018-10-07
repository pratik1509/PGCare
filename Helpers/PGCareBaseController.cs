using Microsoft.AspNetCore.Mvc;
using PGCare.ViewModels;
using System.Net;

namespace PGCare.Helpers
{
    public class PGCareBaseController : Controller
    {
        public ResultVM Success(object data)
        {
            return new ResultVM {
                IsSuccess = true,
                Status = HttpStatusCode.OK,
                ReturnData = data
            };
        }

        public ResultVM Failure(HttpStatusCode errorCode, string errorMesssage)
        {
            return new ResultVM {
                IsSuccess = false,
                ErrorMessage = errorMesssage,
                Status = errorCode,
                ReturnData = null
            };
        }
    }
}
