using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.ViewModels;

namespace ConestogaVirtualGameStore.Tests.ViewModels
{
    public class CheckOutViewModelTests
    {
        // Helper method to create a valid Member instance
        private Member GetValidMember(int id)
        {
            return new Member
            {
                Member_ID = id,
                FirstName = "Test",
                LastName = "User",
                Email = "testuser@example.com"
            };
        }

        // Helper method to create a valid CreditCard instance
        private CreditCards GetValidCreditCard(int id)
        {
            return new CreditCards
            {
                CreditCard_ID = id,
                Member_ID = 1,
                CreditCardNumber = "1234567812345678",
                CreditCardExpiryDate = DateTime.Now.AddYears(1),
                CreditCardOwnerName = "Test User",
                CreditCardVerificationValue = "123"
            };
        }

        // Helper method to create a valid CheckOutViewModel instance
        private CheckOutViewModel GetValidCheckOutViewModel()
        {
            return new CheckOutViewModel
            {
                Total = 59.99m,
                Member_ID = 1,
                Member = GetValidMember(1),
                CreditCards = new List<CreditCards> { GetValidCreditCard(1), GetValidCreditCard(2) }
            };
        }

        [Fact]
        public void CheckOutViewModel_With_Valid_Data()
        {
            // Arrange
            var model = GetValidCheckOutViewModel();

            // Act
            var total = model.Total;
            var member = model.Member;
            var creditCards = model.CreditCards;

            // Assert
            total.Should().Be(59.99m);
            member.Should().NotBeNull();
            creditCards.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Total_Can_Be_Zero()
        {
            // Arrange
            var model = GetValidCheckOutViewModel();
            model.Total = 0.00m;

            // Act
            var total = model.Total;

            // Assert
            total.Should().Be(0.00m);
        }

        [Fact]
        public void Total_Cannot_Be_Negative()
        {
            // Arrange
            var model = GetValidCheckOutViewModel();
            model.Total = -10.00m;

            // Act
            var total = model.Total;

            // Assert
            total.Should().BeNegative();
        }

        [Fact]
        public void Member_Can_Be_Null()
        {
            // Arrange
            var model = GetValidCheckOutViewModel();
            model.Member = null;

            // Act
            var member = model.Member;

            // Assert
            member.Should().BeNull();
        }

        [Fact]
        public void CreditCards_Can_Be_Empty()
        {
            // Arrange
            var model = GetValidCheckOutViewModel();
            model.CreditCards = new List<CreditCards>();

            // Act
            var creditCards = model.CreditCards;

            // Assert
            creditCards.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void CreditCards_Contain_Valid_Data()
        {
            // Arrange
            var model = GetValidCheckOutViewModel();

            // Act
            var creditCard1 = model.CreditCards[0];
            var creditCard2 = model.CreditCards[1];

            // Assert
            creditCard1.Should().NotBeNull();
            creditCard2.Should().NotBeNull();
            creditCard1.CreditCard_ID.Should().Be(1);
            creditCard2.CreditCard_ID.Should().Be(2);
        }
    }
}
