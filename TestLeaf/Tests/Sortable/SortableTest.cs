using NUnit.Framework;
using OpenQA.Selenium;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Sortable
{
    class SortableTest : BaseClass
    {
        public SortablePage SortablePage { get; set; }

        [SetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(SortablePage.BaseUrl);

            SortablePage = new SortablePage(driver);
        }

        [Test]
        public void FirstToLastAndLastToFirstElement()
        {
            SortablePage.FirstToLast();
            SortablePage.LastToFirst();

            IWebElement firstItem = driver.FindElement(By.ClassName("ui-state-default"));

            Assert.True(firstItem.Text == "Item 7");
        }

        [TearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
