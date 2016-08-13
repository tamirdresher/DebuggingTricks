using System.Collections.Generic;
using OzCodeDemo.Invoices;

namespace OzCodeDemo
{
    internal class CustomerController
    {
        private readonly List<Customer> _customers = new List<Customer>();

        public CustomerController()
        {
            _customers.AddRange(CustomersRepository.LoadCustomers());
            _customers.AddRange(CustomersRepository.LoadCustomers());
            _customers.AddRange(CustomersRepository.LoadCustomers());
        }

        public Customer GetCurrentCustomer()
        {            
            var corruptCustomer = _customers[5];
            corruptCustomer.PendingInvoiceID = 915486;
            return corruptCustomer;
        }
    }
}