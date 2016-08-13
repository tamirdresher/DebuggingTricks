using System;
using System.Collections.Concurrent;
using System.Threading;
using Common.Customers;

namespace InvoiceSender.Invoices
{
    public class InvoiceService
    {
        private readonly BlockingCollection<PendingInvoice> _queue = new BlockingCollection<PendingInvoice>();

        readonly InvoiceSender _sender = new InvoiceSender();

        public InvoiceService()
        {
            new Thread(ProcessInvoiceRequests).Start();
            new Thread(ProcessInvoiceRequests).Start();
            new Thread(ProcessInvoiceRequests).Start();
            new Thread(ProcessInvoiceRequests).Start();
        }

        public void SendInvoice(Customer customer) // <---- Use QuickAction Here.
        {
            _queue.Add(new PendingInvoice(customer.EmailAddress, customer.PendingInvoiceID));
        }

        private void ProcessInvoiceRequests()
        {
            while (!_queue.IsCompleted)
            {
                try
                {
                    var invoiceDetails = _queue.Take();
                    invoiceDetails.ProcessingStartTime=DateTime.Now;
                    FinishProcessing(invoiceDetails);
                    _sender.SendInvoice(invoiceDetails);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception caught! "+Environment.NewLine +exp.Message);
                }

            }
        }

        private void FinishProcessing(PendingInvoice pendingInvoice)
        {
            pendingInvoice.ProcessingEndTime = DateTime.Now;
            pendingInvoice.IsValid = true;
            if (pendingInvoice.ProcessingStartTime.AddSeconds(1) < pendingInvoice.ProcessingEndTime)
            {
                // this invoice took too long to process, so i'm skipping it
                pendingInvoice.IsValid = false;
            }
        }

        public void Shutdown()
        {
            _queue.CompleteAdding();
        }
    }

    class PendingInvoice
    {
        public PendingInvoice(string email, int invoiceId)
        {
            Email = email;
            InvoiceId = invoiceId;
        }

        public string Email { get; set; }
        public int InvoiceId { get; set; }
        public DateTime ProcessingStartTime { get; set; }
        public DateTime ProcessingEndTime { get; set; }
        public bool IsValid { get; set; }
    }
}