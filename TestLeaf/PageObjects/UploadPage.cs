using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.IO;

namespace TestLeaf.PageObjects
{
    class UploadPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/upload.html";

        public UploadPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[contains(@type,'file')]")]
        [CacheLookup]
        public IWebElement UploadButton { get; set; }

        public void Upload(string path)
        {
            if (File.Exists(path))
                UploadButton.SendKeys(path);
            else
                Assert.Fail("Path do not exist");
        }
    }
}