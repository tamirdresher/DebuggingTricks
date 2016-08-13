using System;
using System.Collections.Concurrent;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading;
using OzCodeDemo.Invoices;

namespace OzCodeDemo
{
    [Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "ShowAllInstances")]
    class ShowAllInstancesDemo : IOzCodeDemo
    {
        readonly CustomerController _controller = new CustomerController();

        public void Start()
        {
            var invoiceService = new InvoiceService();

            var currCustomer = _controller.GetCurrentCustomer();
            
            invoiceService.SendInvoice(currCustomer);
            
            invoiceService.Shutdown();        
        }
    }


    public class InvoiceService
    {
        readonly BlockingCollection<int> _queue = new BlockingCollection<int>();

        readonly InvoiceSender _sender = new InvoiceSender();

        public InvoiceService()
        {
            new Thread(ProcessInvoiceRequests).Start();
        }

        public void SendInvoice(Customer customer) // <---- Use QuickAction Here.
        {
            _queue.Add(customer.PendingInvoiceID);
        }

        private void ProcessInvoiceRequests()
        {
            while (!_queue.IsCompleted)
            {
                try
                {
                    int pendingInvoiceID = _queue.Take();
                    _sender.SendInvoice(pendingInvoiceID);
                }
                catch (Exception e)
                {
                    // We got an exception while trying to send an invoice, 
                    // but can we figure out which customer the invoice is for?
                    // View the pendingInvoiceID, right click it, and choose 'Copy Value'.
                    // Then, put your caret on the word 'Customer' above, open the QuickAction menu, 
                    // and then search for the invoiceID you just Copied.   
                    Trace.WriteLine(e.Message);
                }

            }
        }

        public void Shutdown()
        {
            _queue.CompleteAdding();
        }
    }
}
