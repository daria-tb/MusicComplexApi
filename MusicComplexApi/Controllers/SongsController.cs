using Microsoft.AspNetCore.Mvc;
using MusicComplexModels.Entities;
using MusicComplexServices.Interfaces;

namespace MusicComplexApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private readonly IGenericService<Song> _service;
    public SongsController(IGenericService<Song> service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => (await _service.GetByIdAsync(id)) is Song s ? Ok(s) : NotFound();
    [HttpPost] public async Task<IActionResult> Create([FromBody] Song song) { await _service.AddAsync(song); return CreatedAtAction(nameof(Get), new { id = song.Id }, song); }
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Song song) { if (id != song.Id) return BadRequest(); await _service.UpdateAsync(song); return NoContent(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.DeleteAsync(id); return NoContent(); }
}
