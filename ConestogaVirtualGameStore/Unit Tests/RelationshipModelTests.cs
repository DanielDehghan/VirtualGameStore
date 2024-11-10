using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class RelationshipModelTests
    {
        [Fact]
        public void Relationship_With_Valid_Data()
        {
            // Arrange
            var relationship = new Relationship
            {
                Relationship_Type = "Friendship"
            };

            // Act
            var results = ValidateModel(relationship);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Invalid_Relationship_Type()
        {
            // Arrange
            var relationship = new Relationship
            {
                Relationship_Type = string.Empty // Invalid Relationship_Type
            };

            // Act
            var results = ValidateModel(relationship);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Relationship_Type"));
        }

        [Fact]
        public void Invalid_Relationship_Type_As_Null()
        {
            // Arrange
            var relationship = new Relationship
            {
                Relationship_Type = null // Invalid Relationship_Type
            };

            // Act
            var results = ValidateModel(relationship);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Relationship_Type"));
        }

        private IList<ValidationResult> ValidateModel(Relationship relationship)
        {
            var context = new ValidationContext(relationship);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(relationship, context, results, validateAllProperties: true);
            return results;
        }
    }
}
