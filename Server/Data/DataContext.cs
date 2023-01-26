namespace BlazorDeck.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deck>().HasData(
                new Deck { Id = 1, Name = "Quest" },
                new Deck { Id = 2, Name = "World" },
                new Deck { Id = 3, Name = "Mind" },
                new Deck { Id = 4, Name = "Heart" }
            );

        modelBuilder.Entity<Card>().HasData(
                new Card
                {
                    Id = 1,
                    Title = "Make App",
                    Description = "Do something fun with mudblazor",
                    DeckId = 1
                },
                new Card
                {
                    Id = 2,
                    Title = "Program",
                    Description = "Use GitHub, Visual Studio, all the tricks you know, and learn some new tricks!",
                    DeckId = 2
                }
            );
    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Deck> Decks { get; set; }

}

