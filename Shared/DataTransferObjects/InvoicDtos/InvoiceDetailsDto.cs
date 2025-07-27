namespace Shared.DataTransferObjects.InvoicDtos
{
    public class InvoiceDetailsDto
    {
        public Guid OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<InvoiceOrderItemDto> OrderItems { get; set; } = [];
    }
}
