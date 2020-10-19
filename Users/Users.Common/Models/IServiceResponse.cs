using System;

namespace Users.Common.Models
{
    public interface IServiceResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
        Exception Exception { get; set; }
    }
}
