using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestLeaf.PageObjects
{
    class SortablePage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/sortable.html";

        public SortablePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "ui-state-default")]
        [CacheLookup]
        public IList<IWebElement> ListOfItems { get; set; }



        public void FirstToLast()
        {
            IWebElement LastItem = ListOfItems[ListOfItems.Count - 1];
            IWebElement FirstItem = ListOfItems[0];

            var itemHeight = FirstItem.Size.Height;
            var itemWidth = FirstItem.Size.Width;

            Actions action = new Actions(_driver);
            action.ClickAndHold(FirstItem).MoveToElement(LastItem, itemWidth / 2, (itemHeight / 2) + 5).Release().Build().Perform();
        }

        public void LastToFirst()
        {
            IWebElement LastItem = ListOfItems[ListOfItems.Count - 1];
            IWebElement SecondItem = ListOfItems[1];

            var itemHeight = SecondItem.Size.Height;
            var itemWidth = SecondItem.Size.Width;

            Actions action = new Actions(_driver);
            action.ClickAndHold(LastItem).MoveToElement(SecondItem, itemWidth / 2, 0).Release().Build().Perform();
        }
    }
}
