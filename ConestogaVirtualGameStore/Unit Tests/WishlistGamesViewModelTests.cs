using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.ViewModels;

namespace ConestogaVirtualGameStore.Tests.ViewModels
{
    public class WishlistGamesViewModelTests
    {
        // Helper method to create a valid Wishlist instance
        private Wishlist GetValidWishlist(int id)
        {
            return new Wishlist
            {
                Wishlist_ID = id,
                Wishlist_Name = "Test Wishlist",
                Member_ID = 1,
                Wishlist_Games = new List<Wishlist_Games>()
            };
        }

        // Helper method to create a valid Game instance
        private Game GetValidGame(int id)
        {
            return new Game
            {
                GameId = id,
                Title = "Test Game",
                Genere = "Action",
                ReleaseDate = DateTime.UtcNow,
                Description = "A test game description",
                Platform = "PC",
                Price = 59.99m,
                CoverImageURL = "http://example.com/game-cover.jpg",
                Wishlist_Games = new List<Wishlist_Games>()
            };
        }

        // Helper method to create a valid WishlistGamesViewModel instance
        private WishlistGamesViewModel GetValidWishlistGamesViewModel()
        {
            return new WishlistGamesViewModel
            {
                Wishlist = GetValidWishlist(1),
                Game = GetValidGame(1),
                GamesWishlist = new List<Game> { GetValidGame(1), GetValidGame(2) },
                Wishlists = new List<Wishlist> { GetValidWishlist(1), GetValidWishlist(2) },
                NewWishlistName = "New Wishlist Name"
            };
        }

        [Fact]
        public void Wishlist_Games_With_Valid_Data()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();

            // Act
            var wishlist = model.Wishlist;
            var game = model.Game;
            var gamesWishlist = model.GamesWishlist;
            var wishlists = model.Wishlists;

            // Assert
            wishlist.Should().NotBeNull();
            game.Should().NotBeNull();
            gamesWishlist.Should().NotBeNull().And.HaveCount(2);
            wishlists.Should().NotBeNull().And.HaveCount(2);
            model.NewWishlistName.Should().Be("New Wishlist Name");
        }

        [Fact]
        public void Wishlist_Can_Be_Null()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();
            model.Wishlist = null;

            // Act
            var wishlist = model.Wishlist;

            // Assert
            wishlist.Should().BeNull();
        }

        [Fact]
        public void Game_Can_Be_Null()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();
            model.Game = null;

            // Act
            var game = model.Game;

            // Assert
            game.Should().BeNull();
        }

        [Fact]
        public void Games_Wishlist_Can_Be_Empty()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();
            model.GamesWishlist = new List<Game>();

            // Act
            var gamesWishlist = model.GamesWishlist;

            // Assert
            gamesWishlist.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Wishlists_Can_Be_Empty()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();
            model.Wishlists = new List<Wishlist>();

            // Act
            var wishlists = model.Wishlists;

            // Assert
            wishlists.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void New_Wishlist_Name_Is_Required()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();
            model.NewWishlistName = null;

            // Act
            var newWishlistName = model.NewWishlistName;

            // Assert
            newWishlistName.Should().BeNull();
        }

        [Fact]
        public void New_Wishlist_Name_Max_Length()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();
            model.NewWishlistName = new string('a', 256); // Assuming the max length is 255

            // Act
            var newWishlistName = model.NewWishlistName;

            // Assert
            newWishlistName.Should().HaveLength(256);
        }

        [Fact]
        public void Valid_Wishlist_Name()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();
            model.Wishlist.Wishlist_Name = "Valid Wishlist Name";

            // Act
            var wishlistName = model.Wishlist.Wishlist_Name;

            // Assert
            wishlistName.Should().Be("Valid Wishlist Name");
        }

        [Fact]
        public void Wishlist_Contains_Valid_Data()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();

            // Act
            var wishlist = model.Wishlist;

            // Assert
            wishlist.Should().NotBeNull();
            wishlist.Wishlist_ID.Should().Be(1);
            wishlist.Wishlist_Name.Should().Be("Test Wishlist");
        }

        [Fact]
        public void Game_Contains_Valid_Data()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();

            // Act
            var game = model.Game;

            // Assert
            game.Should().NotBeNull();
            game.GameId.Should().Be(1);
            game.Title.Should().Be("Test Game");
            game.Genere.Should().Be("Action");
            game.ReleaseDate.Should().BeBefore(DateTime.UtcNow.AddSeconds(1));
            game.Description.Should().Be("A test game description");
            game.Platform.Should().Be("PC");
            game.Price.Should().Be(59.99m);
            game.CoverImageURL.Should().Be("http://example.com/game-cover.jpg");
        }

        [Fact]
        public void Games_Wishlist_Contains_Valid_Games()
        {
            // Arrange
            var model = GetValidWishlistGamesViewModel();

            // Act
            var game1 = model.GamesWishlist[0];
            var game2 = model.GamesWishlist[1];

            // Assert
            game1.Should().NotBeNull();
            game2.Should().NotBeNull();
            game1.GameId.Should().Be(1);
            game2.GameId.Should().Be(2);
        }
    }
}
