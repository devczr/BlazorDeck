using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorDeck.Client.Services.CardService;

public class CardService : ICardService
{
    private readonly HttpClient _http;

    private readonly NavigationManager _navigationManager;

    public CardService(HttpClient http, NavigationManager navigationManager)
    {
        _http = http;
        _navigationManager = navigationManager;

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

    public async Task CreateCard(Card card)
    {
        var result = await _http.PostAsJsonAsync("api/dealer", card);
        await SetCards(result);
    }

    public async Task UpdateCard(Card card)
    {
        var result = await _http.PutAsJsonAsync($"api/dealer/{card.Id}", card);
        await SetCards(result);
    }

    public async Task DeleteCard(int id)
    {
        var result = await _http.DeleteAsync($"api/dealer/{id}");
        await SetCards(result);
    }
    private async Task SetCards(HttpResponseMessage result)
    {
        var response = await result.Content.ReadFromJsonAsync<List<Card>>();
        //TODO: add null check
        Cards = response;
        _navigationManager.NavigateTo("cards");
    }
}
