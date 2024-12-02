using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.ViewModels;

namespace ConestogaVirtualGameStore.Tests.ViewModels
{
    public class CreateCreditCardViewModelTests
    {
        // Helper method to create a valid CreateCreditCardViewModel instance
        private CreateCreditCardViewModel GetValidCreateCreditCardViewModel()
        {
            return new CreateCreditCardViewModel
            {
                CreditCart_ID = 1,
                Member_ID = 1,
                CreditCardNumber = "1234567812345678",
                CreditCardExpiryDate = DateTime.Now.AddYears(1),
                CreditCardOwnerName = "John Doe",
                CreditCardVerificationValue = "123"
            };
        }

        [Fact]
        public void CreateCreditCardViewModel_With_Valid_Data()
        {
            // Arrange
            var model = GetValidCreateCreditCardViewModel();

            // Act
            var results = ValidateModel(model);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void CreditCardNumber_Is_Required()
        {
            // Arrange
            var model = GetValidCreateCreditCardViewModel();
            model.CreditCardNumber = null;

            // Act
            var results = ValidateModel(model);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardNumber"));
        }

        [Fact]
        public void CreditCardNumber_Must_Be_16_Digits()
        {
            // Arrange
            var model = GetValidCreateCreditCardViewModel();
            model.CreditCardNumber = "12345678"; // Invalid length

            // Act
            var results = ValidateModel(model);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardNumber"));
        }

        [Fact]
        public void CreditCardNumber_Must_Contain_Only_Numbers()
        {
            // Arrange
            var model = GetValidCreateCreditCardViewModel();
            model.CreditCardNumber = "1234abcd5678abcd";

            // Act
            var results = ValidateModel(model);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardNumber"));
        }

        [Fact]
        public void CreditCardExpiryDate_Is_Required()
        {
            // Arrange
            var model = GetValidCreateCreditCardViewModel();
            model.CreditCardExpiryDate = null;

            // Act
            var results = ValidateModel(model);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardExpiryDate"));
        }

        [Fact]
        public void CreditCardOwnerName_Is_Required()
        {
            // Arrange
            var model = GetValidCreateCreditCardViewModel();
            model.CreditCardOwnerName = null;

            // Act
            var results = ValidateModel(model);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardOwnerName"));
        }

        [Fact]
        public void CreditCardVerificationValue_Is_Required()
        {
            // Arrange
            var model = GetValidCreateCreditCardViewModel();
            model.CreditCardVerificationValue = null;

            // Act
            var results = ValidateModel(model);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardVerificationValue"));
        }

        [Fact]
        public void CreditCardVerificationValue_Must_Be_3_Digits()
        {
            // Arrange
            var model = GetValidCreateCreditCardViewModel();
            model.CreditCardVerificationValue = "12"; // Invalid length

            // Act
            var results = ValidateModel(model);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardVerificationValue"));
        }

        [Fact]
        public void CreditCardVerificationValue_Must_Contain_Only_Numbers()
        {
            // Arrange
            var model = GetValidCreateCreditCardViewModel();
            model.CreditCardVerificationValue = "12a"; // Contains non-numeric characters

            // Act
            var results = ValidateModel(model);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardVerificationValue"));
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
