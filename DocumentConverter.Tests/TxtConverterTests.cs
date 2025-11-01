using DocumentConverter.Core;
using Xunit;

namespace DocumentConverter.Tests
{
    public class TxtConverterTests
    {
        [Fact]
        public void Convert_ShouldAppendTxtConversionText()
        {
            // Arrange
            var converter = new TxtConverter();
            var content = "Test content";

            // Act
            var result = converter.Convert(content);

            // Assert
            Assert.Equal("Test content [Converted to TXT]", result);
        }

        [Fact]
        public void Convert_WithEmptyString_ShouldReturnOnlyConversionText()
        {
            // Arrange
            var converter = new TxtConverter();
            var content = "";

            // Act
            var result = converter.Convert(content);

            // Assert
            Assert.Equal(" [Converted to TXT]", result);
        }

        [Fact]
        public void TargetExtension_ShouldReturnTxt()
        {
            // Arrange
            var converter = new TxtConverter();

            // Act
            var extension = converter.TargetExtension;

            // Assert
            Assert.Equal(".txt", extension);
        }
    }
}
