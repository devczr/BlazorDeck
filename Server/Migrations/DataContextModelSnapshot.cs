// <auto-generated />
using System;
using BlazorDeck.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorDeck.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BlazorDeck.Server.Authentication.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "Test",
                            Role = "Administrator",
                            Username = "Test"
                        });
                });

            modelBuilder.Entity("BlazorDeck.Shared.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DeckId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeckId = 1,
                            Description = "Do something fun with mudblazor",
                            Guid = new Guid("4c855461-0fd9-4d8b-8491-f80d57ce1185"),
                            Status = "",
                            Title = "Make App",
                            Type = 3
                        },
                        new
                        {
                            Id = 2,
                            DeckId = 2,
                            Description = "Use GitHub, Visual Studio, all the tricks you know, and learn some new tricks!",
                            Guid = new Guid("743dc82e-ecd4-4a52-a0ab-ce7de91bd1f0"),
                            Status = "",
                            Title = "Program",
                            Type = 3
                        });
                });

            modelBuilder.Entity("BlazorDeck.Shared.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Decks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Quest"
                        },
                        new
                        {
                            Id = 2,
                            Name = "World"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mind"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Heart"
                        });
                });

            modelBuilder.Entity("BlazorDeck.Shared.Card", b =>
                {
                    b.HasOne("BlazorDeck.Shared.Deck", "Deck")
                        .WithMany()
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");
                });
#pragma warning restore 612, 618
        }
    }
}
