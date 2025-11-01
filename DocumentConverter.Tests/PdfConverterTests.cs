using DocumentConverter.Core;
using Xunit;

namespace DocumentConverter.Tests
{
    public class PdfConverterTests
    {
        [Fact]
        public void Convert_ShouldAppendPdfConversionText()
        {
            // Arrange
            var converter = new PdfConverter();
            var content = "Test content";

            // Act
            var result = converter.Convert(content);

            // Assert
            Assert.Equal("Test content [Converted to PDF]", result);
        }

        [Fact]
        public void Convert_WithEmptyString_ShouldReturnOnlyConversionText()
        {
            // Arrange
            var converter = new PdfConverter();
            var content = "";

            // Act
            var result = converter.Convert(content);

            // Assert
            Assert.Equal(" [Converted to PDF]", result);
        }

        [Fact]
        public void TargetExtension_ShouldReturnPdf()
        {
            // Arrange
            var converter = new PdfConverter();

            // Act
            var extension = converter.TargetExtension;

            // Assert
            Assert.Equal(".pdf", extension);
        }
    }
}
