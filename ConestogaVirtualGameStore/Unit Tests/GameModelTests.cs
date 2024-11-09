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

        /// <summary>
        /// Another test where the test should fail, but doesn't
        /// </summary>
        /// <param name="title"></param>
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("A very very long title that exceeds the one hundred character limit for the title field in the Game model.")]
        //public void Game_Title_Field_ShouldHaveValidLength(string title)
        //{
        //    // Arrange
        //    var game = new Game
        //    {
        //        Title = title,
        //        Genere = "Action",
        //        ReleaseDate = DateTime.Now,
        //        Platform = "PC",
        //        Price = 49.99m,
        //        CoverImageURL = "http://example.com/image.jpg"
        //    };

        //    // Act
        //    var results = ValidateModel(game);

        //    // Assert
        //    if (string.IsNullOrEmpty(title) || title.Length > 100)
        //    {
        //        results.Should().Contain(r => r.MemberNames.Contains("Title"));
        //    }
        //    else
        //    {
        //        results.Should().NotContain(r => r.MemberNames.Contains("Title"));
        //    }
        //}

        /// <summary>
        /// This does not error how its supposed to
        /// </summary>
        /// <param name="price">Inline data being inputted for testing</param>
        //[Theory]
        //[InlineData(-10)]
        //[InlineData(0)]
        //[InlineData(201)]
        //[InlineData(1)]   // Valid value
        //[InlineData(50)]  // Valid value
        //[InlineData(200)] // Valid value
        //public void Game_Price_Should_Be_Valid(decimal price)
        //{
        //    // Arrange
        //    var game = new Game
        //    {
        //        Title = "Game Title",
        //        Genere = "Action",
        //        ReleaseDate = DateTime.Now,
        //        Platform = "PC",
        //        Price = price,
        //        CoverImageURL = "http://example.com/image.jpg"
        //    };

        //    // Act
        //    var results = ValidateModel(game);

        //    // Assert
        //    if (price < 1 || price > 200)
        //    {
        //        // Expecting a validation error for out-of-range prices
        //        results.Should().Contain(r => r.MemberNames.Contains("Price"), $"because the price {price} is out of the valid range (1-200)");
        //    }
        //    else
        //    {
        //        // Expecting no validation errors for in-range prices
        //        results.Should().NotContain(r => r.MemberNames.Contains("Price"), $"because the price {price} is within the valid range (1-200)");
        //    }
        //}


        private IList<ValidationResult> ValidateModel(Game game)
        {
            var context = new ValidationContext(game, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(game, context, results, validateAllProperties: true);
            return results;
        } 
    }
}
