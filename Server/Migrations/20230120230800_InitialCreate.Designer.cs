﻿// <auto-generated />
using BlazorDeck.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorDeck.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230120230800_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorDeck.Shared.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeckId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeckId = 1,
                            Description = "Do something fun with mudblazor",
                            Title = "Make App"
                        },
                        new
                        {
                            Id = 2,
                            DeckId = 2,
                            Description = "Use GitHub, Visual Studio, all the tricks you know, and learn some new tricks!",
                            Title = "Program"
                        });
                });

            modelBuilder.Entity("BlazorDeck.Shared.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
