using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class CartModelTests
    {
        [Fact]
        public void Cart_With_All_Fields()
        {
            // Arrange
            var cart = new Cart
            {
                Cart_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                Date_Created = DateTime.Now,
                Cart_Games = new List<CartGames>
                {
                    new CartGames(),
                    new CartGames()
                }
            };

            // Act
            var results = ValidateModel(cart);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Cart_Without_Member()
        {
            // Arrange
            var cart = new Cart
            {
                Cart_ID = 1,
                Member_ID = 1,
                Date_Created = DateTime.Now,
                Cart_Games = new List<CartGames>()
            };

            // Act
            var results = ValidateModel(cart);

            // Assert
            results.Should().BeEmpty(); // Assuming `Member` is not required in your design.
        }

        [Fact]
        public void Cart_Without_Cart_Games()
        {
            // Arrange
            var cart = new Cart
            {
                Cart_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                Date_Created = DateTime.Now
            };

            // Act
            var results = ValidateModel(cart);

            // Assert
            results.Should().BeEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Cart_With_Invalid_Member_ID(int memberId)
        {
            // Arrange
            var cart = new Cart
            {
                Cart_ID = 1,
                Member_ID = memberId,
                Member = new Member(),
                Date_Created = DateTime.Now,
                Cart_Games = new List<CartGames>()
            };

            // Act
            var results = ValidateModel(cart);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Member_ID"));
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
