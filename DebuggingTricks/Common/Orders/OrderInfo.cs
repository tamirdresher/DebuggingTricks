using Common.Customers;

namespace Common.Orders
{
    public class OrderInfo
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }

        public OrderInfo(Order order, Customer customer)
        {
            Order = order;
            Customer = customer;
        }
    }
}