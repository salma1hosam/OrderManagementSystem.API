using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DataTransferObjects.InvoicDtos;

namespace Presentation.Controllers
{
    public class InvoicesController(IInvoiceService _invoiceService) : ApiBaseController
    {
        [HttpGet("{invoiceId:guid}")]
        public async Task<ActionResult<InvoiceDetailsDto>> GetInvoiceDetails(Guid invoiceId)
        {
            var result = await _invoiceService.GetInvoiceDetailsAsync(invoiceId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAllInvoices()
        {
            var result = await _invoiceService.GetAllInvoicesAsync();
            return Ok(result);
        }
    }
}
