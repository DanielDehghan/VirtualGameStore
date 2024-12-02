using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class ReportModelTests
    {
        [Fact]
        public void Report_With_All_Fields()
        {
            // Arrange
            var report = new Report
            {
                Id = 1,
                Name = "Monthly Sales Report"
            };

            // Act
            var results = ValidateModel(report);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Report_Without_Name()
        {
            // Arrange
            var report = new Report
            {
                Id = 1
            };

            // Act
            var results = ValidateModel(report);

            // Assert
            results.Should().BeEmpty(); 
        }

        [Fact]
        public void Report_With_Empty_Name()
        {
            // Arrange
            var report = new Report
            {
                Id = 1,
                Name = string.Empty
            };

            // Act
            var results = ValidateModel(report);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Name"));
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
