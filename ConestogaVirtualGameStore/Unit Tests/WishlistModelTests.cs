using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class WishlistModelTests
    {
        [Fact]
        public void Wishlist_With_Valid_Data()
        {
            // Arrange
            var wishlist = new Wishlist
            {
                Wishlist_Name = "My Wishlist",
                Member_ID = 1
            };

            // Act
            var results = ValidateModel(wishlist);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Invalid_Member_ID()
        {
            // Arrange
            var wishlist = new Wishlist
            {
                Wishlist_Name = "My Wishlist",
                Member_ID = 0 // Invalid Member ID
            };

            // Act
            var results = ValidateModel(wishlist);

            // Assert
            results.Should().NotContain(r => r.MemberNames.Contains("Member_ID"));
        }

        private IList<ValidationResult> ValidateModel(Wishlist wishlist)
        {
            var context = new ValidationContext(wishlist);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(wishlist, context, results, validateAllProperties: true);
            return results;
        }
    }
}
