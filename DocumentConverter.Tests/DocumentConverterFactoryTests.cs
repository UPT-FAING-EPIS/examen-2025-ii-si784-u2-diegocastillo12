using DocumentConverter.Core;
using Xunit;

namespace DocumentConverter.Tests
{
    public class DocumentConverterFactoryTests
    {
        [Theory]
        [InlineData("docx")]
        [InlineData("DOCX")]
        [InlineData("Docx")]
        public void CreateDocumentConverter_WithDocxFormat_ShouldReturnDocxConverter(string format)
        {
            // Act
            var converter = DocumentConverterFactory.CreateDocumentConverter(format);

            // Assert
            Assert.IsType<DocxConverter>(converter);
            Assert.Equal(".docx", converter.TargetExtension);
        }

        [Theory]
        [InlineData("pdf")]
        [InlineData("PDF")]
        [InlineData("Pdf")]
        public void CreateDocumentConverter_WithPdfFormat_ShouldReturnPdfConverter(string format)
        {
            // Act
            var converter = DocumentConverterFactory.CreateDocumentConverter(format);

            // Assert
            Assert.IsType<PdfConverter>(converter);
            Assert.Equal(".pdf", converter.TargetExtension);
        }

        [Theory]
        [InlineData("txt")]
        [InlineData("TXT")]
        [InlineData("Txt")]
        public void CreateDocumentConverter_WithTxtFormat_ShouldReturnTxtConverter(string format)
        {
            // Act
            var converter = DocumentConverterFactory.CreateDocumentConverter(format);

            // Assert
            Assert.IsType<TxtConverter>(converter);
            Assert.Equal(".txt", converter.TargetExtension);
        }

        [Theory]
        [InlineData("xml")]
        [InlineData("html")]
        [InlineData("json")]
        [InlineData("")]
        public void CreateDocumentConverter_WithUnsupportedFormat_ShouldThrowArgumentException(string format)
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => 
                DocumentConverterFactory.CreateDocumentConverter(format));
            Assert.Equal("Unsupported document format", exception.Message);
        }

        [Fact]
        public void CreateDocumentConverter_WithDocx_ShouldConvertCorrectly()
        {
            // Arrange
            var converter = DocumentConverterFactory.CreateDocumentConverter("docx");
            var content = "Sample text";

            // Act
            var result = converter.Convert(content);

            // Assert
            Assert.Equal("Sample text [Converted to DOCX]", result);
        }

        [Fact]
        public void CreateDocumentConverter_WithPdf_ShouldConvertCorrectly()
        {
            // Arrange
            var converter = DocumentConverterFactory.CreateDocumentConverter("pdf");
            var content = "Sample text";

            // Act
            var result = converter.Convert(content);

            // Assert
            Assert.Equal("Sample text [Converted to PDF]", result);
        }

        [Fact]
        public void CreateDocumentConverter_WithTxt_ShouldConvertCorrectly()
        {
            // Arrange
            var converter = DocumentConverterFactory.CreateDocumentConverter("txt");
            var content = "Sample text";

            // Act
            var result = converter.Convert(content);

            // Assert
            Assert.Equal("Sample text [Converted to TXT]", result);
        }
    }
}
