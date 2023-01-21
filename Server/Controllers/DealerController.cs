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

    //Add card
    [HttpPost]
    public async Task<ActionResult<List<Card>>> CreateCard(Card card)
    {
        card.Deck = null;

        _context.Cards.Add(card);
        await _context.SaveChangesAsync();

        return Ok(await GetDbCards());
    }

    //Update card
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Card>>> UpdateCard(Card card, int id)
    {
        var dbCard = await _context.Cards
            .Include(card => card.Deck)
            .FirstOrDefaultAsync(c => c.Id == id);
        if(dbCard == null)
            return NotFound("Sorry, card not found");

        dbCard.Title = card.Title;
        dbCard.Description = card.Description;
        dbCard.DeckId = card.DeckId;

        await _context.SaveChangesAsync();

        return Ok(await GetDbCards());
    }

    //Delete Card
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Card>>> DeleteCard(int id)
    {
        var dbCard = await _context.Cards
            .Include(card => card.Deck)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (dbCard == null)
            return NotFound("Sorry, card not found");

        _context.Cards.Remove(dbCard);
        await _context.SaveChangesAsync();

        return Ok(await GetDbCards());
    }



    private async Task<List<Card>> GetDbCards()
    {
        return await _context.Cards.Include(c => c.Deck).ToListAsync();
    }

}
