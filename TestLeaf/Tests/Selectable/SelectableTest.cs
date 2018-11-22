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
        }

        [Test, Order(2)]
        public void SelectAllOddsElements()
        {
            SelectablePage.SelectOddsElements();
            Thread.Sleep(2000);
        }

        [TearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}