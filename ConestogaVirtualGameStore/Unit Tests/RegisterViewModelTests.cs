using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.ViewModels;

namespace ConestogaVirtualGameStore.Tests.ViewModels
{
    public class RegisterViewModelTests
    {
        // Helper method to create a valid RegisterViewModel instance
        private RegisterViewModel GetValidRegisterViewModel()
        {
            return new RegisterViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test@example.com",
                Password = "Password@123",
                ConfirmPassword = "Password@123"
            };
        }

        [Fact]
        public void Register_With_Valid_Data()
        {
            // Arrange
            var model = GetValidRegisterViewModel();

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FirstName_Is_Required(string firstName)
        {
            // Arrange
            var model = GetValidRegisterViewModel();
            model.FirstName = firstName;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.FirstName)) &&
                result.ErrorMessage.Contains("Please enter first name"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void LastName_Is_Required(string lastName)
        {
            // Arrange
            var model = GetValidRegisterViewModel();
            model.LastName = lastName;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.LastName)) &&
                result.ErrorMessage.Contains("Please enter last name"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("invalid-email")]
        [InlineData("user@@example.com")]
        [InlineData("user.com")]
        public void Invalid_Email_Format(string invalidEmail)
        {
            // Arrange
            var model = GetValidRegisterViewModel();
            model.Email = invalidEmail;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Email)) &&
                (result.ErrorMessage.Contains("Email is Invalid") || result.ErrorMessage.Contains("Email is invalid should contain @")));
        }

        [Fact]
        public void Missing_Email()
        {
            // Arrange
            var model = GetValidRegisterViewModel();
            model.Email = null;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Email)) &&
                result.ErrorMessage.Contains("Email is Invalid"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Password_Is_Required(string invalidPassword)
        {
            // Arrange
            var model = GetValidRegisterViewModel();
            model.Password = invalidPassword;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Password)) &&
                result.ErrorMessage.Contains("The Password field is required"));
        }

        [Theory]
        [InlineData("short")]
        [InlineData("NoNumber@Password")]
        [InlineData("NoSpecialCharacter123")]
        public void Invalid_Password_Format(string invalidPassword)
        {
            // Arrange
            var model = GetValidRegisterViewModel();
            model.Password = invalidPassword;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Password)) &&
                result.ErrorMessage.Contains("Password must contain"));
        }

        [Theory]
        [InlineData("Password@123", "Mismatch@123")]
        public void Confirm_Password_Does_Not_Match(string password, string confirmPassword)
        {
            // Arrange
            var model = GetValidRegisterViewModel();
            model.Password = password;
            model.ConfirmPassword = confirmPassword;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.ConfirmPassword)) &&
                result.ErrorMessage.Contains("Confirm password doesn't match, Type again!"));
        }

        [Fact]
        public void Missing_Confirm_Password()
        {
            // Arrange
            var model = GetValidRegisterViewModel();
            model.ConfirmPassword = null;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.ConfirmPassword)) &&
                result.ErrorMessage.Contains("Please enter confirm password"));
        }

        // Helper method to validate the model
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
