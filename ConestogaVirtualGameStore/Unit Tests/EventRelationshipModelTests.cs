using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class MemberRelationshipModelTests
    {
        [Fact]
        public void MemberRelationship_With_Valid_Data()
        {
            // Arrange
            var memberRelationship = new MemberRelationship
            {
                Member_ID = 1,
                Relationship_ID = 1,
                MemberAdded_ID = 2
            };

            // Act
            var results = ValidateModel(memberRelationship);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Invalid_Member_ID()
        {
            // Arrange
            var memberRelationship = new MemberRelationship
            {
                Member_ID = 0, // Invalid Member ID
                Relationship_ID = 1,
                MemberAdded_ID = 2
            };

            // Act
            var results = ValidateModel(memberRelationship);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Member_ID"));
        }

        [Fact]
        public void Invalid_Relationship_ID()
        {
            // Arrange
            var memberRelationship = new MemberRelationship
            {
                Member_ID = 1,
                Relationship_ID = 0, // Invalid Relationship ID
                MemberAdded_ID = 2
            };

            // Act
            var results = ValidateModel(memberRelationship);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Relationship_ID"));
        }

        [Fact]
        public void Invalid_MemberAdded_ID()
        {
            // Arrange
            var memberRelationship = new MemberRelationship
            {
                Member_ID = 1,
                Relationship_ID = 1,
                MemberAdded_ID = 0 // Invalid MemberAdded ID
            };

            // Act
            var results = ValidateModel(memberRelationship);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("MemberAdded_ID"));
        }

        private IList<ValidationResult> ValidateModel(MemberRelationship memberRelationship)
        {
            var context = new ValidationContext(memberRelationship);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(memberRelationship, context, results, validateAllProperties: true);
            return results;
        }
    }
}
