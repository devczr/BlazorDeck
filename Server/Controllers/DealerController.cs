using BlazorDeck.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDeck.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DealerController : ControllerBase
{
    private readonly DataContext _context;
    public DealerController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Card>>> GetCards()
    {
        var cards = await _context.Cards.ToListAsync();
        return Ok(cards);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Card>> GetSingleCard(int id)
    {
        var card = await _context.Cards
            .Include(c => c.Deck)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (card == null)
        {
            return NotFound("Sorry, no card found.");
        }
        return Ok(card);
    }

    [HttpGet("decks")]
    public async Task<ActionResult<Deck>> GetDecks()
    {
        var decks = await _context.Decks.ToListAsync();

        return Ok(decks);
    }

}
