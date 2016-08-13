using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Customers;
using InvoiceSender.Invoices;

namespace InvoiceSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoiceService = new InvoiceService();

            foreach (var currCustomer in LoadPendingInvoiceCustomer())
            {
                invoiceService.SendInvoice(currCustomer);
            }

            Console.ReadLine();
            invoiceService.Shutdown();
        }

        public static IEnumerable<Customer> LoadPendingInvoiceCustomer()
        {
            var customers = CustomersRepository.LoadCustomersFromDb();
            var corruptCustomer = customers[5];

            corruptCustomer.EmailAddress = null;
            corruptCustomer.PendingInvoiceID = 915486;

            return customers;
        }
        
    }
}
