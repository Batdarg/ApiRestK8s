using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class IceCreamController : ControllerBase
{
    private readonly IceCreamDbContext _context;

    public IceCreamController(IceCreamDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IceCream>>> GetIceCreams()
    {
        return await _context.IceCream.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IceCream>> GetIceCream(int id)
    {
        var iceCream = await _context.IceCream.FindAsync(id);

        if (iceCream == null)
        {
            return NotFound();
        }

        return iceCream;
    }

    [HttpPost]
    public async Task<ActionResult<IceCream>> PostIceCream(IceCream iceCream)
    {
        _context.IceCream.Add(iceCream);
        await _context.SaveChangesAsync();

        Console.WriteLine("Nuevo Id generado: " + iceCream.Id);

        return CreatedAtAction("GetIceCream", new { id = iceCream.Id }, iceCream);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutIceCream(int id, IceCream iceCream)
    {
        if (id != iceCream.Id)
        {
            return BadRequest();
        }

        _context.Entry(iceCream).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IceCreamExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIceCream(int id)
    {
        var iceCream = await _context.IceCream.FindAsync(id);

        if (iceCream == null)
        {
            return NotFound();
        }

        _context.IceCream.Remove(iceCream);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool IceCreamExists(int id)
    {
        return _context.IceCream.Any(e => e.Id == id);
    }
}
