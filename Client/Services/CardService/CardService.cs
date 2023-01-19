using System.Net.Http.Json;

namespace BlazorDeck.Client.Services.CardService;

public class CardService : ICardService
{
    private readonly HttpClient _http;

    public CardService(HttpClient http)
    {
        _http = http;
    }
    public List<Card> Cards { get; set; } = new List<Card>();
    public List<Deck> Decks { get; set; } = new List<Deck>();

    public Task GetDeck()
    {
        throw new NotImplementedException();
    }

    public Task<Card> GetSingleCard(int id)
    {
        throw new NotImplementedException();
    }
    public async Task GetCards()
    {
        var result = await _http.GetFromJsonAsync<List<Card>>("api/dealer");
        if(result != null) 
            Cards = result;
    }
}
