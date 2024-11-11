using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConestogaVirtualGameStore.ViewModels;
using Xunit;
using FluentAssertions;

namespace ConestogaVirtualGameStore.Tests.ViewModels
{
    public class CreateEventViewModelTests
    {
        // Helper method to create a valid CreateEventViewModel instance
        private CreateEventViewModel GetValidCreateEventViewModel()
        {
            return new CreateEventViewModel
            {
                Name = "Test Event",
                Date = DateTime.Today,
                Address = "123 Test Street",
                Country = "Canada",
                City = "Toronto",
                SelectedProvince = "ON",
                PostalCode = "A1A 1A1",
                Description = "A test event description",
            };
        }

        [Fact]
        public void Create_Event_With_Valid_Data()
        {
            // Arrange
            var model = GetValidCreateEventViewModel();

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Missing_Name(string name)
        {
            // Arrange
            var model = GetValidCreateEventViewModel();
            model.Name = name;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Name)) &&
                result.ErrorMessage.Contains("Name is required"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Missing_Address(string address)
        {
            // Arrange
            var model = GetValidCreateEventViewModel();
            model.Address = address;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Address)) &&
                result.ErrorMessage.Contains("Address is required"));
        }

        [Theory]
        [InlineData("AAA 1A1")]
        [InlineData("123 456")]
        public void Invalid_PostalCode(string postalCode)
        {
            // Arrange
            var model = GetValidCreateEventViewModel();
            model.PostalCode = postalCode;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.PostalCode)) &&
                result.ErrorMessage.Contains("Postal code is not valid"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Missing_Country(string country)
        {
            // Arrange
            var model = GetValidCreateEventViewModel();
            model.Country = country;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Country)) &&
                result.ErrorMessage.Contains("Country is required"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Missing_City(string city)
        {
            // Arrange
            var model = GetValidCreateEventViewModel();
            model.City = city;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.City)) &&
                result.ErrorMessage.Contains("City is required"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Missing_Province(string selectedProvince)
        {
            // Arrange
            var model = GetValidCreateEventViewModel();
            model.SelectedProvince = selectedProvince;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.SelectedProvince)) &&
                result.ErrorMessage.Contains("Province is required"));
        }

        [Fact]
        public void Description_Exceeding_Max_Length()
        {
            // Arrange
            var model = GetValidCreateEventViewModel();
            model.Description = new string('a', 1001);

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            validationResults.Should().Contain(result =>
                result.MemberNames.Contains(nameof(model.Description)) &&
                result.ErrorMessage.Contains("The field Description must be a string with a maximum length of 1000."));
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
