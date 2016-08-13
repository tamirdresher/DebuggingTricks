using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Customers;

namespace PredictTheException
{
    class Program
    {
        const int MaxEmailLength = 250;

        static void Main(string[] args)
        {
            var customers = LoadCustomersFromDb();
            
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
        }

        
        private static List<Customer> LoadCustomersFromDb()
        {
            var customers = CustomersRepository.LoadCustomersFromDb();

            customers[5].Gender = Gender.Male;
            customers[5].CCType = "MasterCard";
            customers[5].Address.Country = "UK";
            customers[5].EmailAddress = null;

            return customers;
        }

        private static void SendThankYouLetterInternal(string email)
        {
            // TODO :)
        }

        private static void SendGift(Customer customer)
        {
            if (customer.Address.City == "Chicago")
            {
                SendThankYouLetterInternal(customer.EmailAddress);
            }
        }
        private static void SendThankYouLetter(Customer customer)
        {
            if (customer.EmailAddress.Length > MaxEmailLength)
            {
                SendThankYouLetterInternal(customer.EmailAddress);
            }
            else
            {
                Debug.Write("Email address too long!");
            }
        }

    }
}
