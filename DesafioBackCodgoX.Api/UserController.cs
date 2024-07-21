using DesafioBackCodgoX.Application.DTOs;
using DesafioBackCodgoX.Application.Interfaces;
using DesafioBackCodgoX.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackCodgoX.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUpdateUserDto createUpdateUserDto)
        {
            await _userService.AddAsync(createUpdateUserDto);
            return Created();        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CreateUpdateUserDto createUpdateUserDto)
        {
            await _userService.UpdateAsync(id, createUpdateUserDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}