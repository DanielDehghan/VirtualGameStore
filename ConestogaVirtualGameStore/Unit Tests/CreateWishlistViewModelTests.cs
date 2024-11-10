using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConestogaVirtualGameStore.ViewModels;
using Xunit;
using FluentAssertions;

namespace ConestogaVirtualGameStore.Tests.ViewModels
{
    public class CreateWishlistViewModelTests
    {
        // Helper method to create a valid CreateWishlistViewModel instance
        private CreateWishlistViewModel GetValidCreateWishlistViewModel()
        {
            return new CreateWishlistViewModel
            {
                Wishlist_ID = 1,
                Wishlist_Name = "My Wishlist",
                Member_ID = 1
            };
        }

        [Fact]
        public void Create_Wishlist_With_Valid_Data()
        {
            // Arrange
            var model = GetValidCreateWishlistViewModel();

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Missing_Wishlist_Name(string wishlistName)
        {
            // Arrange
            var model = GetValidCreateWishlistViewModel();
            model.Wishlist_Name = wishlistName;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Wishlist_Name)) &&
                result.ErrorMessage.Contains("Wishlist name is required"));
        }

        [Fact]
        public void Wishlist_Name_Exceeds_Max_Length()
        {
            // Arrange
            var model = GetValidCreateWishlistViewModel();
            model.Wishlist_Name = new string('A', 256); 

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Wishlist_Name)) &&
                result.ErrorMessage.Contains("The field Wishlist_Name must be a string with a maximum length of 255."));
        }

        [Fact]
        public void Set_Member_ID()
        {
            // Arrange
            var model = GetValidCreateWishlistViewModel();
            model.Member_ID = 5;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [Fact]
        public void Member_ID_Defaults_To_Zero()
        {
            // Arrange
            var model = GetValidCreateWishlistViewModel();
            model.Member_ID = 0;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().BeEmpty();
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
