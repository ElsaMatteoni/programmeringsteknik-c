using System;
using TimeSheet.Common.Models;

namespace TimeSheet.Common
{
    public class PaymentProcessor
    {
        public static decimal CalculatePayment(PaymentModel model, int hours)
        {
            if (hours < model.HourLimit)
                throw new ArgumentException($"Hours '{hours}' are less than model.HourLimit '{model.HourLimit}'");

            return hours * model.HourlyRate;
        }
    }
}
