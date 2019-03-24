using System;
using NUnit.Framework;
using StringConvertion.Domain.Enums;
using StringConvertion.Domain.Services;

namespace StringConvertion.UnitTests.Domain
{
    public class StringServiceTests
    {
        [Test]
        public void StringService_SortEmptyText_ShouldReturnExpectedResult()
        {
            // Arrange
            var text = string.Empty;
            var stringService = new StringService();

            // Act
            var result = stringService.GetSortedText(text, SortType.AlphabeticAsc);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(string.Empty, result[0]);
        }

        [Test]
        public void StringService_SortAlphabeticAsc_ShouldReturnExpectedResult()
        {
            // Arrange
            var text = "Hi- how are you?";
            var stringService = new StringService();

            // Act
            var result = stringService.GetSortedText(text, SortType.AlphabeticAsc);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("are", result[0]);
            Assert.AreEqual("Hi-", result[1]);
            Assert.AreEqual("how", result[2]);
            Assert.AreEqual("you?", result[3]);
        }

        [Test]
        public void StringService_SortAlphabeticDesc_ShouldReturnExpectedResult()
        {
            // Arrange
            var text = "Hi- how are you?";
            var stringService = new StringService();

            // Act
            var result = stringService.GetSortedText(text, SortType.AlphabeticDesc);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("you?", result[0]);
            Assert.AreEqual("how", result[1]);
            Assert.AreEqual("Hi-", result[2]);
            Assert.AreEqual("are", result[3]);
        }

        [Test]
        public void StringService_SortLengthAsc_ShouldReturnExpectedResult()
        {
            // Arrange
            var text = "Hi- how are you?";
            var stringService = new StringService();

            // Act
            var result = stringService.GetSortedText(text, SortType.LengthAsc);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("Hi-", result[0]);
            Assert.AreEqual("how", result[1]);
            Assert.AreEqual("are", result[2]);
            Assert.AreEqual("you?", result[3]);
        }

        [Test]
        public void StringService_GetTextStatistics_ShouldReturnExpectedResult()
        {
            // Arrange
            var text = "Hi- how are you?";
            var stringService = new StringService();

            // Act
            var result = stringService.GetTextStatistics(text);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.HyphensQuantity);
            Assert.AreEqual(4, result.WordsQuantity);
            Assert.AreEqual(3, result.SpacesQuantity);
        }

        [Test]
        public void StringService_GetEmptyTextStatistics_ShouldReturnExpectedResult()
        {
            // Arrange
            var text = string.Empty;
            var stringService = new StringService();

            // Act
            var result = stringService.GetTextStatistics(text);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(0, result.HyphensQuantity);
            Assert.AreEqual(1, result.WordsQuantity);
            Assert.AreEqual(0, result.SpacesQuantity);
        }
    }
}