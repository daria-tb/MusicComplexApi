using Microsoft.AspNetCore.Mvc;
using MusicComplexModels.Entities;
using MusicComplexServices.Interfaces;

namespace MusicComplexApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtistsController : ControllerBase
{
    private readonly IGenericService<Artist> _service;
    public ArtistsController(IGenericService<Artist> service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Artist artist)
    {
        await _service.AddAsync(artist);
        return CreatedAtAction(nameof(Get), new { id = artist.Id }, artist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Artist artist)
    {
        if (id != artist.Id) return BadRequest();
        await _service.UpdateAsync(artist);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
