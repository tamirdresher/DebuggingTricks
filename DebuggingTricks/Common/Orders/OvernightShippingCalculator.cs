using System;
using Common.Customers;

namespace Common.Orders
{
    internal class OvernightShippingCalculator : IShippingCalculator
    {
        public DateTime CalculateEta(string origin, Address destination)
        {
            return DateTime.Now.AddHours(12);
        }
    }
}