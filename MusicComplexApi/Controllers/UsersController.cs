using Microsoft.AspNetCore.Mvc;
using MusicComplexModels.Entities;
using MusicComplexServices.Interfaces;

namespace MusicComplexApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IGenericService<User> _service;
    public UsersController(IGenericService<User> service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => (await _service.GetByIdAsync(id)) is User u ? Ok(u) : NotFound();
    [HttpPost] public async Task<IActionResult> Create([FromBody] User user) { await _service.AddAsync(user); return CreatedAtAction(nameof(Get), new { id = user.Id }, user); }
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] User user) { if (id != user.Id) return BadRequest(); await _service.UpdateAsync(user); return NoContent(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.DeleteAsync(id); return NoContent(); }
}
