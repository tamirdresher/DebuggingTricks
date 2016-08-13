﻿using System.Collections.Generic;

namespace Common.Customers
{
    internal class CustomerController
    {
        private readonly List<Customer> _customers = new List<Customer>();

        public CustomerController()
        {
            _customers.AddRange(CustomersRepository.LoadCustomersFromDb());
            _customers.AddRange(CustomersRepository.LoadCustomersFromDb());
            _customers.AddRange(CustomersRepository.LoadCustomersFromDb());
        }

        public Customer GetCurrentCustomer()
        {
            var corruptCustomer = _customers[5];

            corruptCustomer.EmailAddress = null;
            corruptCustomer.PendingInvoiceID = 915486;

            return corruptCustomer;
        }
    }
}