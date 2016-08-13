using System;
using Common.Customers;

namespace Common.Orders
{
    public interface IShippingCalculator
    {
        DateTime CalculateEta(string origin, Address destination);
    }
}