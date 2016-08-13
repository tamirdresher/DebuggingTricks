using System;
using System.Linq;
using Common;
using Common.Customers;
using Common.Orders;

namespace DataBreakpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            // Data breakpoints are not supported for non-native. 
            // OzCode "When Set" gives similar experience

            var customers = CustomersRepository.LoadCustomersFromDb()
                .Where(c => c.Address.Country == "US")
                .Take(20);

            foreach (var sender in customers)
            {
                var orders = OrderRepository.GetOrdersForCustomer(sender.Id);
                if (orders.Any())
                {
                    Logger.LogMessage("Start sending orders for customer: " + sender.Id);
                }

                foreach (var order in orders)
                {
                    ProcessOrder(order, sender);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, Logger.GetAllMessages()));
            Console.ReadLine();
        }

        private static void ProcessOrder(Order order, Customer sender)
        {
            var orderInfo = new OrderInfo(order, sender);

            var shippingService = new ShippingService("US");
            var orderProcessing = new OrderProcessing(shippingService);

            orderProcessing.ShipOrder(orderInfo, order);

            SendInvoice(orderInfo);
        }

        private static void SendInvoice(OrderInfo orderInfo)
        {
            BillingService billingService = new BillingService();

            billingService.SendInvoice(orderInfo);
        }
    }
}
