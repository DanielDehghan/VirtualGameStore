using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.ViewModels;

namespace ConestogaVirtualGameStore.Tests.ViewModels
{
    public class RelationshipViewModelTests
    {
        // Helper method to create a valid Member instance
        private Member GetValidMember(int id)
        {
            return new Member
            {
                Member_ID = id,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "Password123!",
                PreferredLanguage = "English",
                PreferredPlatform = "PC",
                PreferredCategory = "RPG",
                ReceivePromotionalEmails = true,
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                Apt_suit = "100",
                StreetAddress = "123 Test Street",
                City = "Toronto",
                Province = "ON",
                Country = "Canada",
                Postal_Code = "A1A 1A1",
                Phone_Number = "123-456-7890",
                Register_Date = DateTime.UtcNow,
                MemberRelationshipPrimary = new List<MemberRelationship>(),
                MemberRelationshipRelated = new List<MemberRelationship>(),
                Wishlists = new List<Wishlist>()
            };
        }

        // Helper method to create a valid RelationshipViewModel instance
        private RelationshipViewModel GetValidRelationshipViewModel()
        {
            return new RelationshipViewModel
            {
                Members = new List<Member>
                {
                    GetValidMember(1),
                    GetValidMember(2)
                },
                Relationship = new Relationship
                {
                    Relationship_ID = 1,
                    Relationship_Type = "Friend",
                    MemberRelationship = new List<MemberRelationship>
                    {
                        new MemberRelationship { Member_ID = 1, Relationship_ID = 1 },
                        new MemberRelationship { Member_ID = 2, Relationship_ID = 1 }
                    }
                }
            };
        }

        [Fact]
        public void Relationship_With_Valid_Data()
        {
            // Arrange
            var model = GetValidRelationshipViewModel();

            // Act
            var members = model.Members;
            var relationship = model.Relationship;

            // Assert
            members.Should().NotBeNull().And.HaveCount(2);
            relationship.Should().NotBeNull();
            relationship.Relationship_Type.Should().Be("Friend");
            relationship.MemberRelationship.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Members_List_Can_Be_Empty()
        {
            // Arrange
            var model = GetValidRelationshipViewModel();
            model.Members = new List<Member>();

            // Act
            var members = model.Members;

            // Assert
            members.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Members_List_Set_To_Null_Should_Be_Empty()
        {
            // Arrange
            var model = new RelationshipViewModel { Members = null };

            // Act
            var members = model.Members ?? new List<Member>();

            // Assert
            members.Should().NotBeNull();
            members.Should().BeEmpty();
        }

        [Fact]
        public void Relationship_Can_Be_Null()
        {
            // Arrange
            var model = GetValidRelationshipViewModel();
            model.Relationship = null;

            // Act
            var relationship = model.Relationship;

            // Assert
            relationship.Should().BeNull();
        }

        [Fact]
        public void Relationship_Should_Have_Valid_Data()
        {
            // Arrange
            var model = GetValidRelationshipViewModel();

            // Act
            var relationship = model.Relationship;

            // Assert
            relationship.Should().NotBeNull();
            relationship.Relationship_ID.Should().Be(1);
            relationship.Relationship_Type.Should().Be("Friend");
        }

        [Fact]
        public void Relationship_Type_Is_Null_Or_Empty()
        {
            // Arrange
            var model = GetValidRelationshipViewModel();
            model.Relationship.Relationship_Type = null;

            // Act
            var relationshipType = model.Relationship.Relationship_Type;

            // Assert
            relationshipType.Should().BeNull();
        }

        [Fact]
        public void Member_Relationship_List_Can_Be_Empty()
        {
            // Arrange
            var model = GetValidRelationshipViewModel();
            model.Relationship.MemberRelationship = new List<MemberRelationship>();

            // Act
            var memberRelationships = model.Relationship.MemberRelationship;

            // Assert
            memberRelationships.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Member_Relationship_List_Set_As_Null_Should_Be_Empty()
        {
            // Arrange
            var model = GetValidRelationshipViewModel();
            model.Relationship.MemberRelationship = null;

            // Act
            var memberRelationships = model.Relationship.MemberRelationship ?? new List<MemberRelationship>();

            // Assert
            memberRelationships.Should().NotBeNull();
            memberRelationships.Should().BeEmpty();
        }

        [Fact]
        public void Members_Contains_Valid_Data()
        {
            // Arrange
            var model = GetValidRelationshipViewModel();

            // Act
            var firstMember = model.Members[0];

            // Assert
            firstMember.Should().NotBeNull();
            firstMember.FirstName.Should().Be("John");
            firstMember.Email.Should().Be("john.doe@example.com");
            firstMember.PreferredPlatform.Should().Be("PC");
            firstMember.PreferredCategory.Should().Be("RPG");
            firstMember.Register_Date.Should().BeBefore(DateTime.UtcNow.AddSeconds(1));
        }

        [Fact]
        public void Members_List_When_Empty_Should_Have_No_Data()
        {
            // Arrange
            var model = new RelationshipViewModel { Members = new List<Member>() };

            // Act
            var members = model.Members;

            // Assert
            members.Should().BeEmpty();
        }
    }
}
