using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Unit_Tests
{
    public class ReviewModelTests
    {
        [Fact]
        public void Review_With_All_Fields()
        {
            // Arrange
            var review = new Review
            {
                Review_ID = 1,
                Game_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                ReviewTitle = "Great Game",
                ReviewDescription = "This is an amazing game. I had a lot of fun playing it.",
                ReviewRating = "5",
                Status = "Approved"
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Review_Without_ReviewTitle()
        {
            // Arrange
            var review = new Review
            {
                Review_ID = 1,
                Game_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                ReviewDescription = "This is an amazing game. I had a lot of fun playing it.",
                ReviewRating = "5",
                Status = "Approved"
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("ReviewTitle"));
        }

        [Fact]
        public void Review_Without_ReviewDescription()
        {
            // Arrange
            var review = new Review
            {
                Review_ID = 1,
                Game_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                ReviewTitle = "Great Game",
                ReviewRating = "5",
                Status = "Approved"
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("ReviewDescription"));
        }

        [Fact]
        public void Review_Without_ReviewRating()
        {
            // Arrange
            var review = new Review
            {
                Review_ID = 1,
                Game_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                ReviewTitle = "Great Game",
                ReviewDescription = "This is an amazing game. I had a lot of fun playing it.",
                Status = "Approved"
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("ReviewRating"));
        }

        [Fact]
        public void Review_Title_Exceeds_Max_Length()
        {
            // Arrange
            var review = new Review
            {
                Review_ID = 1,
                Game_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                ReviewTitle = new string('a', 256),
                ReviewDescription = "This is an amazing game.",
                ReviewRating = "5",
                Status = "Approved"
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("ReviewTitle"));
        }

        [Fact]
        public void Review_Description_Exceeds_Max_Length()
        {
            // Arrange
            var review = new Review
            {
                Review_ID = 1,
                Game_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                ReviewTitle = "Great Game",
                ReviewDescription = new string('a', 256),
                ReviewRating = "5",
                Status = "Approved"
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("ReviewDescription"));
        }

        [Fact]
        public void Review_With_Null_Status()
        {
            // Arrange
            var review = new Review
            {
                Review_ID = 1,
                Game_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                ReviewTitle = "Great Game",
                ReviewDescription = "This is an amazing game. I had a lot of fun playing it.",
                ReviewRating = "5",
                Status = null // Optional field
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public void Review_Rating_Is_Required()
        {
            // Arrange
            var review = new Review
            {
                Review_ID = 1,
                Game_ID = 1,
                Member_ID = 1,
                Member = new Member(),
                ReviewTitle = "Great Game",
                ReviewDescription = "This is an amazing game.",
                ReviewRating = null // Required field
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            results.Should().Contain(r => r.MemberNames.Contains("ReviewRating"));
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
