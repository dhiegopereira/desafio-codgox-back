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

    /// <summary>
    /// Obtém um cliente pelo ID.
    /// </summary>
    /// <param name="id">ID do cliente.</param>
    /// <returns>Detalhes do cliente.</returns>
    [HttpGet("{id}")]
    [SwaggerResponse(200, "Cliente encontrado", typeof(CustomerListDto))]
    [SwaggerResponse(404, "Cliente não encontrado")]
    public async Task<ActionResult<CustomerListDto>> GetById(long id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        return Ok(customer);
    }

    /// <summary>
    /// Obtém todos os clientes.
    /// </summary>
    /// <returns>Lista de clientes.</returns>
    [HttpGet]
    [SwaggerResponse(200, "Lista de clientes", typeof(IEnumerable<CustomerListDto>))]
    public async Task<ActionResult<IEnumerable<CustomerListDto>>> GetAll()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(customers);
    }

    /// <summary>
    /// Adiciona um novo cliente.
    /// </summary>
    /// <param name="createUpdateUserDto">Dados do cliente a ser adicionado.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost]
    [SwaggerResponse(201, "Cliente adicionado com sucesso")]
    [SwaggerResponse(400, "Requisição inválida")]
    public async Task<IActionResult> Add([FromBody] CreateUpdateCustomerDto createUpdateUserDto)
    {
        await _customerService.AddAsync(createUpdateUserDto);
        return Created();
    }

    /// <summary>
    /// Atualiza os dados de um cliente.
    /// </summary>
    /// <param name="id">ID do cliente a ser atualizado.</param>
    /// <param name="createUpdateUserDto">Dados do cliente a ser atualizado.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPut("{id}")]
    [SwaggerResponse(204, "Cliente atualizado com sucesso")]
    [SwaggerResponse(400, "Requisição inválida")]
    [SwaggerResponse(404, "Cliente não encontrado")]
    public async Task<IActionResult> Update(long id, [FromBody] CreateUpdateCustomerDto createUpdateUserDto)
    {
        await _customerService.UpdateAsync(id, createUpdateUserDto);
        return NoContent();
    }

    /// <summary>
    /// Deleta um cliente pelo ID.
    /// </summary>
    /// <param name="id">ID do cliente a ser deletado.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpDelete("{id}")]
    [SwaggerResponse(204, "Cliente deletado com sucesso")]
    [SwaggerResponse(404, "Cliente não encontrado")]
    public async Task<IActionResult> Delete(long id)
    {
        await _customerService.DeleteAsync(id);
        return NoContent();
    }
}
