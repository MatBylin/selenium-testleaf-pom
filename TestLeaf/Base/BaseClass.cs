using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace TestLeaf.Base
{
    public class BaseClass
    {
        protected IWebDriver driver;

        public void InitBrowser(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.IE:
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    throw new System.Exception();
            }
        }
    }
}
