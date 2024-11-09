using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Tests.Models
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

        public IList<ValidationResult> ValidateModel(object model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }
    }
}
