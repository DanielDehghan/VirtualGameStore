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
            var member = GetValidMember();
            member.Email = email;

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Email"));
        }

        [Theory]
        [InlineData("12345")] // Too short
        [InlineData("123456789012345678901234567890123456789012345678901234567890123456")] // Too long
        public void Invalid_Member_Phone_Number(string phoneNumber)
        {
            // Arrange
            var member = GetValidMember();
            member.Phone_Number = phoneNumber;

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("Phone_Number"));
        }

        [Fact]
        public void Invalid_Member_Register_Date()
        {
            // Arrange
            var member = GetValidMember();
            member.Register_Date = default; // Invalid date (DateTime.MinValue)

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Register_Date"));
        }

        [Theory]
        [InlineData("AAA 123")] // Invalid postal code format
        [InlineData("12345")]
        public void Invalid_Postal_Code(string postalCode)
        {
            // Arrange
            var member = GetValidMember();
            member.Postal_Code = postalCode;

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("Postal_Code"));
        }

        [Theory]
        [InlineData("2024-11-10")] // Future date
        [InlineData("1800-01-01")] // Too far in the past
        public void Invalid_DateOfBirth(string date)
        {
            // Arrange
            var member = GetValidMember();
            member.DateOfBirth = DateTime.Parse(date);

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("DateOfBirth"));
        }

        [Fact]
        public void Valid_Member_Data_Should_Pass_Validation()
        {
            // Arrange
            var member = GetValidMember();

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().BeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("This is a valid delivery instruction.")]
        public void Member_DeliveryInstruction_Should_Accept_Null_Or_Valid_Strings(string instruction)
        {
            // Arrange
            var member = GetValidMember();
            member.DeliveryInstruction = instruction;

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().BeEmpty();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Member_Should_Accept_ReceivePromotionalEmails_Boolean(bool receiveEmails)
        {
            // Arrange
            var member = GetValidMember();
            member.ReceivePromotionalEmails = receiveEmails;

            // Act
            var results = ValidateModel(member);

            // Assert
            results.Should().BeEmpty();
        }

        // Helper Method to create a valid Member instance
        private Member GetValidMember()
        {
            return new Member
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "Password123",
                PreferredLanguage = "English",
                PreferredPlatform = "PC",
                PreferredCategory = "RPG",
                ReceivePromotionalEmails = true,
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                Apt_suit = "100",
                StreetAddress = "123 Main St",
                City = "Toronto",
                Province = "Ontario",
                Country = "Canada",
                Postal_Code = "K1A 0B1",
                Phone_Number = "(123) 456-7890",
                DeliveryInstruction = "Leave at the front door",
                Register_Date = DateTime.Now
            };
        }

        // Private Helper Method for Model Validation
        private IList<ValidationResult> ValidateModel(Member member)
        {
            var context = new ValidationContext(member);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(member, context, results, validateAllProperties: true);
            return results;
        }
    }
}
