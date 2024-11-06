using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Tests.Models
{
    public class GameModelTests
    {
        [Fact]
        public void Game_With_Valid_Data()
        {
            // Arrange
            var game = new Game
            {
                GameId = 1,
                Title = "Valid Game Title",
                Genre = "Action",
                ReleaseDate = new DateTime(2022, 1, 1),
                Description = "A detailed description of the game.",
                Platform = "PC",
                Price = 59.99m,
                CoverImageURL = "http://example.com/image.jpg"
            };

            // Act
            var results = ValidateModel(game);

            // Assert
            results.Should().BeEmpty("because all fields are valid");
        }

        [Fact]
        public void Game_With_All_Required_Fields()
        {
            // Arrange
            var game = new Game
            {
                Title = "Test Game",
                Genre = "Action",
                ReleaseDate = DateTime.Now,
                Platform = "PC",
                Price = 19.99m,
                CoverImageURL = "http://example.com/cover.jpg"
            };

            // Act
            var results = ValidateModel(game);

            // Assert
            results.Should().BeEmpty("because all required fields are populated, so validation should pass");
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("A very very long title that exceeds the one hundred character limit for the title field in the Game model.")]
        public void Game_Title_Field_ShouldHaveValidLength(string title)
        {
            // Arrange
            var game = new Game
            {
                Title = title,
                Genre = "Action",
                ReleaseDate = DateTime.Now,
                Platform = "PC",
                Price = 49.99m,
                CoverImageURL = "http://example.com/image.jpg"
            };

            // Act
            var results = ValidateModel(game);

            // Assert
            if (string.IsNullOrEmpty(title) || title.Length > 100)
            {
                results.Should().Contain(r => r.MemberNames.Contains("Title"));
            }
            else
            {
                results.Should().NotContain(r => r.MemberNames.Contains("Title"));
            }
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(201)]
        public void Game_Price_ShouldBeInRange(decimal price)
        {
            // Arrange
            var game = new Game
            {
                Title = "Game Title",
                Genre = "Action",
                ReleaseDate = DateTime.Now,
                Platform = "PC",
                Price = price,
                CoverImageURL = "http://example.com/image.jpg"
            };

            // Act
            var results = ValidateModel(game);

            // Assert
            if (price < 1 || price > 200)
            {
                results.Should().Contain(r => r.MemberNames.Contains("Price"));
            }
            else
            {
                results.Should().NotContain(r => r.MemberNames.Contains("Price"));
            }
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
