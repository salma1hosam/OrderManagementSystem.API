namespace Domain.Models.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        OrderConfirmed = 1,
        OrderFailed = 2,
		PaymentReceived = 3,
		PaymentFailed = 4
    }
}
