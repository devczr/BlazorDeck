using BlazorDeck.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDeck.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DealerController : ControllerBase
{
    public static List<Deck> decks = new List<Deck>
    {
        new Deck{ Id = 1, Name = "Quest" },
        new Deck{ Id = 2, Name = "Action" },
        new Deck{ Id = 3, Name = "Mind" },
        new Deck{ Id = 4, Name = "Heart" },
    };

    public static List<Card> cards = new List<Card>
    {
        new Card{
            Id = 1,
            Title = "Make App",
            Description = "Do something fun with mudblazor",
            Deck = decks[0],
            DeckId= 1
        },
        new Card{
            Id = 2,
            Title = "Program",
            Description = "Use GitHub, Visual Studio, all the tricks you know, and learn some new tricks!",
            Deck = decks[1],
            DeckId= 2
        }
    };

    [HttpGet]
    public async Task<ActionResult<List<Card>>> GetCards()
    {
        return Ok(cards);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Card>> GetSingleCard(int id)
    {
        var card = cards.FirstOrDefault(c => c.Id == id);
        if (card == null)
        {
            return NotFound("Sorry, no card found.");
        }
        return Ok(card);
    }

    [HttpGet("decks")]
    public async Task<ActionResult<Card>> GetDecks()
    {
        return Ok(decks);
    }

}
