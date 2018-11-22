using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace TestLeaf.PageObjects
{
    class AlertPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/Alert.html";

        public AlertPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@onclick='normalAlert()'][contains(.,'Alert Box')]")]
        [CacheLookup]
        public IWebElement AlertBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@onclick,'confirmAlert()')]")]
        [CacheLookup]
        public IWebElement ConfirmBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@onclick='confirmPrompt()']")]
        [CacheLookup]
        public IWebElement PromptBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@onclick='lineBreaks()'][contains(.,'Line Breaks?')]")]
        [CacheLookup]
        public IWebElement LineBreaksBox { get; set; }

        public void DisplayAlertBox()
        {
            AlertBox.Click();
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        public void DisplayAndConfirmAlertBox()
        {
            ConfirmBox.Click();
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void PromptAlertBox()
        {
            PromptBox.Click();
            IAlert alert = _driver.SwitchTo().Alert();
            alert.SendKeys("Some text");
            alert.Accept();
        }

        public string LineBreaksAlertBox()
        {
            LineBreaksBox.Click();
            IAlert alert = _driver.SwitchTo().Alert();
            string alertText = alert.Text;
            alert.Accept();
            //return alertText;

            if (alertText.Contains("\n"))
                return "Alert text contain line brake!";
            else
                return "Alert text does not contain line brake!";
        }
    }
}
