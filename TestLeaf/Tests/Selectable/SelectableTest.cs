using NUnit.Framework;
using System.Threading;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Selectable
{
    class SelectableTest : BaseClass
    {
        public SelectablePage SelectablePage { get; set; }

        [SetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(SelectablePage.BaseUrl);

            SelectablePage = new SelectablePage(driver);
        }

        [Test, Order(1)]
        public void SelectFirstThreeElements()
        {
            SelectablePage.SelectFirstThree();

            Assert.True(SelectablePage.ListOfItems[0].GetAttribute("class")
                == "ui-widget-content ui-selectee ui-selected");
            Assert.True(SelectablePage.ListOfItems[1].GetAttribute("class")
                == "ui-widget-content ui-selectee ui-selected");
            Assert.True(SelectablePage.ListOfItems[2].GetAttribute("class")
                == "ui-widget-content ui-selectee ui-selected");
        }

        [Test, Order(2)]
        public void SelectAllOddsElements()
        {
            SelectablePage.SelectOddsElements();

            Assert.True(SelectablePage.ListOfItems[6].GetAttribute("class")
                == "ui-widget-content ui-selectee ui-selected");
        }

        [TearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
