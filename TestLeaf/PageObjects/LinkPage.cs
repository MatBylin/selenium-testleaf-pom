using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TestLeaf.Methods;

namespace TestLeaf.PageObjects
{
    class LinkPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/Link.html";

        public LinkPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='contentblock']/section/div[1]/div/div/a")]
        [CacheLookup]
        public IWebElement FirstHomeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@style,'color:green')]")]
        [CacheLookup]
        public IWebElement WhereButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Verify am I broken?')]")]
        [CacheLookup]
        public IWebElement BrokenButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='contentblock']/section/div[4]/div/div/a")]
        [CacheLookup]
        public IWebElement SecondHomeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'How many links are available in this page?')]")]
        [CacheLookup]
        public IWebElement HowManyButton { get; set; }


        public void ClickFirstHomePage()
        {
            FirstHomeButton.Click();
        }

        public string WhereRedirect()
        {
            return WhereButton.GetAttribute("href");
        }

        public bool VerifyBroken()
        {
            return BrokenButton.VerifyBrokenLink();
        }

        public void ClickSecondHomePage()
        {
            SecondHomeButton.Click();
        }

        public int HowManyLinks()
        {
           return _driver.FindElements(By.TagName("a")).Count;
        }
    }
}
