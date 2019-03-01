using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace TestLeaf.PageObjects
{
    class InteractPage
    {
        private readonly IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/tooltip.html";

        public InteractPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "age")]
        [CacheLookup]
        IWebElement AgeTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "ui-id-12")]
        [CacheLookup]
        public IWebElement HideMe { get; set; }

        public void SetMouseOver()
        {
            var action = new Actions(_driver);

            action.MoveToElement(AgeTextBox).Build().Perform();
        }
    }
}
