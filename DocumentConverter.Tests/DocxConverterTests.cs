using DocumentConverter.Core;
using Xunit;

namespace DocumentConverter.Tests
{
    public class DocxConverterTests
    {
        [Fact]
        public void Convert_ShouldAppendDocxConversionText()
        {
            // Arrange
            var converter = new DocxConverter();
            var content = "Test content";

            // Act
            var result = converter.Convert(content);

            // Assert
            Assert.Equal("Test content [Converted to DOCX]", result);
        }

        [Fact]
        public void Convert_WithEmptyString_ShouldReturnOnlyConversionText()
        {
            // Arrange
            var converter = new DocxConverter();
            var content = "";

            // Act
            var result = converter.Convert(content);

            // Assert
            Assert.Equal(" [Converted to DOCX]", result);
        }

        [Fact]
        public void TargetExtension_ShouldReturnDocx()
        {
            // Arrange
            var converter = new DocxConverter();

            // Act
            var extension = converter.TargetExtension;

            // Assert
            Assert.Equal(".docx", extension);
        }
    }
}
