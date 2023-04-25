using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<CustomerDto> SaveAsync(CustomerDto customerDto)
    {
        var customer = new Customer
        {
            FK_idDireccionCliente = customerDto.FK_idDireccionCliente,
            nombre = customerDto.nombre,
            telefono = customerDto.telefono,

            CreatedBy = "",
            CreateDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
            
        };

        customer = await _customerRepository.SaveAsync(customer);
        customer.Id = customer.Id;

        return customerDto;
    }

    public async Task<CustomerDto> UpdateAsync(CustomerDto customerDto)
    {
        var customer = await _customerRepository.GetById(customerDto.Id);

        if (customer == null)
            throw new Exception("Customer Not Found");

        customer.FK_idDireccionCliente = customerDto.FK_idDireccionCliente;
        customer.nombre = customerDto.nombre;
        customer.telefono = customerDto.telefono;

        customer.CreatedBy = "";
        customer.CreateDate = DateTime.Now;
        customer.UpdatedBy = "";
        customer.UpdateDate = DateTime.Now;

        customer.UpdatedBy = "";
        customer.UpdateDate = DateTime.Now;
        
        await _customerRepository.UpdateAsync(customer);

        return customerDto;
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        var customersDto =
            customers.Select(c => new CustomerDto(c)).ToList();
        return customersDto;
        
    }

    public async Task<bool> CustomerExist(int id)
    {
        var customer = await _customerRepository.GetById(id);
        return (customer != null);
    }

    public async Task<CustomerDto> GetById(int id)
    {
        var customer = await _customerRepository.GetById(id);
        if (customer == null)
            throw new Exception("Customer Not Found");
        var customerDto = new CustomerDto(customer);
        return customerDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _customerRepository.DeleteAsync(id);
    }
    
    
}