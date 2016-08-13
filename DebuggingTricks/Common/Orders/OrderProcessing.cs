namespace Common.Orders
{
    public class OrderProcessing
    {
        private readonly ShippingService _shippingService;

        public OrderProcessing(ShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public void ShipOrder(OrderInfo orderInfo, Order order)
        {
            var reciever = OrderRepository.GetOrderReciever(orderInfo);

            if (reciever.Id != orderInfo.Customer.Id)
            {
                // Here the problem. instead of using the receiver object, the programmer changed the 
                // Customer property and used it later to send the order
                orderInfo.Customer = reciever; 
            }

            _shippingService.SendOrder(orderInfo.Customer, order).Wait();
        }
    }
}