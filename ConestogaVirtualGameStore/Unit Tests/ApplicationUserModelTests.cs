using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class ApplicationUserModelTests
    {
        [Fact]
        public void ApplicationUser_With_Valid_Data()
        {
            // Arrange
            var applicationUser = new ApplicationUser
            {
                UserName = "testuser",  // IdentityUser requires this property to be set
                FirstName = "John",
                LastName = "Doe"
            };

            // Act
            var results = ValidateModel(applicationUser);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Invalid_FirstName()
        {
            // Arrange
            var applicationUser = new ApplicationUser
            {
                FirstName = string.Empty, // Invalid First Name
                LastName = "Doe"
            };

            // Act
            var results = ValidateModel(applicationUser);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("FirstName"));
        }

        [Fact]
        public void Invalid_LastName()
        {
            // Arrange
            var applicationUser = new ApplicationUser
            {
                FirstName = "John",
                LastName = string.Empty // Invalid Last Name
            };

            // Act
            var results = ValidateModel(applicationUser);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("LastName"));
        }

        [Fact]
        public void Invalid_FirstName_Max_Length()
        {
            // Arrange
            var applicationUser = new ApplicationUser
            {
                FirstName = new string('A', 101), // Invalid First Name size
                LastName = "Doe"
            };

            // Act
            var results = ValidateModel(applicationUser);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("FirstName"));
        }

        [Fact]
        public void Invalid_LastName_Max_Length()
        {
            // Arrange
            var applicationUser = new ApplicationUser
            {
                FirstName = "John",
                LastName = new string('A', 101) // Invalid Last Name size
            };

            // Act
            var results = ValidateModel(applicationUser);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("LastName"));
        }

        private IList<ValidationResult> ValidateModel(ApplicationUser applicationUser)
        {
            var context = new ValidationContext(applicationUser);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(applicationUser, context, results, validateAllProperties: true);
            return results;
        }
    }
}
