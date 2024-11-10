using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.ViewModels;

namespace ConestogaVirtualGameStore.Tests.ViewModels
{
    public class LoginViewModelTests
    {
        // Helper method to create a valid LoginViewModel instance
        private LoginViewModel GetValidLoginViewModel()
        {
            return new LoginViewModel
            {
                Email = "test@example.com",
                Password = "Password@123",
                RememberMe = false
            };
        }

        [Fact]
        public void Login_With_Valid_Data()
        {
            // Arrange
            var model = GetValidLoginViewModel();

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().BeEmpty();
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
            var model = GetValidLoginViewModel();
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
            var model = GetValidLoginViewModel();
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
        public void Missing_Password(string invalidPassword)
        {
            // Arrange
            var model = GetValidLoginViewModel();
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
            var model = GetValidLoginViewModel();
            model.Password = invalidPassword;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Password)) &&
                result.ErrorMessage.Contains("Password must contain"));
        }

        [Theory]
        [InlineData("P@ssw0rd")]
        [InlineData("Validpass123#")]
        public void Password_Length_Within_Range(string validPassword)
        {
            // Arrange
            var model = GetValidLoginViewModel();
            model.Password = validPassword;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [Theory]
        [InlineData("Short1@")]
        [InlineData("TooLongPasswordThatExceeds15Characters@")]
        public void Password_Length_Out_Of_Range(string invalidPassword)
        {
            // Arrange
            var model = GetValidLoginViewModel();
            model.Password = invalidPassword;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Password)) &&
                result.ErrorMessage.Contains("Password \"Password\" must have 8 characters") ||
                result.ErrorMessage.Contains("Password must contain: Minimum 8 characters, at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number, and 1 Special Character"));
        }

        [Fact]
        public void Remember_Me_Validation_When_Set()
        {
            // Arrange
            var model = GetValidLoginViewModel();
            model.RememberMe = true;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().BeEmpty();
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
