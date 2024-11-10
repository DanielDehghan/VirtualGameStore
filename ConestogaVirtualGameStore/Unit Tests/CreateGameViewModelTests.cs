using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConestogaVirtualGameStore.ViewModels;

namespace ConestogaVirtualGameStore.Tests.ViewModels
{
    public class CreateGameViewModelTests
    {
        // Helper method to create a valid CreateGameViewModel instance
        private CreateGameViewModel GetValidCreateGameViewModel()
        {
            return new CreateGameViewModel
            {
                GameId = 1,
                Title = "Sample Game",
                SelectedGenere = "Action",
                ReleaseDate = DateTime.Now,
                Description = "This is a sample game description",
                SelectedPlatform = "PC",
                Price = 59.99m,
                CoverImageURL = "https://example.com/sample.jpg"
            };
        }
        
        [Fact]
        public void Create_Game_With_Valid_Data()
        {
            // Arrange
            var model = GetValidCreateGameViewModel();

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [Fact]
        public void Missing_Title()
        {
            // Arrange
            var model = GetValidCreateGameViewModel();
            model.Title = null;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Title)) &&
                result.ErrorMessage.Contains("Title is required"));
        }

        [Fact]
        public void Title_Exceeds_Max_Length()
        {
            // Arrange
            var model = GetValidCreateGameViewModel();
            model.Title = new string('A', 101); 

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Title)) &&
                result.ErrorMessage.Contains("The field Title must be a string with a maximum length of 100."));
        }

        [Fact]
        public void Missing_Genere()
        {
            // Arrange
            var model = GetValidCreateGameViewModel();
            model.SelectedGenere = null;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.SelectedGenere)) &&
                result.ErrorMessage.Contains("Genere is required"));
        }

        [Fact]
        public void Missing_Platform()
        {
            // Arrange
            var model = GetValidCreateGameViewModel();
            model.SelectedPlatform = null;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.SelectedPlatform)) &&
                result.ErrorMessage.Contains("Platform is required"));
        }

        [Theory]
        [InlineData(0.00)]
        [InlineData(1000.00)]
        public void Price_Out_Of_Range(decimal invalidPrice)
        {
            // Arrange
            var model = GetValidCreateGameViewModel();
            model.Price = invalidPrice;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Price)) &&
                result.ErrorMessage.Contains("Price must be between 0.01 and 999.99"));
        }

        [Fact]
        public void Missing_Cover_Image_URL()
        {
            // Arrange
            var model = GetValidCreateGameViewModel();
            model.CoverImageURL = null;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.CoverImageURL)) &&
                result.ErrorMessage.Contains("Cover Image URL is required"));
        }

        [Theory]
        [InlineData("invalid-url")]
        [InlineData("www.example.com")]
        public void Invalid_Cover_Image_URL_Format(string invalidUrl)
        {
            // Arrange
            var model = GetValidCreateGameViewModel();
            model.CoverImageURL = invalidUrl;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.CoverImageURL)) &&
                result.ErrorMessage.Contains("Invalid URL format"));
        }

        [Fact]
        public void Description_Exceeds_Max_Length()
        {
            // Arrange
            var model = GetValidCreateGameViewModel();
            model.Description = new string('A', 2001); // Exceeds max length of 2000

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Description)) &&
                result.ErrorMessage.Contains("The field Description must be a string with a maximum length of 2000."));
        }

        // Helper method to validate the model
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);
            return validationResults;
        }
    }
}
