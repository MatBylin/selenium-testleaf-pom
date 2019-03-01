using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TestLeaf.Methods;


namespace TestLeaf.PageObjects
{
    class DropDownPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/Dropdown.html";

        public DropDownPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "dropdown1")]
        [CacheLookup]
        public IWebElement IndexDropdown { get; set; }

        [FindsBy(How = How.Name, Using = "dropdown2")]
        [CacheLookup]
        public IWebElement TextDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "dropdown3")]
        [CacheLookup]
        public IWebElement ValueDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class='dropdown']")]
        [CacheLookup]
        public IWebElement PtionsDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='innerblock']/div[5]/select")]
        [CacheLookup]
        public IWebElement SendKeysDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='innerblock']/div[6]/select/option[2]")]
        [CacheLookup]
        public IWebElement MultiDropdownOption { get; set; }

        public void SelectByIndex()
        {
            IndexDropdown.SelectByIndex(2);
        }

        public void SelectByText()
        {
            TextDropdown.SelectByText("Selenium");
        }

        public void SelectByValue()
        {
            ValueDropdown.SelectByValue("2");
        }

        public int NumberOfOptions()
        {
            return IndexDropdown.NumberOfOptions();
        }

        public void SelectBySendKeys()
        {
            SendKeysDropdown.SendKeys("Selenium");
        }

        public void SelectMultiDrop()
        {
            MultiDropdownOption.Click();
        }
    }
}
