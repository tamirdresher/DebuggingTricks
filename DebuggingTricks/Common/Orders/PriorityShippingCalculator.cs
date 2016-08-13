using System;
using Common.Customers;

namespace Common.Orders
{
    internal class PriorityShippingCalculator : IShippingCalculator
    {
        public DateTime CalculateEta(string origin, Address destination)
        {
            return DateTime.Now.AddDays(2);
        }
    }
}