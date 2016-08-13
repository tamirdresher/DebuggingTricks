using System;
using System.Diagnostics;

// ReSharper disable UnusedMethodReturnValue.Local
// ReSharper disable UnusedParameter.Local

namespace OzCodeDemo.Invoices
{
    internal class InvoiceSender
    {
        [DebuggerHidden]        
        public void SendInvoice(int pendingInvoiceID)
        {
            PrepareInvoiceDetails(pendingInvoiceID);
        }

        [DebuggerHidden]        
        private void PrepareInvoiceDetails(int pendingInvoiceID)
        {
            try
            {
                LoadInvoiceData(pendingInvoiceID);
            }
            catch (Exception e)
            {
                throw new InvoiceException("Failed to process invoice. Operation will be rolled back.", e);
            }
        }

        [DebuggerHidden]        
        private void LoadInvoiceData(int pendingInvoiceID)
        {
            try
            {
                CalculateInvoiceVAT(pendingInvoiceID);
                CalculateInterest();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(
                    string.Format("Cannot process request - Customer with InvoiceID '{0}' not in database. ",
                                  pendingInvoiceID), e);
            }
        }


        [DebuggerHidden]        
        private double CalculateInvoiceVAT(int pendingInvoiceID)
        {
            Invoice invoice = LoadInvoiceFromDB(pendingInvoiceID);
            return invoice.CalculateVAT();
        }


        private Invoice LoadInvoiceFromDB(int pendingInvoiceID)
        {
            return null;
        }

        private void CalculateInterest()
        {

        }
    }

    internal class InvoiceException : Exception
    {
        public InvoiceException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }

}
