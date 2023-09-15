using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class ResponseModel
    {
        public HttpStatusCode ResponseCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
