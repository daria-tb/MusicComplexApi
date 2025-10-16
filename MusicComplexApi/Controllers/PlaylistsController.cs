using Microsoft.AspNetCore.Mvc;
using MusicComplexModels.Entities;
using MusicComplexServices.Interfaces;

namespace MusicComplexApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaylistsController : ControllerBase
{
    private readonly IGenericService<Playlist> _service;
    public PlaylistsController(IGenericService<Playlist> service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => (await _service.GetByIdAsync(id)) is Playlist p ? Ok(p) : NotFound();
    [HttpPost] public async Task<IActionResult> Create([FromBody] Playlist playlist) { await _service.AddAsync(playlist); return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist); }
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Playlist playlist) { if (id != playlist.Id) return BadRequest(); await _service.UpdateAsync(playlist); return NoContent(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.DeleteAsync(id); return NoContent(); }
}
