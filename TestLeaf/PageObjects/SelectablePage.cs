using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Threading;


namespace TestLeaf.PageObjects
{
    class SelectablePage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/selectable.html";

        public SelectablePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "ui-widget-content")]
        [CacheLookup]
        public IList<IWebElement> ListOfItems { get; set; }

        public void SelectFirstThree()
        {
            for (int i = 0; i < 3; i++)
            {
                new Actions(_driver).KeyDown(Keys.Control).Click(ListOfItems[i]).Build().Perform();
            }
        }

        public void SelectOddsElements()
        {
            for (int i = 0; i < ListOfItems.Count; i++)
            {
                if (i % 2 == 0)
                    new Actions(_driver).KeyDown(Keys.Control).Click(ListOfItems[i]).Build().Perform();
            }
        }
    }
}
