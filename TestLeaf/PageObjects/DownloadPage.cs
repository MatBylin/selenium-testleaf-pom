using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestLeaf.PageObjects
{
    class DownloadPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/download.html";

        public DownloadPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='div']/h1/center/a")]
        [CacheLookup]
        public IWebElement DownloadLink { get; set; }

        public void ClickDownload()
        {
            /* Important thing is to initialize
             * browser with auto-download setting */
            DownloadLink.Click();
        }

        public bool CheckDownload()
        {
            return File.Exists("D:\\download.xls");
        }

    }
}
