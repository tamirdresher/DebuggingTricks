using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Customers;

namespace ConditionalBreakpoint
{
    class Program
    {

        static void Main(string[] args)
        {
            PaymentValidation validation = new PaymentValidation();
            var allCustomers = CustomersRepository.LoadCustomersFromDb();

            IEnumerable<Customer> approvedCustomers = validation.Validate(allCustomers);

            //for some reason 'Robert Williams' didnt get his order
            SendOrders(approvedCustomers);

            Console.ReadLine();
        }

        private static void SendOrders(IEnumerable<Customer> approvedCustomers)
        {
            foreach (var customer in approvedCustomers)
            {
                Console.WriteLine(customer.FirstName + " " + customer.Surname);
            }
        }
    }
   
    
}
