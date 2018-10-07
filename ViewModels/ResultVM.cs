using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PGCare.ViewModels
{
    public class ResultVM
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode Status { get; set; }
        public string ErrorMessage { get; set; }
        public object ReturnData { get; set; }
    }
}
