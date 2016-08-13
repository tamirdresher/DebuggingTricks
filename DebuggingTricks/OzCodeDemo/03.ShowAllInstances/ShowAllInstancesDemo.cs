using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using OzCodeDemo.DemoClasses;
using OzCodeDemo.DemoClasses.Customers;
using OzCodeDemo.DemoClasses.Invoices;

namespace OzCodeDemo._03.ShowAllInstances
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "ShowAllInstances")]
    public class ShowAllInstancesDemo : IOzCodeDemo
    {
        private readonly CustomerController _controller = new CustomerController();

        public void Start()
        {
            var invoiceService = new InvoiceService();

            foreach (var currCustomer in LoadPendingInvoiceCustomer())
            {
                invoiceService.SendInvoice(currCustomer);
            }
            
            invoiceService.Shutdown();
        }

        IEnumerable<Customer> LoadPendingInvoiceCustomer()
        {
            var customers = CustomersRepository.LoadCustomersFromDb();
            var corruptCustomer = customers[5];

            corruptCustomer.EmailAddress = null;
            corruptCustomer.PendingInvoiceID = 915486;

            return customers;
        }
    }
}
