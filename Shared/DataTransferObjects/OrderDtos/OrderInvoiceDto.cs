namespace Shared.DataTransferObjects.OrderDtos
{
    public class OrderInvoiceDto
    {
        public Guid InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
