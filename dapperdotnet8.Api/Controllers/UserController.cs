using dapperdotnet8.Domain.Entity;
using dapperdotnet8.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace dapperdotnet8.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var result = await userService.CreateUserAsync(user);
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetUserById), new { id = user.ID }, user);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar o usuário.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            if (user == null || user.ID != id)
            {
                return BadRequest();
            }

            var result = await userService.UpdateUserAsync(user);
            if (result > 0)
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar o usuário.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await userService.DeleteUserAsync(user);
            if (result > 0)
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar o usuário.");
        }
    }
}