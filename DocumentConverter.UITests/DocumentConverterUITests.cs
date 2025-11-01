using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Xunit;

using SelectElement = OpenQA.Selenium.Support.UI.SelectElement;

namespace DocumentConverter.UITests
{
    public class DocumentConverterUITests : IDisposable
    {
        private IWebDriver? _driver;
        private readonly string _baseUrl = "http://localhost:5000";

        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }

        private void InitializeChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            _driver = new ChromeDriver(options);
        }

        private void InitializeFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            _driver = new FirefoxDriver(options);
        }

        [Fact]
        public void Chrome_ConvertToDocx_ShouldDisplayConvertedContent()
        {
            InitializeChromeDriver();
            TestConvertToDocx();
        }

        [Fact]
        public void Chrome_ConvertToPdf_ShouldDisplayConvertedContent()
        {
            InitializeChromeDriver();
            TestConvertToPdf();
        }

        [Fact]
        public void Chrome_ConvertToTxt_ShouldDisplayConvertedContent()
        {
            InitializeChromeDriver();
            TestConvertToTxt();
        }

        [Fact(Skip = "Firefox tests run in CI/CD only")]
        public void Firefox_ConvertToDocx_ShouldDisplayConvertedContent()
        {
            InitializeFirefoxDriver();
            TestConvertToDocx();
        }

        [Fact(Skip = "Firefox tests run in CI/CD only")]
        public void Firefox_ConvertToPdf_ShouldDisplayConvertedContent()
        {
            InitializeFirefoxDriver();
            TestConvertToPdf();
        }

        private void TestConvertToDocx()
        {
            Assert.NotNull(_driver);
            _driver.Navigate().GoToUrl(_baseUrl);

            var contentTextarea = _driver.FindElement(By.Id("content"));
            contentTextarea.SendKeys("Test document");

            var formatSelect = new SelectElement(_driver.FindElement(By.Id("format")));
            formatSelect.SelectByValue("docx");

            var convertButton = _driver.FindElement(By.Id("convertBtn"));
            convertButton.Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var resultDiv = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("result")));

            var convertedContent = _driver.FindElement(By.Id("convertedContent")).Text;
            Assert.Equal("Test document [Converted to DOCX]", convertedContent);
        }

        private void TestConvertToPdf()
        {
            Assert.NotNull(_driver);
            _driver.Navigate().GoToUrl(_baseUrl);

            var contentTextarea = _driver.FindElement(By.Id("content"));
            contentTextarea.SendKeys("Test document");

            var formatSelect = new SelectElement(_driver.FindElement(By.Id("format")));
            formatSelect.SelectByValue("pdf");

            var convertButton = _driver.FindElement(By.Id("convertBtn"));
            convertButton.Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var resultDiv = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("result")));

            var convertedContent = _driver.FindElement(By.Id("convertedContent")).Text;
            Assert.Equal("Test document [Converted to PDF]", convertedContent);
        }

        private void TestConvertToTxt()
        {
            Assert.NotNull(_driver);
            _driver.Navigate().GoToUrl(_baseUrl);

            var contentTextarea = _driver.FindElement(By.Id("content"));
            contentTextarea.SendKeys("Test document");

            var formatSelect = new SelectElement(_driver.FindElement(By.Id("format")));
            formatSelect.SelectByValue("txt");

            var convertButton = _driver.FindElement(By.Id("convertBtn"));
            convertButton.Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var resultDiv = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("result")));

            var convertedContent = _driver.FindElement(By.Id("convertedContent")).Text;
            Assert.Equal("Test document [Converted to TXT]", convertedContent);
        }

        [Fact]
        public void Chrome_PageTitle_ShouldBeDocumentConverter()
        {
            InitializeChromeDriver();
            Assert.NotNull(_driver);
            _driver.Navigate().GoToUrl(_baseUrl);
            Assert.Equal("Document Converter", _driver.Title);
        }

        [Fact]
        public void Chrome_AllFormElementsExist_ShouldBePresent()
        {
            InitializeChromeDriver();
            Assert.NotNull(_driver);
            _driver.Navigate().GoToUrl(_baseUrl);

            Assert.NotNull(_driver.FindElement(By.Id("content")));
            Assert.NotNull(_driver.FindElement(By.Id("format")));
            Assert.NotNull(_driver.FindElement(By.Id("convertBtn")));
        }
    }
}
