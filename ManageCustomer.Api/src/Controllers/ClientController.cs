using ManageCustomer.Application.DTOs;
using ManageCustomer.Application.Interfaces;
using ManageCustomer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ManageCustomer.Api;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerListDto>> GetById(long id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        return Ok(customer);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerListDto>>> GetAll()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(customers);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUpdateCustomerDto createUpdateUserDto)
    {
        await _customerService.AddAsync(createUpdateUserDto);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] CreateUpdateCustomerDto createUpdateUserDto)
    {
        await _customerService.UpdateAsync(id, createUpdateUserDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _customerService.DeleteAsync(id);
        return NoContent();
    }
}
