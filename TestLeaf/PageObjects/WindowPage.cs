using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;


namespace TestLeaf.PageObjects
{
    class WindowPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/Window.html";

        public WindowPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "home")]
        [CacheLookup]
        public IWebElement HomePageButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@onclick='openWindows()'][contains(.,'Open Multiple Windows')]")]
        [CacheLookup]
        public IWebElement MultipleWindoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@onclick='openWindows();']")]
        [CacheLookup]
        public IWebElement DoNotCloseButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@onclick,'openWindowsWithWait();')]")]
        [CacheLookup]
        public IWebElement WaitForFiveSecondsButton { get; set; }

        public void OpenHomePage()
        {
            string parentWindow = _driver.CurrentWindowHandle;

            HomePageButton.Click();

            List<string> windowHandles = _driver.WindowHandles.ToList();

            //close new window handle
            _driver.SwitchTo().Window(windowHandles[1]);
            _driver.Close();
            //go back to patentWindow handle
            _driver.SwitchTo().Window(parentWindow);
        }

        public void OpenMultipleWindows()
        {
            string parentWindow = _driver.CurrentWindowHandle;

            MultipleWindoButton.Click();

            //Get all the open window handles
            List<string> windowHandles = _driver.WindowHandles.ToList();

            //Iterate through handles and if its not parentWindow close it
            foreach (var window in windowHandles)
            {
                if (!window.Equals(parentWindow))
                {
                    _driver.SwitchTo().Window(window);
                    _driver.Close();
                }
            }

            //return to parent window
            _driver.SwitchTo().Window(parentWindow);
        }

        public void DoNotCloseTwoNewWindows()
        {
            string parentWindow = _driver.CurrentWindowHandle;
            MultipleWindoButton.Click();
            //_driver.Close();
        }

        public void WaitForNewWindows(int n)
        {
            WaitForFiveSecondsButton.Click();
            Methods.Methods.ImplicitWaitForSeconds(_driver, n);
            string parentWindow = _driver.CurrentWindowHandle;
        }
    }
}
