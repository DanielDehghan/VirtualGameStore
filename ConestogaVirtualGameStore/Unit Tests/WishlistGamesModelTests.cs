using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class WishlistGamesModelTests
    {
        [Fact]
        public void Wishlist_Games_With_Valid_Data()
        {
            // Arrange
            var wishlistGame = new Wishlist_Games
            {
                Wishlist_ID = 1,
                GameId = 1
            };

            // Act
            var results = ValidateModel(wishlistGame);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Invalid_Wishlist_ID()
        {
            // Arrange
            var wishlistGame = new Wishlist_Games
            {
                Wishlist_ID = 0, // Invalid Wishlist_ID
                GameId = 1
            };

            // Act
            var results = ValidateModel(wishlistGame);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Wishlist_ID"));
        }

        [Fact]
        public void Invalid_GameId()
        {
            // Arrange
            var wishlistGame = new Wishlist_Games
            {
                Wishlist_ID = 1,
                GameId = 0 // Invalid GameId
            };

            // Act
            var results = ValidateModel(wishlistGame);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("GameId"));
        }

        [Fact]
        public void Wishlist_and_Game_Should_Allow_Null()
        {
            // Arrange
            var wishlistGame = new Wishlist_Games
            {
                Wishlist = null, // Should be Valid
                Game = null // Should be Valid
            };

            // Act
            var results = ValidateModel(wishlistGame);

            // Assert
            results.Should().BeEmpty();
        }

        private IList<ValidationResult> ValidateModel(Wishlist_Games wishlistGame)
        {
            var context = new ValidationContext(wishlistGame);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(wishlistGame, context, results, validateAllProperties: true);
            return results;
        }
    }
}
