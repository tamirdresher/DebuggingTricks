using System;
using System.Runtime.Serialization;

namespace InvoiceSender.Invoices
{
    [Serializable]
    public class InvoiceProcessingException : Exception
    {
        public InvoiceProcessingException()
        {
        }

        public InvoiceProcessingException(string message) : base(message)
        {
        }

        public InvoiceProcessingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvoiceProcessingException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}