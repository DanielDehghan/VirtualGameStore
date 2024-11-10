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
        private CreateEventViewModel GetValidViewModel()
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
        public void ValidModel_ShouldPassValidation()
        {
            // Arrange
            var model = GetValidViewModel();

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Empty(validationResults);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Name_IsRequired_ShouldFailValidation(string name)
        {
            // Arrange
            var model = GetValidViewModel();
            model.Name = name;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(model.Name)) &&
                                                    v.ErrorMessage == "Name is required");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Address_IsRequired_ShouldFailValidation(string address)
        {
            // Arrange
            var model = GetValidViewModel();
            model.Address = address;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(model.Address)) &&
                                                    v.ErrorMessage == "Address is required");
        }

        [Theory]
        [InlineData("AAA 1A1")]
        [InlineData("123 456")]
        public void PostalCode_InvalidFormat_ShouldFailValidation(string postalCode)
        {
            // Arrange
            var model = GetValidViewModel();
            model.PostalCode = postalCode;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(model.PostalCode)) &&
                                                    v.ErrorMessage == "Postal code is not valid");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Country_IsRequired_ShouldFailValidation(string country)
        {
            // Arrange
            var model = GetValidViewModel();
            model.Country = country;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(model.Country)) &&
                                                    v.ErrorMessage == "Country is required");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void City_IsRequired_ShouldFailValidation(string city)
        {
            // Arrange
            var model = GetValidViewModel();
            model.City = city;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(model.City)) &&
                                                    v.ErrorMessage == "City is required");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void SelectedProvince_IsRequired_ShouldFailValidation(string selectedProvince)
        {
            // Arrange
            var model = GetValidViewModel();
            model.SelectedProvince = selectedProvince;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(model.SelectedProvince)) &&
                                                    v.ErrorMessage == "Province is required");
        }

        [Fact]
        public void Description_ExceedsMaxLength_ShouldFailValidation()
        {
            // Arrange
            var model = GetValidViewModel();
            model.Description = new string('a', 1001);

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(model.Description)) &&
                                                    v.ErrorMessage.Contains("The field Description must be a string with a maximum length of 1000."));
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
