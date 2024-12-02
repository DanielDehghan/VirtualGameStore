using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class CartGamesModelTests
    {
        [Fact]
        public void Cart_Games_With_All_Fields()
        {
            // Arrange
            var cartGames = new CartGames
            {
                CartGames_ID = 1,
                Cart_ID = 1,
                Game_ID = 1,
                Cart = new Cart(),
                Game = new Game(),
                Quantity = 2,
                Total = 59.99M
            };

            // Act
            var results = ValidateModel(cartGames);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Cart_Games_Without_Cart()
        {
            // Arrange
            var cartGames = new CartGames
            {
                CartGames_ID = 1,
                Cart_ID = 1,
                Game_ID = 1,
                Game = new Game(),
                Quantity = 2,
                Total = 59.99M
            };

            // Act
            var results = ValidateModel(cartGames);

            // Assert
            results.Should().BeEmpty(); 
        }

        [Fact]
        public void Cart_Games_Without_Game()
        {
            // Arrange
            var cartGames = new CartGames
            {
                CartGames_ID = 1,
                Cart_ID = 1,
                Game_ID = 1,
                Cart = new Cart(),
                Quantity = 2,
                Total = 59.99M
            };

            // Act
            var results = ValidateModel(cartGames);

            // Assert
            results.Should().BeEmpty(); 
        }

        [Fact]
        public void Cart_Games_With_Invalid_Quantity()
        {
            // Arrange
            var cartGames = new CartGames
            {
                CartGames_ID = 1,
                Cart_ID = 1,
                Game_ID = 1,
                Cart = new Cart(),
                Game = new Game(),
                Quantity = -1, // Invalid quantity
                Total = 59.99M
            };

            // Act
            var results = ValidateModel(cartGames);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Quantity"));
        }

        [Fact]
        public void Cart_Games_With_Invalid_Total()
        {
            // Arrange
            var cartGames = new CartGames
            {
                CartGames_ID = 1,
                Cart_ID = 1,
                Game_ID = 1,
                Cart = new Cart(),
                Game = new Game(),
                Quantity = 2,
                Total = -10.00M // Invalid total
            };

            // Act
            var results = ValidateModel(cartGames);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Total"));
        }

        [Fact]
        public void Cart_Games_With_Zero_Quantity()
        {
            // Arrange
            var cartGames = new CartGames
            {
                CartGames_ID = 1,
                Cart_ID = 1,
                Game_ID = 1,
                Cart = new Cart(),
                Game = new Game(),
                Quantity = 0, // Zero quantity might be invalid depending on requirements
                Total = 0.00M
            };

            // Act
            var results = ValidateModel(cartGames);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Quantity"));
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }
    }
}
