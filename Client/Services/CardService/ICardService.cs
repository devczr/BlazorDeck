namespace BlazorDeck.Client.Services.CardService;

public interface ICardService
{
    List<Card> Cards { get; set; }
    List<Deck> Decks { get; set; }
    Task GetCards();
    Task<Card> GetSingleCard(int id);
    Task GetDecks();
    Task CreateCard(Card card);
    Task UpdateCard(Card card);
    Task DeleteCard(int id);
}
