namespace Shared.DataTransferObjects.OrderDtos
{
    public class OrderItemToReturnDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
