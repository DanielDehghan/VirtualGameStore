using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class MemberModelTests
    {
        [Fact]
        public void Member_Should_Have_Required_Fields()
        {
            // Arrange
            var member = new Member();

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("FirstName"));
            results.Should().Contain(r => r.MemberNames.Contains("LastName"));
            results.Should().Contain(r => r.MemberNames.Contains("Email"));
            results.Should().Contain(r => r.MemberNames.Contains("Password"));
        }

        [Theory]
        [InlineData("missing@domain")]
        [InlineData("missing@.com")]
        public void Invalid_Member_Email(string email)
        {
            // Arrange
            var member = new Member
            {
                FirstName = "John",
                LastName = "Doe",
                Email = email,
                Password = "Password123",
                Register_Date = DateTime.Now
            };

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Email"));
        }

        [Theory]
        [InlineData("1234")] // Too short
        [InlineData("12345678901234567890123456789012345678901234567890123456789012345")] // Too long

        public void Invalid_Member_Phone_Number(string phoneNumber)
        {
            // Arrange
            var member = new Member
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test@example.com",
                Password = "Password123",
                Phone_Number = phoneNumber,
                Register_Date = DateTime.Now
            };

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Phone_Number"));
        }


        [Fact]
        public void Invalid_Member_Register_Date()
        {
            // Arrange
            var member = new Member
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test@example.com",
                Password = "Password123",
                Register_Date = default // Invalid date (DateTime.MinValue)
            };

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Register_Date"));
        }

        [Fact]
        public void Member_With_Valid_Data()
        {
            // Arrange
            var member = new Member
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "Password123",
                Address = "123 Main St",
                Country = "Canada",
                City = "Toronto",
                Province = "Ontario",
                Postal_Code = "A1A1A1",
                Phone_Number = "1234567890",
                Register_Date = DateTime.Now
            };

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().BeEmpty();
        }


        private IList<ValidationResult> ValidateModel(Member member)
        {
            var context = new ValidationContext(member);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(member, context, results, validateAllProperties: true);
            return results;
        }


    }
}
