using System.Collections.Generic;
using TimeSheet.Common.Models;

namespace TimeSheet.Common.Data
{
    public class CustomerLibrary
    {
        public static List<CustomerModel> GetCustomers()
        {
            return new List<CustomerModel>
            {
                new CustomerModel { Name = "Acme", HourlyRate = 150 },
                new CustomerModel { Name = "ABC", HourlyRate = 125 }
            };
        }
    }
}
