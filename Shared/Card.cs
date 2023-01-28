namespace BlazorDeck.Shared;

public class Card
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CardType Type { get; set; }
    public Deck? Deck { get; set; }
    public int DeckId { get; set; }

}
