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

    public async Task GetDecks()
    {
        var result = await _http.GetFromJsonAsync<List<Deck>>("api/dealer/decks");
        if (result != null)
            Decks = result;
    }

    public async Task<Card> GetSingleCard(int id)
    {
        var result = await _http.GetFromJsonAsync<Card>($"api/dealer/{id}");
        if (result != null)
            return result;
        throw new Exception("The dealer lost your card...");
    }
    public async Task GetCards()
    {
        var result = await _http.GetFromJsonAsync<List<Card>>("api/dealer");
        if(result != null) 
            Cards = result;
    }
}
