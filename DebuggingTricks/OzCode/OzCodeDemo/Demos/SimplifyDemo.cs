using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using OzCodeDemo.Invoices;

namespace OzCodeDemo
{
    [Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "Simplify")]
    public class SimplifyDemo : IOzCodeDemo
    {
        public void Start()
        {
            SendGiftsToCustomers();
        }









        private static void SendGiftsToCustomers()
        {
            foreach (var customer in GetPrizeWinners(prizesToGive: 10))
            {
                SendGift(customer);
            }
        }

        private static int SendGift(Customer customer)
        {
            var gift = GetSpecialGiftIfInStock() ?? GetRegularGift();

            int totalPrice = IsElgibileForDiscount(SupplierID) ? gift.GetRetailPrice() : gift.GetPriceAfterDiscount();

            int shippingCost;
            if (int.TryParse(GetShippingCostFromConfig(), out shippingCost))
            {
                totalPrice += shippingCost;
            }

            AddVAT(ref totalPrice);

            return totalPrice + GetExtraFreebiesCost(customer);
        }









        private static Gift GetSpecialGiftIfInStock()
        {
            return new Gift();
        }

        private static Gift GetRegularGift()
        {
            return null;
        }

        private static List<Customer> GetPrizeWinners(int prizesToGive)
        {
            var customers = CustomersRepository.LoadCustomers();

            var prizeWinners =
                customers
                  .Where(IsEligibleForPrize)
                  .Select(c => new
                  {
                      Customer = c,
                      Age = (int)(Today - c.Birthday).TotalDays % 365
                  })
                  .Where(c => c.Age < 70)
                  .Select(c => c.Customer)
                  .Take(10);

            if (prizeWinners.Count() != prizesToGive)
            {
                // How did we get here? :(
     //          System.Diagnostics.Debugger.Break();
                //throw new InvalidOperationException("There were not enough prize winners!");
            }

            return prizeWinners.ToList();
        }


        public static int SupplierID { get { return 23652; } }

        private static int GetExtraFreebiesCost(Customer customer)
        {
            return 52;
        }








        public static DateTime Today = DateTime.Now.Date;


        private static void SendGift(Customer customer, float price)
        {
            // TODO, never ;)

        }

        private static void AddVAT(ref int currentGiftPrice)
        {
            currentGiftPrice = Convert.ToInt32(currentGiftPrice * 1.18);
        }

        private static bool IsEligibleForPrize(Customer customer)
        {
            return customer.Gender == Gender.Female;
        }

        private static int GetDiscountPrice()
        {
            return 250;
        }

        private static int GetRegularPrice()
        {
            return 300;
        }

        private static bool IsElgibileForDiscount(int supplierId)
        {
            return false;
        }

        private static string GetShippingCostFromConfig()
        {
            return "21";
        }
    }
}