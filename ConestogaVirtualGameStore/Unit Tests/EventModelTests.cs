using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class EventModelTests
    {
        [Fact]
        public void Event_With_All_Fields()
        {
            // Arrange
            var eventObj = new Event
            {
                Name = "Sample Event",
                Description = "This is a sample event",
                Date = DateTime.Now,
                Address = "123 Event St",
                Country = "Canada",
                City = "Toronto",
                Province = "Ontario",
                PostalCode = "A1A1A1"
            };

            // Act
            var results = ValidateModel(eventObj);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Event_Without_Description()
        {
            // Arrange
            var eventObj = new Event
            {
                Name = "Sample Event",
                Date = DateTime.Now,
                Address = "123 Event St",
                Country = "Canada",
                City = "Toronto",
                Province = "Ontario",
                PostalCode = "A1A1A1"
            };

            // Act
            var results = ValidateModel(eventObj);

            // Assert
            results.Should().BeEmpty();
        }

        // write a test to check if the postal code is valid
        [Theory]
        [InlineData("A1A1A1")]
        [InlineData("A1A1")]
        [InlineData("A1A-1A1")]
        [InlineData("A1A-1A")]
        [InlineData("A1A 1A")]

        public void Event_With_Invalid_Postal_Code(string postalCode)
        {
            // Arrange
            var eventObj = new Event
            {
                Name = "Sample Event",
                Description = "This is a sample event",
                Date = DateTime.Now,
                Address = "123 Event St",
                Country = "Canada",
                City = "Toronto",
                Province = "Ontario",
                PostalCode = postalCode
            };

            // Act
            var results = ValidateModel(eventObj);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("PostalCode"));
        }

        public IList<ValidationResult> ValidateModel(object model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }
    }
}
