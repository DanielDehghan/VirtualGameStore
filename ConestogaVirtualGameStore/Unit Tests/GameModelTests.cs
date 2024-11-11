using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class GameModelTests
    {
        [Fact]
        public void Game_With_All_Required_Fields()
        {
            // Arrange
            var game = new Game
            {
                Title = "Test Game",
                Genere = "Action",
                ReleaseDate = DateTime.Now,
                Platform = "PC",
                Price = 19.99m,
                CoverImageURL = "http://example.com/cover.jpg"
            };

            // Act
            var results = ValidateModel(game);

            // Assert
            results.Should().BeEmpty();
        }

        [Theory]
        [InlineData(50)]
        [InlineData(1)]
        [InlineData(200)]
        public void Game_Price_Should_Be_Valid(decimal price)
        {
            // Arrange
            var game = new Game
            {
                Title = "Game Title",
                Genere = "Action",
                ReleaseDate = DateTime.Now,
                Platform = "PC",
                Price = price,
                CoverImageURL = "http://example.com/image.jpg"
            };

            // Act
            var results = ValidateModel(game);

            // Assert
            results.Should().BeEmpty();
        }


        private IList<ValidationResult> ValidateModel(Game game)
        {
            var context = new ValidationContext(game, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(game, context, results, validateAllProperties: true);
            return results;
        } 
    }
}
