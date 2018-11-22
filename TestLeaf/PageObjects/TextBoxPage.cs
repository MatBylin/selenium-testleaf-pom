using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestLeaf.Base;
using TestLeaf.Methods;

namespace TestLeaf.PageObjects
{
    public class TextBoxPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/Edit.html";

        public TextBoxPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.Id, Using ="email")]
        [CacheLookup]
        public IWebElement EmailTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Append ']")]
        [CacheLookup]
        public IWebElement AppendTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "username")]
        [CacheLookup]
        public IWebElement DefaultTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "username")]
        [CacheLookup]
        public IWebElement ClearTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'TestLeaf')]")]
        [CacheLookup]
        public IWebElement ConfirmTextBox { get; set; }

        public void GoToEditPage()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public void EnterEmail(string email)
        {
            EmailTextBox.EnterText(email);
        }

        public void AppendText(string text)
        {
            AppendTextBox.EnterText(text + Keys.Tab);
        }

        public string GetDefaultText()
        {
            string text = DefaultTextBox.GetTextBoxText();
            return text;
        }

        public bool IsTextBoxDisabled()
        {
            if (ConfirmTextBox.Enabled)
                return true;
            else
                return false;
        }
    }
}