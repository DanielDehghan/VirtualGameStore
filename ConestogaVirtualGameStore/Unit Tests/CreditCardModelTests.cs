using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class CreditCardsModelTests
    {
        [Fact]
        public void Credit_Card_With_All_Fields()
        {
            // Arrange
            var creditCard = new CreditCards
            {
                CreditCard_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                CreditCardNumber = "1234567812345678",
                CreditCardExpiryDate = DateTime.Now.AddYears(1),
                CreditCardOwnerName = "John Doe",
                CreditCardVerificationValue = "123"
            };

            // Act
            var results = ValidateModel(creditCard);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Credit_Card_Without_Credit_Card_Number()
        {
            // Arrange
            var creditCard = new CreditCards
            {
                CreditCard_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                CreditCardExpiryDate = DateTime.Now.AddYears(1),
                CreditCardOwnerName = "John Doe",
                CreditCardVerificationValue = "123"
            };

            // Act
            var results = ValidateModel(creditCard);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardNumber"));
        }

        [Fact]
        public void Credit_Card_With_Invalid_Credit_Card_Number_Length()
        {
            // Arrange
            var creditCard = new CreditCards
            {
                CreditCard_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                CreditCardNumber = "12345", // Too short
                CreditCardExpiryDate = DateTime.Now.AddYears(1),
                CreditCardOwnerName = "John Doe",
                CreditCardVerificationValue = "123"
            };

            // Act
            var results = ValidateModel(creditCard);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardNumber"));
        }

        [Fact]
        public void Credit_Card_Without_Credit_Card_Expiry_Date()
        {
            // Arrange
            var creditCard = new CreditCards
            {
                CreditCard_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                CreditCardNumber = "1234567812345678",
                CreditCardOwnerName = "John Doe",
                CreditCardVerificationValue = "123"
            };

            // Act
            var results = ValidateModel(creditCard);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardExpiryDate"));
        }

        [Fact]
        public void Credit_Card_With_Expired_Credit_Card_Expiry_Date()
        {
            // Arrange
            var creditCard = new CreditCards
            {
                CreditCard_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                CreditCardNumber = "1234567812345678",
                CreditCardExpiryDate = DateTime.Now.AddMonths(-1), // Expired
                CreditCardOwnerName = "John Doe",
                CreditCardVerificationValue = "123"
            };

            // Act
            var results = ValidateModel(creditCard);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("CreditCardExpiryDate"));
        }

        [Fact]
        public void Credit_Card_Without_Credit_Card_Owner_Name()
        {
            // Arrange
            var creditCard = new CreditCards
            {
                CreditCard_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                CreditCardNumber = "1234567812345678",
                CreditCardExpiryDate = DateTime.Now.AddYears(1),
                CreditCardVerificationValue = "123"
            };

            // Act
            var results = ValidateModel(creditCard);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("CreditCardOwnerName"));
        }

        [Fact]
        public void Credit_Card_With_Invalid_CVV_Length()
        {
            // Arrange
            var creditCard = new CreditCards
            {
                CreditCard_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                CreditCardNumber = "1234567812345678",
                CreditCardExpiryDate = DateTime.Now.AddYears(1),
                CreditCardOwnerName = "John Doe",
                CreditCardVerificationValue = "12" // Too short
            };

            // Act
            var results = ValidateModel(creditCard);

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
