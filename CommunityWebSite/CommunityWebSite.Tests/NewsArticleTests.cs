using CommunityWebSite.Models;
using System;
using Xunit;
namespace CommunityWebSite.Tests
{
    public class NewsArticleTests
    {
        [Fact]
        public void CanArchiveANewsArticle() {

            // Arrange 
            var n = new NewsArticle() {
                Title = "test",
                DatePublished = DateTime.Today,
                Article = "This is a test article",
                IsArchived = false
            };

            // Act
            n.IsArchived = true;

            // Assert
            Assert.Equal(true, n.IsArchived);
        }

        [Fact]
        public void CanTitleChange() {

            // Arrange 
            var n = new NewsArticle() {
                Title = "test",
                DatePublished = DateTime.Today,
                Article = "This is a test article",
                IsArchived = false
            };

            // Act
            n.Title = "Test change";

            // Assert
            Assert.Equal("Test change", n.Title);
        }

        [Fact]
        public void CanDatePublishedChange() {

            // Arrange 
            var n = new NewsArticle() {
                Title = "test",
                DatePublished = DateTime.Today,
                Article = "This is a test article",
                IsArchived = false
            };

            // Act
            n.DatePublished = new DateTime(2017, 1, 28);

            // Assert
            Assert.Equal(new DateTime(2017, 1, 28), n.DatePublished);
        }

        [Fact]
        public void CanArticleChange() {

            // Arrange 
            var n = new NewsArticle() {
                Title = "test",
                DatePublished = DateTime.Today,
                Article = "This is a test article",
                IsArchived = false
            };

            // Act
            n.Article = "The test article has been changed";

            // Assert
            Assert.Equal("The test article has been changed", n.Article);
        }


    }
}
