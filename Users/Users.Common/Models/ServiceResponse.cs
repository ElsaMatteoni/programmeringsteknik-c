using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Common.Models
{
    class ServiceResponse : IServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
