using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeaf.PageObjects
{
    class FramesPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/frame.html";

        public FramesPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//iframe[@src='default.html']")]
        [CacheLookup]
        public IWebElement FirstIframe { get; set; }

        [FindsBy(How = How.Id, Using = "click")]
        [CacheLookup]
        public IWebElement FirstIframeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//iframe[@src='page.html']")]
        [CacheLookup]
        public IWebElement SecondIframe { get; set; }

        [FindsBy(How = How.Id, Using = "Click1")]
        [CacheLookup]
        public IWebElement NestedIframeButton { get; set; }

        [FindsBy(How = How.Id, Using = "frame2")]
        [CacheLookup]
        public IWebElement SecondNestedIframe { get; set; }

        [FindsBy(How = How.XPath, Using = "//iframe[@src='countframes.html']")]
        [CacheLookup]
        public IWebElement ThirdIframe { get; set; }

        public void ClickFirstIframe()
        {
            _driver.SwitchTo().Frame(FirstIframe);
            FirstIframeButton.Click();
        }

        public void ClickNestedIframe()
        {
            _driver.SwitchTo().Frame(SecondIframe);
            _driver.SwitchTo().Frame(SecondNestedIframe);
            NestedIframeButton.Click();
        }

        public int IframeCount()
        {
            return _driver.FindElements(By.TagName("iframe")).Count;
        }

    }
}
