using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class OrdersModelTests
    {
        [Fact]
        public void Order_With_All_Fields()
        {
            // Arrange
            var order = new Orders
            {
                Order_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                Status = "Completed",
                Games = new List<Game>
                {
                    new Game(),
                    new Game()
                },
                TotalPrice = 59.99M
            };

            // Act
            var results = ValidateModel(order);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Order_Without_Status()
        {
            // Arrange
            var order = new Orders
            {
                Order_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                Games = new List<Game>
                {
                    new Game(),
                    new Game()
                },
                TotalPrice = 59.99M
            };

            // Act
            var results = ValidateModel(order);

            // Assert
            results.Should().BeEmpty(); 
        }

        [Fact]
        public void Order_With_Invalid_Status()
        {
            // Arrange
            var order = new Orders
            {
                Order_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                Status = "InvalidStatus",
                Games = new List<Game>
                {
                    new Game(),
                    new Game()
                },
                TotalPrice = 59.99M
            };

            // Act
            var results = ValidateModel(order);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Status"));
        }

        [Fact]
        public void Order_Without_Games()
        {
            // Arrange
            var order = new Orders
            {
                Order_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                Status = "Pending",
                TotalPrice = 59.99M
            };

            // Act
            var results = ValidateModel(order);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Order_With_Zero_TotalPrice()
        {
            // Arrange
            var order = new Orders
            {
                Order_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                Status = "Pending",
                Games = new List<Game>
                {
                    new Game(),
                    new Game()
                },
                TotalPrice = 0.00M
            };

            // Act
            var results = ValidateModel(order);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("TotalPrice"));
        }

        [Fact]
        public void Order_With_Negative_TotalPrice()
        {
            // Arrange
            var order = new Orders
            {
                Order_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                Status = "Pending",
                Games = new List<Game>
                {
                    new Game(),
                    new Game()
                },
                TotalPrice = -10.00M
            };

            // Act
            var results = ValidateModel(order);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("TotalPrice"));
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
