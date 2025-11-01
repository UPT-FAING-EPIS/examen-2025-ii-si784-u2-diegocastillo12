using DocumentConverter.Core;
using TechTalk.SpecFlow;
using Xunit;

namespace DocumentConverter.BDD.StepDefinitions
{
    [Binding]
    public class DocumentConversionStepDefinitions
    {
        private string _content = string.Empty;
        private string _result = string.Empty;
        private IDocumentConverter? _converter;
        private Exception? _exception;

        [Given(@"I have a document with content ""(.*)""")]
        public void GivenIHaveADocumentWithContent(string content)
        {
            _content = content;
        }

        [When(@"I convert it to ""(.*)"" format")]
        public void WhenIConvertItToFormat(string format)
        {
            _converter = DocumentConverterFactory.CreateDocumentConverter(format);
            _result = _converter.Convert(_content);
        }

        [When(@"I attempt to convert it to ""(.*)"" format")]
        public void WhenIAttemptToConvertItToFormat(string format)
        {
            try
            {
                _converter = DocumentConverterFactory.CreateDocumentConverter(format);
                _result = _converter.Convert(_content);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string expected)
        {
            Assert.Equal(expected, _result);
        }

        [Then(@"the target extension should be ""(.*)""")]
        public void ThenTheTargetExtensionShouldBe(string expectedExtension)
        {
            Assert.NotNull(_converter);
            Assert.Equal(expectedExtension, _converter.TargetExtension);
        }

        [Then(@"an ArgumentException should be thrown")]
        public void ThenAnArgumentExceptionShouldBeThrown()
        {
            Assert.NotNull(_exception);
            Assert.IsType<ArgumentException>(_exception);
        }

        [Then(@"the exception message should be ""(.*)""")]
        public void ThenTheExceptionMessageShouldBe(string expectedMessage)
        {
            Assert.NotNull(_exception);
            Assert.Equal(expectedMessage, _exception.Message);
        }
    }
}
