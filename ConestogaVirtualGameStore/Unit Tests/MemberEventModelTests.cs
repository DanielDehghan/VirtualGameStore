using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class MemberEventModelTests
    {
        [Fact]
        public void MemberEvent_With_All_Required_Fields()
        {
            // Arrange
            var memberEvent = new MemberEvent
            {
                Event_ID = 1,
                Member_ID = 2
            };

            // Act
            var results = ValidateModel(memberEvent);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Invalid_MemberEvent_Event_Id()
        {
            // Arrange
            var memberEvent = new MemberEvent
            {
                Event_ID = 0, // Invalid Event ID
                Member_ID = 1
            };

            // Act
            var results = ValidateModel(memberEvent);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Event_ID"));
        }

        [Fact]
        public void Invalid_MemberEvent_Member_Id()
        {
            // Arrange
            var memberEvent = new MemberEvent
            {
                Event_ID = 1,
                Member_ID = 0 // Invalid Member ID
            };

            // Act
            var results = ValidateModel(memberEvent);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Member_ID"));
        }

        private IList<ValidationResult> ValidateModel(MemberEvent memberEvent)
        {
            var context = new ValidationContext(memberEvent);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(memberEvent, context, results, validateAllProperties: true);
            return results;
        }
    }
}
