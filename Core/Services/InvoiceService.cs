using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repository.Contracts;
using Services.Abstractions;
using Shared.DataTransferObjects.InvoicDtos;

namespace Services
{
    public class InvoiceService(IUnitOfWork _unitOfWork , IMapper _mapper) : IInvoiceService
    {
        public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
        {
            var invoices = await _unitOfWork.InvoiceRepository.GetAllAsync();
            if (!invoices.Any()) throw new InvoiceNotFoundException("No Invoices Found");
            return _mapper.Map<IEnumerable<Invoice> , IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<InvoiceDetailsDto> GetInvoiceDetailsAsync(Guid invoiceId)
        {
            var invoice = await _unitOfWork.InvoiceRepository.GetInvoiceDetailsAsync(invoiceId) 
                ?? throw new InvoiceNotFoundException($"Invoice with id = {invoiceId} is Not Found");
            
            return _mapper.Map<Invoice , InvoiceDetailsDto>(invoice );
        }
    }
}
