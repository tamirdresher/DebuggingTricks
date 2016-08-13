using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using OzCodeDemo.Invoices;

// ReSharper disable AccessToModifiedClosure

namespace OzCodeDemo
{
    [Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "EnhancedTrace")]
    public class TraceDemoDemo : IOzCodeDemo
    {
        public void Start()
        {
            ProcessCustomerOrders(CustomersRepository.LoadCustomers());
        }
        
        private static void ProcessCustomerOrders(List<Customer> customers)
        {
           System.Diagnostics.Debugger.Break();

            Parallel.ForEach(customers, delegate(Customer customer)
            {
                SendPendingOrders(customer.Id);
            });

        }

        private static void SendPendingOrders(int customerID)
        {
            List<Order> orders = GetOrders(customerID);

            foreach (Order order in orders)
            {
                DateTime expectedDeliveryDate = EstimateDeliveryDate(order, customerID);

                SendOrder(order, expectedDeliveryDate);
            }
        }










        private static List<Order> GetOrders(int customerID)
        {
            return new List<Order>
                {
                    new Order() {Item = items[r.Next(5)], Quantity = r.Next(5), Destination = destinations[r.Next(5)]},
                    new Order() { Item = items[r.Next(5)] , Quantity = r.Next(5), Destination = destinations[r.Next(9)]}
                };
        }

        private static string[] items = new[] { "XBox One", "iPad", "LG G2", "PS4", "HTC1", "Nokia 1020" };
        private static string[] destinations = new[] { "Paris", "Tel Aviv", "Budapest", "London", "Helsinki", "Chicago", "Athens", "Berlin", "Istanbul", "Kharkiv", "Liverpool", "Lyon", "Madrid", "Leeds", "Munich", "Prague" };
        private static Random r = new Random();

        internal class Order
        {
            private static int _maxID;

            public Order()
            {
                ID = _maxID++;
            }

            public int ID { get; set; }

            public string Item { get; set; }

            public int Quantity { get; set; }

            public string Destination { get; set; }

        }

        static DateTime _beginning = DateTime.Now;
        private static DateTime EstimateDeliveryDate(Order order, int customerID)
        {
            _beginning = _beginning.AddDays(1);
            if (order.Destination == "Paris") return new DateTime(2020, r.Next(10) + 1, r.Next(10) + 1);
            return _beginning;
        }

        private static void SendOrder(Order order, DateTime expectedShipDate)
        {

        }
    }
}