namespace Shared.DataTransferObjects.CustomerDtos
{
    public class CustomerOrderItemDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
