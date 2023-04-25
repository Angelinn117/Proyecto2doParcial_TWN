using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Services;

public class CustomerAddressService : ICustomerAddressService
{
    
    private readonly ICustomerAddressRepository _customerAddressRepository;

    public CustomerAddressService(ICustomerAddressRepository customerAddressRepository)
    {
        _customerAddressRepository = customerAddressRepository;
    }
    
    public async Task<CustomerAddressDto> SaveAsync(CustomerAddressDto customerAddressDto)
    {
        var customerAddress = new CustomerAddress
        {
            
            calle = customerAddressDto.calle,
            colonia = customerAddressDto.colonia,
            numeroExterior = customerAddressDto.numeroExterior,
            numeroInterior = customerAddressDto.numeroInterior,
            
            CreatedBy = "",
            CreateDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
            
        };

        customerAddress = await _customerAddressRepository.SaveAsync(customerAddress);
        customerAddress.Id = customerAddress.Id;

        return customerAddressDto;
    }

    public async Task<CustomerAddressDto> UpdateAsync(CustomerAddressDto customerAddressDto)
    {
        var customerAddress = await _customerAddressRepository.GetById(customerAddressDto.Id);

        if (customerAddress == null)
            throw new Exception("Customer address Not Found");
        
        customerAddress.calle = customerAddressDto.calle;
        customerAddress.colonia = customerAddressDto.colonia;
        customerAddress.numeroExterior = customerAddressDto.numeroExterior;
        customerAddress.numeroInterior = customerAddressDto.numeroInterior;
            
        customerAddress.UpdatedBy = "";
        customerAddress.UpdateDate = DateTime.Now;

        await _customerAddressRepository.UpdateAsync(customerAddress);

        return customerAddressDto;
    }

    public async Task<List<CustomerAddressDto>> GetAllAsync()
    {
        var customerAddresss = await _customerAddressRepository.GetAllAsync();
        var customerAddressDto =
            customerAddresss.Select(c => new CustomerAddressDto(c)).ToList();
        return customerAddressDto;
        
    }

    public async Task<bool> CustomerAddressExist(int id)
    {
        var customerAddress = await _customerAddressRepository.GetById(id);
        return (customerAddress != null);
    }

    public async Task<CustomerAddressDto> GetById(int id)
    {
        var customerAddress = await _customerAddressRepository.GetById(id);
        if (customerAddress == null)
            throw new Exception("Customer address Not Found");
        var customerAddressDto = new CustomerAddressDto(customerAddress);
        return customerAddressDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _customerAddressRepository.DeleteAsync(id);
    }
    
}