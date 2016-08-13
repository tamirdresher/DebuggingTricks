using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Customers;
using Common.Orders;

namespace ExceptionTrail
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = CustomersRepository.LoadCustomersFromDb();

            var shippingService = new ShippingService("US");

            try
            {
                Parallel.ForEach(customers, customer =>
                {
                    var orders = OrderRepository.GetOrdersForCustomer(customer.Id);

                    var tasks = orders.Select(order => shippingService.SendOrder(customer, order)).ToArray();

                    Task.WaitAll(tasks);
                });
            }
            catch (Exception)
            {
                Debugger.Break();
            }
        }
    }
}
