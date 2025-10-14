
using Microsoft.AspNetCore.Mvc;
using MusicComplexModels.Entities;
using MusicComplexServices.Interfaces;

namespace MusicComplexApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumsController : ControllerBase
{
    private readonly IGenericService<Album> _service;
    public AlbumsController(IGenericService<Album> service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => (await _service.GetByIdAsync(id)) is Album a ? Ok(a) : NotFound();
    [HttpPost] public async Task<IActionResult> Create([FromBody] Album album) { await _service.AddAsync(album); return CreatedAtAction(nameof(Get), new { id = album.Id }, album); }
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Album album) { if (id != album.Id) return BadRequest(); await _service.UpdateAsync(album); return NoContent(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.DeleteAsync(id); return NoContent(); }
}
