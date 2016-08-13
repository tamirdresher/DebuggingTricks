using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OzCodeDemo.Invoices;

namespace OzCodeDemo {
	[Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "Predict")]
	public class PredictDemo : IOzCodeDemo {

        public void Start()
        {
           System.Diagnostics.Debugger.Break();
            var customers = CustomersRepository.LoadCustomers();

            foreach (var customer in customers)
            {
                switch (customer.Gender)
                {
                    case Gender.Male:
                        if (customer.Address.Country == "France" ||
                            customer.Address.Country == "Canada" ||
                            customer.GetYearlyEarnings(2014) > 10000 ||
                            customer.CCType == "Visa")
                        {
                            SendGift(customer);
                        }
                        else
                        {
                            SendThankYouLetter(customer);
                        }
                        break;
                    case Gender.Female:
                        SendGift(customer);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }






            if (customers.Any(c => c.CCType == "MasterKard") &&
                customers.All(c => c.EmailAddress == null))
            {
                SendBill(customers);
            }

        }





        private void SendThankYouLetter(Customer customer)
        {
            if (customer.Address.City == "Chicago")
            {
                SendThankYouLetterInternal(customer.Address);
            }
        }








        private void SendThankYouEmail()
        {
            // TODO, someday :)
        }

        private void SendThankYouLetterInternal(Address address)
        {
            // TODO, someday :)
        }

        private bool IsValidEmail(string emailAddress)
	    {
	        const string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
	                                         + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
	                                         + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

	        return new Regex(validEmailPattern, RegexOptions.IgnoreCase).IsMatch(emailAddress);
	    }
	


	    private void SendThankYouLetterInternal(string email)
        {
            // TODO :)
        }

        private void SendGift(Customer customer)
        {
            // TODO :)
        }
        private void SendBill(object customers)
        {
            // TODO :)
        }
        const int MAX_EMAIL_LENGTH = 250;
	}
}
